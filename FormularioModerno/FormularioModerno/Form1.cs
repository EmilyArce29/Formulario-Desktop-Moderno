using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace FormularioModerno
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState=FormWindowState.Normal;
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnIncio_Click(null, e);
        }


        private void bntMiximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private  extern  static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private  extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012,0);
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            SubmenuReportes.Visible = true;
        }

        private void SubmenuReportes_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnReporteVentas_Click(object sender, EventArgs e)
        {
            SubmenuReportes.Visible = false;
        }

        private void btnReporteComrpas_Click(object sender, EventArgs e)
        {
            SubmenuReportes.Visible = false;
        }

        private void bntReportesPagos_Click(object sender, EventArgs e)
        {
            SubmenuReportes.Visible = false;
        }

        public void AbrirFormsHija(object formhija)
        {
            if (this.panelContendor.Controls.Count > 0)
               this.panelContendor.Controls.RemoveAt(0);
            Form fh = formhija as Form;
            fh.TopLevel = false;
            fh.Dock= DockStyle.Fill;
            this.panelContendor.Controls.Add(fh);
            this.panelContendor.Tag = fh;
            fh.Show();
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            AbrirFormsHija(new productos());
        }

        private void btnIncio_Click(object sender, EventArgs e)
        {
            AbrirFormsHija(new inicio());
        }
    }
}
