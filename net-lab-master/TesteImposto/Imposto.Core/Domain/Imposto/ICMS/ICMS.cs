namespace Imposto.Core.Domain.Imposto.ICMS
{
    public static class Icms
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pBrinde"></param>
        /// <param name="pEstadoDestino"></param>
        /// <param name="pEstadoOrigem"></param>
        /// <returns></returns>
        public static string ObterTipoIcms(bool pBrinde, string pEstadoDestino, string pEstadoOrigem)
        {
            if (pBrinde)
                return "60";

            if (pEstadoDestino == pEstadoOrigem)
                return "60";

            return "10";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pBrinde"></param>
        /// <param name="pEstadoDestino"></param>
        /// <param name="pEstadoOrigem"></param>
        /// <returns></returns>
        public static double ObterAliquotaIcms(bool pBrinde, string pEstadoDestino, string pEstadoOrigem)
        {
            if (pBrinde)
                return 0.18;

            if (pEstadoDestino == pEstadoOrigem)
                return 0.18;

            return 0.17;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCfop"></param>
        /// <param name="pValorItemPedido"></param>
        /// <returns></returns>
        public static double CalcularBaseIcms(string pCfop, double pValorItemPedido)
        {
            if (pCfop == "6.009")
                //Redução de base
                return pValorItemPedido * 0.90; 

            return pValorItemPedido;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pBaseIcms"></param>
        /// <param name="pAliquotaIcms"></param>
        /// <returns></returns>
        public static double CalcularValorIcms(double pBaseIcms, double pAliquotaIcms)
        {
            return pBaseIcms * pAliquotaIcms;
        }
    }
}