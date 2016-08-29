namespace Imposto.Core.Domain.Imposto.Cfop.MG
{
    public class CfopMgRo : IImpostoCfop
    {
        public IImpostoCfop Proximo { get; set; }

        public string ObterCfop(Pedido pPedido)
        {
            if ((pPedido.EstadoOrigem == "MG") && (pPedido.EstadoDestino == "RO"))
                return "6.006";

            return Proximo.ObterCfop(pPedido);
        }
    }
}