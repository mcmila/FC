using Imposto.Core.Domain;

namespace Imposto.Core.Service
{
    /// <summary>
    /// Classe de Service de Nota Fiscal
    /// </summary>
    public class NotaFiscalService
    {
        /// <summary>
        /// Gera uma nota fiscal de acordo com o pedido recebido
        /// </summary>
        /// <param name="pedido">Pedido</param>
        public void GerarNotaFiscal(Pedido pedido)
        {
            new NotaFiscal().EmitirNotaFiscal(pedido);
        }
    }
}