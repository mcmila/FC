namespace Imposto.Core.Domain.Imposto.Cfop.MG
{
    public class CfopMgPa : IImpostoCfop
    {
        public IImpostoCfop Proximo { get; set; }

        public string ObterCfop(Pedido pPedido)
        {
            if ((pPedido.EstadoOrigem == "MG") && (pPedido.EstadoDestino == "PA"))
                return "6.010";

            return Proximo.ObterCfop(pPedido);
        }
    }
}