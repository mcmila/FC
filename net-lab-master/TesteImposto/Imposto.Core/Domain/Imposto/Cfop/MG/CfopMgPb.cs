namespace Imposto.Core.Domain.Imposto.Cfop.MG
{
    public class CfopMgPb : IImpostoCfop
    {
        public IImpostoCfop Proximo { get; set; }

        public string ObterCfop(Pedido pPedido)
        {
            if ((pPedido.EstadoOrigem == "MG") && (pPedido.EstadoDestino == "PB"))
                return "6.003";

            return Proximo.ObterCfop(pPedido);
        }
    }
}