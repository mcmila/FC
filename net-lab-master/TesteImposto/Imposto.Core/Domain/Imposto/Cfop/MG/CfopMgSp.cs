namespace Imposto.Core.Domain.Imposto.Cfop.MG
{
    public class CfopMgSp : IImpostoCfop
    {
        public IImpostoCfop Proximo { get; set; }

        public string ObterCfop(Pedido pPedido)
        {
            if ((pPedido.EstadoOrigem == "MG") && (pPedido.EstadoDestino == "SP"))
                return "6.000";

            return Proximo.ObterCfop(pPedido);
        }
    }
}