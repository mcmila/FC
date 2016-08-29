namespace Imposto.Core.Domain.Imposto.Cfop.SP
{
    public class CfopSpRj : IImpostoCfop
    {
        public IImpostoCfop Proximo { get; set; }

        public string ObterCfop(Pedido pPedido)
        {
            if ((pPedido.EstadoOrigem == "SP") && (pPedido.EstadoDestino == "RJ"))
                return "6.000";

            return Proximo.ObterCfop(pPedido);
        }
    }
}