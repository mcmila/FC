namespace Imposto.Core.Domain.Imposto.Cfop
{
    public interface IImpostoCfop
    {
        /// <summary>
        /// Obter CFOP
        /// </summary>
        /// <param name="pPedido"></param>
        /// <returns></returns>
        string ObterCfop(Pedido pPedido);

        /// <summary>
        /// Próximo Item
        /// </summary>
        IImpostoCfop Proximo { get; set; }
    }
}
