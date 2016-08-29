namespace Imposto.Core.Domain.Imposto.Cfop.MG
{
    public class CfopMgPi : IImpostoCfop
    {
        public IImpostoCfop Proximo { get; set; }

        public string ObterCfop(Pedido pPedido)
        {
            if ((pPedido.EstadoOrigem == "MG") && (pPedido.EstadoDestino == "PI"))
                return "6.005";

            return Proximo.ObterCfop(pPedido);
        }
    }
}