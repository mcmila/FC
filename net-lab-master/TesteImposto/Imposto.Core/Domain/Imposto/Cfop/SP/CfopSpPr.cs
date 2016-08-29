namespace Imposto.Core.Domain.Imposto.Cfop.SP
{
    public class CfopSpPr : IImpostoCfop
    {
        public IImpostoCfop Proximo { get; set; }

        public string ObterCfop(Pedido pPedido)
        {
            if ((pPedido.EstadoOrigem == "SP") && (pPedido.EstadoDestino == "PR"))
                return "6.004";

            return Proximo.ObterCfop(pPedido);
        }
    }
}