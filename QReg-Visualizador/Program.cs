using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QReg_Visualizador
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            int modo_rapido_activado = Convert.ToInt16(ConfigurationManager.AppSettings["Inicio_Rapido_Activado"].ToString());

            if (modo_rapido_activado == 1)
            {
                int modo_rapido_area = Convert.ToInt16(ConfigurationManager.AppSettings["Inicio_Rapido_Area"].ToString());
                //Declaro la lista a pasarle al formulario y la instancia de la clase de
                List<Ent_Turno_Llamado> lista = new List<Ent_Turno_Llamado>();
                Neg_Turno_Llamado ngl = new Neg_Turno_Llamado();

                //Asigno la coleccion a la lista antes creada.
                lista = ngl.Traer_Turnos(modo_rapido_area);

                Application.Run(new Visualizador(modo_rapido_area, lista));
            }
            else
            {
                Application.Run(new Inicio());
            }
        }
    }
}
