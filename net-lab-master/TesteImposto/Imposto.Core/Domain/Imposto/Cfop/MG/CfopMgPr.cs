namespace Imposto.Core.Domain.Imposto.Cfop.MG
{
    public class CfopMgPr : IImpostoCfop
    {
        public IImpostoCfop Proximo { get; set; }

        public string ObterCfop(Pedido pPedido)
        {
            if ((pPedido.EstadoOrigem == "MG") && (pPedido.EstadoDestino == "PR"))
                return "6.004";

            return Proximo.ObterCfop(pPedido);
        }
    }
}