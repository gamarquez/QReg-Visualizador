using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QReg_Visualizador
{
    public partial class Inicio : Form
    {
        #region "Variables de instancia"
        Neg_Area na = new Neg_Area();
        Neg_Turno_Llamado ntl = new Neg_Turno_Llamado();
        #endregion

        public Inicio()
        {
            InitializeComponent();
            CargarCombo();
            CargarInicioRapido();
        }

        private void CargarCombo()
        {
            cmbAreas.DataSource = na.Traer_Todas();
            cmbAreas.DisplayMember = "Descripcion";
            cmbAreas.ValueMember = "Id_Area";
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            int id_area = Convert.ToInt16(cmbAreas.SelectedValue.ToString());

            List<Ent_Turno_Llamado> lista = new List<Ent_Turno_Llamado>();
            lista = ntl.Traer_Turnos(id_area);

            Visualizador v = new Visualizador(id_area, lista);
            v.Show();
            this.Hide();
        }

        private void CargarInicioRapido()
        {
            int activado = Convert.ToInt32(ConfigurationManager.AppSettings["Inicio_Rapido_Activado"].ToString());
            int id_area = Convert.ToInt32(ConfigurationManager.AppSettings["Inicio_Rapido_Area"].ToString());

            if (activado == 1)
            {
                List<Ent_Turno_Llamado> lista = new List<Ent_Turno_Llamado>();
                lista = ntl.Traer_Turnos(id_area);

                Visualizador v = new Visualizador(id_area, lista);
                v.Show();
                this.WindowState = FormWindowState.Minimized;
            }
        }
    }
}
