using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Imposto.Core.Data;
using Imposto.Core.Domain.Imposto.Cfop;
using Imposto.Core.Domain.Imposto.ICMS;
using Imposto.Core.Domain.Imposto.IPI;

namespace Imposto.Core.Domain
{
    public class NotaFiscal
    {
        #region Construtores

        public NotaFiscal()
        {
            ItensDaNotaFiscal = new List<NotaFiscalItem>();
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Número da Nota Fiscal
        /// </summary>
        public int NumeroNotaFiscal { get; set; }

        /// <summary>
        /// Série
        /// </summary>
        public int Serie { get; set; }

        /// <summary>
        /// Nome Cliente
        /// </summary>
        public string NomeCliente { get; set; }

        /// <summary>
        /// Estado Destino
        /// </summary>
        public string EstadoDestino { get; set; }

        /// <summary>
        /// Estado Origem
        /// </summary>
        public string EstadoOrigem { get; set; }

        /// <summary>
        /// Itens da Nota Fiscal
        /// </summary>
        public IList<NotaFiscalItem> ItensDaNotaFiscal { get; set; }

        #endregion

        #region Métodos

        public void EmitirNotaFiscal(Pedido pedido)
        {
            NumeroNotaFiscal = 99999;
            Serie = new Random().Next(int.MaxValue);
            NomeCliente = pedido.NomeCliente;

            EstadoDestino = pedido.EstadoOrigem;
            EstadoOrigem = pedido.EstadoDestino;

            foreach (PedidoItem itemPedido in pedido.ItensDoPedido)
            {
                NotaFiscalItem notaFiscalItem = new NotaFiscalItem();

                notaFiscalItem.Cfop = new CalculaCfop().ObterCfop(pedido);

                //ICMS
                notaFiscalItem.AliquotaIcms = Icms.ObterAliquotaIcms(itemPedido.Brinde, pedido.EstadoDestino, pedido.EstadoOrigem);
                notaFiscalItem.TipoIcms = Icms.ObterTipoIcms(itemPedido.Brinde, pedido.EstadoDestino, pedido.EstadoOrigem);
                notaFiscalItem.BaseIcms = Icms.CalcularBaseIcms(notaFiscalItem.Cfop, itemPedido.ValorItemPedido);
                notaFiscalItem.ValorIcms = Icms.CalcularValorIcms(notaFiscalItem.BaseIcms, notaFiscalItem.AliquotaIcms);

                //API
                notaFiscalItem.AliquotaIpi = Ipi.CalculaAliquotaIpi(itemPedido.Brinde);
                notaFiscalItem.BaseIpi = itemPedido.ValorItemPedido;
                notaFiscalItem.ValorIpi = Ipi.CalculaValorIpi(notaFiscalItem.BaseIpi, notaFiscalItem.AliquotaIpi);

                notaFiscalItem.Desconto = Desconto.ObterDesconto(pedido.EstadoDestino);

                notaFiscalItem.NomeProduto = itemPedido.NomeProduto;
                notaFiscalItem.CodigoProduto = itemPedido.CodigoProduto;

                this.ItensDaNotaFiscal.Add(notaFiscalItem);
            }

            //Gera XML da Nota Fiscal
            //GerarXmlNotaFiscal(this);

            //Insere Nota Fiscal no Banco de Dados
            NotaFiscalRepository.InserirNotaFiscal(this);
        }

        private static void GerarXmlNotaFiscal(NotaFiscal pNotaFiscal)
        {
            try
            {
                string path = Path.Combine(ParametrosService.Consultar().PathXmlNotaFiscal, pNotaFiscal.NomeCliente + ".xml");

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                FileStream fileStream = new FileStream(path, FileMode.CreateNew);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(NotaFiscal));
                xmlSerializer.Serialize(fileStream, pNotaFiscal);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro ao gerar XML da Nota Fiscal. Mensagem Original: {0}", ex.Message), ex);
            }
        }

        #endregion
    }
}