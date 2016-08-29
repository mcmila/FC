namespace Imposto.Core.Domain.Imposto.Cfop.SP
{
    public class CfopSpPi : IImpostoCfop
    {
        public IImpostoCfop Proximo { get; set; }

        public string ObterCfop(Pedido pPedido)
        {
            if ((pPedido.EstadoOrigem == "SP") && (pPedido.EstadoDestino == "PI"))
                return "6.005";

            return Proximo.ObterCfop(pPedido);
        }
    }
}