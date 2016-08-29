namespace Imposto.Core.Domain.Imposto.Cfop.MG
{
    public class CfopMgSe : IImpostoCfop
    {
        public IImpostoCfop Proximo { get; set; }

        public string ObterCfop(Pedido pPedido)
        {
            if ((pPedido.EstadoOrigem == "MG") && (pPedido.EstadoDestino == "SE"))
                return "6.007";

            return Proximo.ObterCfop(pPedido);
        }
    }
}