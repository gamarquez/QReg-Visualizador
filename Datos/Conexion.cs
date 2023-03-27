using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Conexion
    {
        public static string Cn = ConfigurationManager.ConnectionStrings["SQLCon"].ConnectionString;
    }
}
