namespace Imposto.Core.Domain.Imposto.Cfop.SP
{
    public class CfopSpPa : IImpostoCfop
    {
        public IImpostoCfop Proximo { get; set; }

        public string ObterCfop(Pedido pPedido)
        {
            if ((pPedido.EstadoOrigem == "SP") && (pPedido.EstadoDestino == "PA"))
                return "6.010";

            return Proximo.ObterCfop(pPedido);
        }
    }
}