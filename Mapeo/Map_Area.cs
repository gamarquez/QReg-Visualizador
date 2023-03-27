using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapeo
{
    public class Map_Area
    {
        public DataTable Traer_Todas()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection con = new SqlConnection(Conexion.Cn);

                con.Open();

                var query = "SELECT * FROM Area_De_Servicio";
                var comando = new SqlCommand(query, con);

                SqlDataAdapter da = new SqlDataAdapter(comando);
                da.Fill(dt);
                con.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
