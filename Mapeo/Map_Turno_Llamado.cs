using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapeo
{
    public class Map_Turno_Llamado
    {
        public List<Ent_Turno_Llamado> Traer_Turnos(int id_area)
        {
            DataTable dt = new DataTable();

            List<Ent_Turno_Llamado> lista = new List<Ent_Turno_Llamado>();
            try
            {
                var sp = "sp_datos_visualizador";
                SqlConnection con = new SqlConnection(Conexion.Cn);
                con.Open();
                SqlCommand cm = new SqlCommand(sp, con);
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cm);
                cm.Parameters.AddWithValue("id_area", id_area);
                da.Fill(dt);

                if (dt != null)
                {
                    if (dt.Rows.Count == 0)
                    {
                        Ent_Turno_Llamado entidad = new Ent_Turno_Llamado();
                        entidad.Id = 0;
                        entidad.Turno = "";
                        entidad.Puesto = "";
                        lista.Add(entidad);
                    }
                    else
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            Ent_Turno_Llamado entidad = new Ent_Turno_Llamado();
                            entidad.Id = Convert.ToInt32(dt.Rows[i]["Id"].ToString());
                            entidad.Turno = dt.Rows[i]["Turno"].ToString();
                            entidad.Puesto = dt.Rows[i]["Puesto"].ToString();
                            lista.Add(entidad);
                        }
                    }
                }

                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lista;
        }
    }
}
