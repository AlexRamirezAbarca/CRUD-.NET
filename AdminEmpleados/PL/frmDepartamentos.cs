using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdminEmpleados.BLL;
using AdminEmpleados.DAL;

namespace AdminEmpleados.PL
{
    public partial class frmDepartamentos : Form
    {

        DepartamentosDAL departamentosDAL;

        public frmDepartamentos()
        {
            departamentosDAL = new DepartamentosDAL();
            InitializeComponent();
            llenarGrid();
            limpiarEntradas();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            departamentosDAL.Agregar(RecuperarInformacion());
            llenarGrid();
            limpiarEntradas();
        }

        private DepartamentoBLL RecuperarInformacion()
        {
            DepartamentoBLL oDepartamentoBll = new DepartamentoBLL();

            int ID = 0; int.TryParse(txtID.Text, out ID);

            oDepartamentoBll.ID = ID;

            oDepartamentoBll.Departamento = txtDepartamento.Text;

            return oDepartamentoBll;
        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.RowIndex;

            dgvDepartamentos.ClearSelection();

            if(index >= 0)
            {
                txtID.Text = dgvDepartamentos.Rows[index].Cells[0].Value.ToString();
                txtDepartamento.Text = dgvDepartamentos.Rows[index].Cells[1].Value.ToString();

                habilitarOpciones();
            }
            
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            departamentosDAL.Eliminar(RecuperarInformacion());
            llenarGrid();
            limpiarEntradas();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            departamentosDAL.Modificar(RecuperarInformacion());
            llenarGrid();
            limpiarEntradas();
        }

        public void llenarGrid()
        {
            dgvDepartamentos.DataSource = departamentosDAL.mostrarDepartamentos().Tables[0];
            dgvDepartamentos.Columns[0].HeaderText = "ID";
            dgvDepartamentos.Columns[0].HeaderText = "Nombre Departamento";
        }

        public void limpiarEntradas()
        {
            txtID.Text = "";
            txtDepartamento.Text = "";
            btnAgregar.Enabled = true;
            btnBorrar.Enabled = false;
            btnModificar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        public void habilitarOpciones()
        {
            btnAgregar.Enabled = false;
            btnBorrar.Enabled = true;
            btnModificar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarEntradas();
        }
    }
}
