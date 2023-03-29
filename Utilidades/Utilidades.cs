using Entidades;
using Negocio;
using QReg_Visualizador;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades
{
    public class Utilidades
    {
        #region "Variables"
        Neg_Turno_Llamado ntl = new Neg_Turno_Llamado();
        #endregion

        private void CargarInicioRapido()
        {
            int activado = Convert.ToInt32(ConfigurationManager.AppSettings["Inicio_Rapido_Activado"].ToString());
            int id_area = Convert.ToInt32(ConfigurationManager.AppSettings["Inicio_Rapido_Area"].ToString());

            if (activado == 1)
            {
                List<Ent_Turno_Llamado> lista = new List<Ent_Turno_Llamado>();
                lista = ntl.Traer_Turnos(id_area);
            }
        }
    }
}
