using System;
using System.Data;
using System.Data.SqlClient;
using Imposto.Core.Domain;

namespace Imposto.Core.Data
{
    /// <summary>
    /// Classe Repository de Nota Fiscal
    /// </summary>
    public class NotaFiscalRepository
    {
        #region Métodos

        /// <summary>
        /// Insere uma Nota Fiscal
        /// </summary>
        /// <param name="pNotaFiscal">Nota Fiscal</param>
        /// <returns></returns>
        public static void InserirNotaFiscal(NotaFiscal pNotaFiscal)
        {
            using (SqlConnection con = new SqlConnection(BaseDao.ObterConectionString()))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    using (SqlCommand cmd = new SqlCommand("P_NOTA_FISCAL", con))
                    {
                        cmd.Transaction = transaction;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pNumeroNotaFiscal", pNotaFiscal.NumeroNotaFiscal);
                        cmd.Parameters.AddWithValue("@pSerie", pNotaFiscal.Serie);
                        cmd.Parameters.AddWithValue("@pNomeCliente", pNotaFiscal.NomeCliente);
                        cmd.Parameters.AddWithValue("@pEstadoDestino", pNotaFiscal.EstadoDestino);
                        cmd.Parameters.AddWithValue("@pEstadoOrigem", pNotaFiscal.EstadoOrigem);
                        cmd.Parameters.Add("@pId", SqlDbType.Int);
                        cmd.Parameters["@pId"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();

                        pNotaFiscal.Id = Convert.ToInt32(cmd.Parameters["@pId"].Value.ToString());
                    }

                    foreach (var notaFiscalItem in pNotaFiscal.ItensDaNotaFiscal)
                    {
                        notaFiscalItem.IdNotaFiscal = pNotaFiscal.Id;

                        using (SqlCommand cmd = new SqlCommand("P_NOTA_FISCAL_ITEM", con))
                        {
                            cmd.Transaction = transaction;
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@pIdNotaFiscal", notaFiscalItem.IdNotaFiscal);
                            cmd.Parameters.AddWithValue("@pCfop", notaFiscalItem.Cfop);
                            cmd.Parameters.AddWithValue("@pTipoIcms", notaFiscalItem.TipoIcms);
                            cmd.Parameters.AddWithValue("@pBaseIcms", notaFiscalItem.BaseIcms);
                            cmd.Parameters.AddWithValue("@pAliquotaIcms", notaFiscalItem.AliquotaIcms);
                            cmd.Parameters.AddWithValue("@pValorIcms", notaFiscalItem.ValorIcms);
                            cmd.Parameters.AddWithValue("@pNomeProduto", notaFiscalItem.NomeProduto);
                            cmd.Parameters.AddWithValue("@pCodigoProduto", notaFiscalItem.CodigoProduto);
                            cmd.Parameters.AddWithValue("@BaseIpi", notaFiscalItem.BaseIpi);
                            cmd.Parameters.AddWithValue("@ValorIpi", notaFiscalItem.ValorIpi);
                            cmd.Parameters.AddWithValue("@AliquotaIpi", notaFiscalItem.AliquotaIpi);
                            cmd.Parameters.AddWithValue("@Desconto", notaFiscalItem.Desconto);
                            cmd.Parameters.Add("@pId", SqlDbType.Int);
                            cmd.Parameters["@pId"].Direction = ParameterDirection.Output;

                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }

                con.Close();
            }
        }

        #endregion
    }
}