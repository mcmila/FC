namespace Imposto.Core.Domain.Imposto.Cfop.SP
{
    public class CfopSpTo : IImpostoCfop
    {
        public IImpostoCfop Proximo { get; set; }

        public string ObterCfop(Pedido pPedido)
        {
            if ((pPedido.EstadoOrigem == "SP") && (pPedido.EstadoDestino == "TO"))
                return "6.008";

            return Proximo.ObterCfop(pPedido);
        }
    }
}