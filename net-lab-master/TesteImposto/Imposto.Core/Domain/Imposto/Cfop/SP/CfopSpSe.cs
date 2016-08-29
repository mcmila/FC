namespace Imposto.Core.Domain.Imposto.Cfop.SP
{
    public class CfopSpSe : IImpostoCfop
    {
        public IImpostoCfop Proximo { get; set; }

        public string ObterCfop(Pedido pPedido)
        {
            if ((pPedido.EstadoOrigem == "SP") && (pPedido.EstadoDestino == "SE"))
                return "6.007";

            return Proximo.ObterCfop(pPedido);
        }
    }
}