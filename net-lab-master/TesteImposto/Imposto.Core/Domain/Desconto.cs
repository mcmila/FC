namespace Imposto.Core.Domain
{
    /// <summary>
    /// Classe de Descontos
    /// </summary>
    public static class Desconto
    {
        /// <summary>
        /// Obtém descontos disponíveis de acordo com o estado
        /// </summary>
        /// <param name="pEstado">Estado</param>
        /// <returns></returns>
        public static double ObterDesconto(string pEstado)
        {
            switch (pEstado)
            {
                case "SP":
                    return 0.10;

                case "MG":
                    return 0.10;

                case "RJ":
                    return 0.10;

                case "ES":
                    return 0.10;
            }

            return 0;
        }
    }
}