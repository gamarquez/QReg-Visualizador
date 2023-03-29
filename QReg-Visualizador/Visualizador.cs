using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QReg_Visualizador
{
    public partial class Visualizador : Form
    {
        #region "Variables de instancia
        Neg_Turno_Llamado ntl = new Neg_Turno_Llamado();
        #endregion

        int area;
        int xClick = 0, yClick = 0;
        public List<Ent_Turno_Llamado> lista_cargada = new List<Ent_Turno_Llamado>();

        public Visualizador(int id_area, List<Ent_Turno_Llamado> lista)
        {
            area = id_area;
            InitializeComponent();
            lista_cargada = lista;
            FormatoGrilla(lista_cargada);
            FormatoForm();
        }

        private void FormatoGrilla(List<Ent_Turno_Llamado> lista)
        {
            //Asigno el datasource de la grilla.
            dgvTurnos.DataSource = lista;
            //Oculto la columna ID
            dgvTurnos.Columns["Id"].Visible = false;
            //Seteo la fila seleccionada default a nula.
            dgvTurnos.CurrentCell = null;
            //Asigno el tamaño del alto en cada fila.
            dgvTurnos.RowTemplate.Height = Convert.ToInt16(ConfigurationManager.AppSettings["Alto_Fila"].ToString());
        }

        private void FormatoForm()
        {
            //Establezco alto y ancho del formulario.
            this.Width = Convert.ToInt16(ConfigurationManager.AppSettings["Ancho"].ToString());
            this.Height = Convert.ToInt16(ConfigurationManager.AppSettings["Alto"].ToString());
        }

        private void TimerCargarDatos_Tick(object sender, EventArgs e)
        {
            if (dgvTurnos.Rows.Count > 0)
            {
                int id_turno_llamado = Convert.ToInt32(dgvTurnos.Rows[0].Cells["Id"].Value.ToString());
                List<Ent_Turno_Llamado> segunda_lista = new List<Ent_Turno_Llamado>();
                Ent_Turno_Llamado entidad = new Ent_Turno_Llamado();
                segunda_lista = ntl.Traer_Turnos(area);
                entidad = segunda_lista.First();

                if(entidad.Id != id_turno_llamado)
                {
                    dgvTurnos.DataSource = segunda_lista;
                    Ping();
                }
            }
        }

        private void Ping()
        {
            SystemSounds.Exclamation.Play();
        }

        private void ColorearCeldas()
        {
            dgvTurnos.DefaultCellStyle.SelectionBackColor = Color.MediumAquamarine;
            dgvTurnos.Rows[0].DefaultCellStyle.BackColor = Color.MediumAquamarine;
            dgvTurnos.Columns[1].Width = Convert.ToInt16(ConfigurationManager.AppSettings["Ancho_Columna_Turno"].ToString());
            dgvTurnos.Columns[2].Width = Convert.ToInt16(ConfigurationManager.AppSettings["Ancho_Columna_Puesto"].ToString());
        }

        private void Visualizador_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dgvTurnos_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }

        private void Visualizador_Load(object sender, EventArgs e)
        {
            CargarUbicacion();
        }

        private void dgvTurnos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ColorearCeldas();
        }

        private void CargarUbicacion()
        {
            //Recupero datos del archivo .config
            int activo = Convert.ToInt32(ConfigurationManager.AppSettings["Ubicacion_Automatica_Activada"].ToString());
            int posicion = Convert.ToInt32(ConfigurationManager.AppSettings["Ubicacion_Automatica_Posicion"].ToString());
            this.StartPosition = FormStartPosition.Manual;
            Rectangle workArea = Screen.GetWorkingArea(this);

            if (activo == 1)
            {
                if (posicion != 0 && posicion != 1)
                {
                    MessageBox.Show("Error al recuperar posicion. Se cerrara el programa.");
                    Application.Exit();
                }
                else
                {
                    if (posicion == 1)
                    {
                        Left = workArea.Right - this.Width;
                    }
                    else
                    {
                        Left = workArea.Left;
                    }
                }
            }
        }
    }
}
