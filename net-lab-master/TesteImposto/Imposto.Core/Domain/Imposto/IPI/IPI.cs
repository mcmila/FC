namespace Imposto.Core.Domain.Imposto.IPI
{
    public static class Ipi
    {
        public static double CalculaAliquotaIpi(bool pBrinde)
        {
            if (pBrinde)
                return 0;

            return 0.10;
        }

        public static double CalculaValorIpi(double pBaseCalculoIpi, double pAliquotaIpi)
        {
            return pBaseCalculoIpi * pAliquotaIpi;
        }
    }
}