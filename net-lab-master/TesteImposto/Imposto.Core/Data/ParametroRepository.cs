using System.Data;
using System.Data.SqlClient;
using Imposto.Core.Domain;

namespace Imposto.Core.Data
{
    /// <summary>
    /// Classe Service de Parâmetros
    /// </summary>
    public class ParametrosService
    {
        #region Métodos

        /// <summary>
        /// Consulta parâmetros
        /// </summary>
        /// <returns></returns>
        public static Parametros Consultar()
        {
            Parametros parametros = new Parametros();
            using (SqlConnection con = new SqlConnection(BaseDao.ObterConectionString()))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("P_PARAMETROS", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            parametros.PathXmlNotaFiscal = reader.GetString(reader.GetOrdinal("PATHXMLNF"));
                    }
                }

                con.Close();
            }

            return parametros;
        }
        
        #endregion
    }
}
