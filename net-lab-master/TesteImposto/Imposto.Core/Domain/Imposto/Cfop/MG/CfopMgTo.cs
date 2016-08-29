namespace Imposto.Core.Domain.Imposto.Cfop.MG
{
    public class CfopMgTo : IImpostoCfop
    {
        public IImpostoCfop Proximo { get; set; }

        public string ObterCfop(Pedido pPedido)
        {
            if ((pPedido.EstadoOrigem == "MG") && (pPedido.EstadoDestino == "TO"))
                return "6.008";

            return Proximo.ObterCfop(pPedido);
        }
    }
}