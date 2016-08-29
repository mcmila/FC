namespace Imposto.Core.Domain.Imposto.Cfop.SP
{
    public class CfopSpRo : IImpostoCfop
    {
        public IImpostoCfop Proximo { get; set; }

        public string ObterCfop(Pedido pPedido)
        {
            if ((pPedido.EstadoOrigem == "SP") && (pPedido.EstadoDestino == "RO"))
                return "6.006";

            return Proximo.ObterCfop(pPedido);
        }
    }
}