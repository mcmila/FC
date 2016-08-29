using Imposto.Core.Domain.Imposto.Cfop.MG;
using Imposto.Core.Domain.Imposto.Cfop.SP;

namespace Imposto.Core.Domain.Imposto.Cfop
{
    /// <summary>
    /// Classe que calcula CFOP
    /// </summary>
    public class CalculaCfop
    {
        /// <summary>
        /// Obtém Imposto CFOP
        /// </summary>
        /// <param name="pPedido"></param>
        /// <returns></returns>
        public string ObterCfop(Pedido pPedido)
        {
            #region SP
            IImpostoCfop cfop1 = new CfopSpMg();
            IImpostoCfop cfop2 = new CfopSpPa();
            IImpostoCfop cfop3 = new CfopSpPb();
            IImpostoCfop cfop4 = new CfopSpPe();
            IImpostoCfop cfop5 = new CfopSpPi();
            IImpostoCfop cfop6 = new CfopSpPr();
            IImpostoCfop cfop7 = new CfopSpRj();
            IImpostoCfop cfop8 = new CfopSpRo();
            IImpostoCfop cfop9 = new CfopSpSe();
            IImpostoCfop cfop10 = new CfopSpTo();
            #endregion

            #region MG
            IImpostoCfop cfop11 = new CfopMgPa();
            IImpostoCfop cfop12 = new CfopMgPb();
            IImpostoCfop cfop13 = new CfopMgPe();
            IImpostoCfop cfop14 = new CfopMgPi();
            IImpostoCfop cfop15 = new CfopMgPr();
            IImpostoCfop cfop16 = new CfopMgRj();
            IImpostoCfop cfop17 = new CfopMgRo();
            IImpostoCfop cfop18 = new CfopMgSe();
            IImpostoCfop cfop19 = new CfopMgTo(); 
            #endregion

            //SemCfop
            IImpostoCfop semCfop = new SemCfop();

            cfop1.Proximo = cfop2;
            cfop2.Proximo = cfop3;
            cfop3.Proximo = cfop4;
            cfop4.Proximo = cfop5;
            cfop5.Proximo = cfop6;
            cfop6.Proximo = cfop7;
            cfop7.Proximo = cfop8;
            cfop8.Proximo = cfop9;
            cfop9.Proximo = cfop10;
            cfop10.Proximo = cfop11;
            cfop11.Proximo = cfop12;
            cfop12.Proximo = cfop13;
            cfop13.Proximo = cfop14;
            cfop14.Proximo = cfop15;
            cfop15.Proximo = cfop16;
            cfop16.Proximo = cfop17;
            cfop17.Proximo = cfop18;
            cfop18.Proximo = cfop19;
            cfop19.Proximo = semCfop;

            return cfop1.ObterCfop(pPedido);
        }
    }
}