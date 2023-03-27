using Mapeo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Neg_Area
    {
        #region "Variables de instancia"

        Map_Area ms = new Map_Area();

        #endregion

        public DataTable Traer_Todas()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ms.Traer_Todas();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
