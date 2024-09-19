using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdminEmpleados.BLL;
using AdminEmpleados.DAL;
using AdminEmpleados.PL;
namespace AdminEmpleados.PL
{
    public partial class frmEmpleados : Form
    {

        byte[] imagenByte;

        public frmEmpleados()
        {
            InitializeComponent();
        }

        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            DepartamentosDAL departamentosDAL = new DepartamentosDAL();

            cbxDepartamento.DataSource = departamentosDAL.mostrarDepartamentos().Tables[0];
            cbxDepartamento.DisplayMember = "departamento";
            cbxDepartamento.ValueMember = "ID";

        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "Seleccionar imagen";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picFoto.Image = Image.FromStream(ofd.OpenFile());
                MemoryStream memoria  = new MemoryStream();
                picFoto.Image.Save(memoria, System.Drawing.Imaging.ImageFormat.Png);

                imagenByte = memoria.ToArray();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            RecolectarDatos();
        }

        private void RecolectarDatos()
        {
            EmpleadosBLL empleadosBLL = new EmpleadosBLL();

            int codigoEmpleado = 1;

            int.TryParse(txtID.Text, out codigoEmpleado);

            empleadosBLL.ID = codigoEmpleado;
            empleadosBLL.NombreEmpleado = txtNombre.Text;
            empleadosBLL.PrimerApellido = txtPrimerApellido.Text;
            empleadosBLL.SegundoApellido = txtSegundoApellido.Text;
            empleadosBLL.Correo = txtCorreo.Text;

            int IDDepartamento = 0;

            int.TryParse(cbxDepartamento.SelectedValue.ToString(), out IDDepartamento);

            empleadosBLL.Departamento = IDDepartamento;

            empleadosBLL.FotoEmpleado = imagenByte;
        }
    }
}
