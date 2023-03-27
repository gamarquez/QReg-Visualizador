using Entidades;
using Mapeo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Neg_Turno_Llamado
    {
        #region "Variables de instancia"

        Map_Turno_Llamado map = new Map_Turno_Llamado();
        #endregion

        public List<Ent_Turno_Llamado> Traer_Turnos(int id_area)
        {
            List<Ent_Turno_Llamado> lista = new List<Ent_Turno_Llamado>();
            try
            {
                lista = map.Traer_Turnos(id_area);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lista;
        }
    }
}
