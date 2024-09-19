using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using AdminEmpleados.BLL;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace AdminEmpleados.DAL
{
    internal class DepartamentosDAL
    {
        ConexionDAL conexion;
        public bool runSQuery;

        public DepartamentosDAL()
        {
            conexion = new ConexionDAL();
        }

        public bool Agregar( DepartamentoBLL odepartamentoBLL)
        {


            SqlCommand sqlCommand = new SqlCommand("INSERT INTO Departamentos VALUES(@Departamente)");

            sqlCommand.Parameters.Add("@Departamente", SqlDbType.VarChar).Value = odepartamentoBLL.Departamento;

            runSQuery = conexion.ejecutarComandoSinRetornoDatos(sqlCommand);
            
            if (runSQuery)
            {
                MessageBox.Show("Inserccion correcta");
            }
            else
            {
                MessageBox.Show("Inserccion incorrecta");
            }
            return runSQuery;

        }

        public bool Eliminar(DepartamentoBLL odepartamentoBLL)
        {

            SqlCommand sqlCommand = new SqlCommand("DELETE FROM Departamentos WHERE ID(@ID)");

            sqlCommand.Parameters.Add("@ID", SqlDbType.Int).Value = odepartamentoBLL.ID.ToString();


            runSQuery = conexion.ejecutarComandoSinRetornoDatos("DELETE FROM Departamentos WHERE ID="+odepartamentoBLL.ID);

            if (runSQuery)
            {
                MessageBox.Show("Eliminación correcta");
            }
            else
            {
                MessageBox.Show("Eliminación incorrecta");
            }
            return runSQuery;

        }

        public bool Modificar(DepartamentoBLL odepartamentoBLL)
        {
            SqlCommand sqlCommand = new SqlCommand("UPDATE Departamentos SET departamento = (@Departamente) WHERE ID=(@ID)");

            sqlCommand.Parameters.Add("@Departamente", SqlDbType.VarChar).Value = odepartamentoBLL.Departamento;
            sqlCommand.Parameters.Add("@ID", SqlDbType.Int).Value = odepartamentoBLL.ID.ToString();

            runSQuery = conexion.ejecutarComandoSinRetornoDatos(sqlCommand);

            if (runSQuery)
            {
                MessageBox.Show("Modificación correcta");
            }
            else
            {
                MessageBox.Show("Modificación incorrecta");
            }
            return runSQuery;

        }

        public DataSet mostrarDepartamentos()
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM Departamentos");

            return conexion.EjecutarSentencia(sentencia);
        }

    }
}
