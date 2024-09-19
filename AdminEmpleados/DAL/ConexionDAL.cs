using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Drawing.Text;
using System.Windows.Forms;


namespace AdminEmpleados.DAL
{
    internal class ConexionDAL
    {

        private string cadenaConexion = "Data Source=ALEX\\SQLEXPRESS; Initial Catalog=dbSistema; Integrated Security = True";

        SqlConnection conexion;

        public SqlConnection EstablecerConexion()
        {
             this.conexion = new SqlConnection(this.cadenaConexion);
            return this.conexion;
        }

        /*Método INSERT, DELETE, UPDATE*/
        public bool ejecutarComandoSinRetornoDatos(string strComando)
        {
            
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = strComando;
                cmd.Connection = this.EstablecerConexion(); ;
                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }

        public bool ejecutarComandoSinRetornoDatos(SqlCommand comando)
        {
            try
            { 
                SqlCommand cmd = comando;
                cmd.Connection = this.EstablecerConexion(); ;
                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }



        /*SELECT (Retorno de datos)*/
        public DataSet EjecutarSentencia(SqlCommand sqlCommand)
        {
            DataSet DS = new DataSet();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            try
            {
                SqlCommand comando = new SqlCommand();
                comando = sqlCommand;
                comando.Connection = EstablecerConexion();
                sqlDataAdapter.SelectCommand = comando;
                conexion.Open();
                sqlDataAdapter.Fill(DS);
                conexion.Close() ;
                return DS;  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return DS;
            }
                  
            

        }
    }
}
