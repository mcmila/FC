namespace Imposto.Core.Domain.Imposto.Cfop.MG
{
    public class CfopMgPe : IImpostoCfop
    {
        public IImpostoCfop Proximo { get; set; }

        public string ObterCfop(Pedido pPedido)
        {
            if ((pPedido.EstadoOrigem == "MG") && (pPedido.EstadoDestino == "PE"))
                return "6.001";

            return Proximo.ObterCfop(pPedido);
        }
    }
}