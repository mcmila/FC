namespace Imposto.Core.Domain
{
    public class PedidoItem
    {
        #region Propriedades

        /// <summary>
        /// Nome do Produto
        /// </summary>
        public string NomeProduto { get; set; }

        /// <summary>
        /// Código do Produto
        /// </summary>
        public string CodigoProduto { get; set; }

        /// <summary>
        /// Valor do Item
        /// </summary>
        public double ValorItemPedido { get; set; }

        /// <summary>
        /// Brinde
        /// </summary>
        public bool Brinde { get; set; }       

        #endregion
    }
}