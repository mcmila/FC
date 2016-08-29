namespace Imposto.Core.Domain.Imposto.Cfop
{
    public class SemCfop : IImpostoCfop 
    {
        public IImpostoCfop Proximo { get; set; }

        public string ObterCfop(Pedido pPedido)
        {
            return string.Empty;
        }
    }
}