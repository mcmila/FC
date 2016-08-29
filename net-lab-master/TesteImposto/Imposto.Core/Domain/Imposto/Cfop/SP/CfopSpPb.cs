namespace Imposto.Core.Domain.Imposto.Cfop.SP
{
    public class CfopSpPb : IImpostoCfop
    {
        public IImpostoCfop Proximo { get; set; }

        public string ObterCfop(Pedido pPedido)
        {
            if ((pPedido.EstadoOrigem == "SP") && (pPedido.EstadoDestino == "PB"))
                return "6.003";

            return Proximo.ObterCfop(pPedido);
        }
    }
}