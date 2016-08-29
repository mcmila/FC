using System.Collections.Generic;

namespace Imposto.Core.Domain
{
    public class Pedido
    {
        #region Construtores

        public Pedido()
        {
            ItensDoPedido = new List<PedidoItem>();
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Estado de Destino
        /// </summary>
        public string EstadoDestino { get; set; }

        /// <summary>
        /// Estado de Origem
        /// </summary>
        public string EstadoOrigem { get; set; }

        /// <summary>
        /// Nome do Cliente
        /// </summary>
        public string NomeCliente { get; set; }

        /// <summary>
        /// Itens do Pedido
        /// </summary>
        public List<PedidoItem> ItensDoPedido { get; set; } 

        #endregion
    }
}