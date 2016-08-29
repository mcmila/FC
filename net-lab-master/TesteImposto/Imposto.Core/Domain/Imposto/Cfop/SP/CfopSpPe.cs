namespace Imposto.Core.Domain.Imposto.Cfop.SP
{
    public class CfopSpPe : IImpostoCfop
    {
        public IImpostoCfop Proximo { get; set; }

        public string ObterCfop(Pedido pPedido)
        {
            if ((pPedido.EstadoOrigem == "SP") && (pPedido.EstadoDestino == "PE"))
                return "6.001";

            return Proximo.ObterCfop(pPedido);
        }
    }
}