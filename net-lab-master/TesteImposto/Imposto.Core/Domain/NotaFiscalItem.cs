namespace Imposto.Core.Domain
{
    /// <summary>
    /// Classe de Item de Nota Fiscal
    /// </summary>
    public class NotaFiscalItem
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id da Nota Fiscal
        /// </summary>
        public int IdNotaFiscal { get; set; }

        /// <summary>
        /// CFOP
        /// </summary>
        public string Cfop { get; set; }

        /// <summary>
        /// Tipo ICMS
        /// </summary>
        public string TipoIcms { get; set; }

        /// <summary>
        /// Base ICMS
        /// </summary>
        public double BaseIcms { get; set; }

        /// <summary>
        /// Alíquota ICMS
        /// </summary>
        public double AliquotaIcms { get; set; }

        /// <summary>
        /// Valor ICMS
        /// </summary>
        public double ValorIcms { get; set; }

        /// <summary>
        /// Nome do Produto
        /// </summary>
        public string NomeProduto { get; set; }

        /// <summary>
        /// Código do Produto
        /// </summary>
        public string CodigoProduto { get; set; }

        /// <summary>
        /// Base IPI
        /// </summary>
        public double BaseIpi { get; set; }

        /// <summary>
        /// AlÍquota IPI
        /// </summary>
        public double AliquotaIpi { get; set; }

        /// <summary>
        /// Valor IPI
        /// </summary>
        public double ValorIpi { get; set; }

        /// <summary>
        /// Desconto
        /// </summary>
        public double Desconto { get; set; }
    }
}