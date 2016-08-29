namespace Imposto.Core.Domain.Imposto.Cfop.SP
{
    class CfopSpMg : IImpostoCfop
    {
        public IImpostoCfop Proximo { get; set; }

        public string ObterCfop(Pedido pPedido)
        {
            if ((pPedido.EstadoOrigem == "SP") && (pPedido.EstadoDestino == "MG"))
                return "6.002";

            return Proximo.ObterCfop(pPedido);
        }
    }
}