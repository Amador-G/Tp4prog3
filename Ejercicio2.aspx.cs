using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel.DataAnnotations;

namespace TP4_PROG3
{
    public partial class Ejercicio2 : System.Web.UI.Page
    {
        public void consultaTabla(string consulta)
        {
            string rutaBd = "Data Source=LocalHost\\SQLEXPRESS;Initial Catalog=Neptuno;Integrated Security=True";

            DataSet ds = new DataSet();
            SqlConnection cn = new SqlConnection(rutaBd);
            cn.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, cn);

            adaptador.Fill(ds, "Productos");
            grdProductos.DataSource = ds.Tables["Productos"];
            grdProductos.DataBind();
            cn.Close();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            consultaTabla("select * from Productos ");
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (txtProducto.Text == "" && txtCategoria.Text == "")
            {


                consultaTabla("select * from Productos ");
            }
            if(txtProducto.Text != "" && txtCategoria.Text!="")
            {
                if (ddlProducto.SelectedIndex == 0 && ddlCategoria.SelectedIndex == 0)
                {

                    string idProducto = txtProducto.Text;
                    string idCategoria = txtCategoria.Text;
                    consultaTabla( "select * from Productos where IdProducto =" + idProducto + "and IdCategoría =" + idCategoria);


                    

                }
                if (ddlProducto.SelectedIndex == 1 && ddlCategoria.SelectedIndex == 0)
                {
                    
                    string idProducto = txtProducto.Text;
                    string idCategoria = txtCategoria.Text;
                    consultaTabla( "select * from Productos where IdProducto >" + idProducto + "and IdCategoría =" + idCategoria);


                    

                }
                if (ddlProducto.SelectedIndex == 0 && ddlCategoria.SelectedIndex == 1)
                {
                   
                    string idProducto = txtProducto.Text;
                    string idCategoria = txtCategoria.Text;
                    consultaTabla( "select * from Productos where IdProducto =" + idProducto + "and IdCategoría >" + idCategoria);


                    

                }
                if (ddlProducto.SelectedIndex == 1 && ddlCategoria.SelectedIndex == 1)
                {
                    
                    string idProducto = txtProducto.Text;
                    string idCategoria = txtCategoria.Text;
                    consultaTabla( "select * from Productos where IdProducto >" + idProducto + "and IdCategoría >" + idCategoria);


                    

                }
                if (ddlProducto.SelectedIndex == 2 && ddlCategoria.SelectedIndex == 1)
                {
                   
                    string idProducto = txtProducto.Text;
                    string idCategoria = txtCategoria.Text;
                    consultaTabla( "select * from Productos where IdProducto <" + idProducto + "and IdCategoría >" + idCategoria);


                    

                }
                if (ddlProducto.SelectedIndex == 1 && ddlCategoria.SelectedIndex == 2)
                {
                   
                    string idProducto = txtProducto.Text;
                    string idCategoria = txtCategoria.Text;
                    consultaTabla( "select * from Productos where IdProducto >" + idProducto + "and IdCategoría <" + idCategoria);


                   

                }
                if (ddlProducto.SelectedIndex == 2 && ddlCategoria.SelectedIndex == 2)
                {
              
                    string idProducto = txtProducto.Text;
                    string idCategoria = txtCategoria.Text;
                    consultaTabla( "select * from Productos where IdProducto <" + idProducto + "and IdCategoría <" + idCategoria);


                  

                }
            }

            if (txtProducto.Text != "" && txtCategoria.Text == "")
            {
                if (ddlProducto.SelectedIndex == 0)
                {
                    
                    string idProducto = txtProducto.Text;
                    consultaTabla( "select * from Productos where IdProducto =" + idProducto);


                    
                }
                if (ddlProducto.SelectedIndex == 1)
                {
                    
                    string idProducto = txtProducto.Text;
                    consultaTabla( "select * from Productos where IdProducto >" + idProducto);


                    
                }
                if (ddlProducto.SelectedIndex == 2)
                {
                    
                    string idProducto = txtProducto.Text;
                    consultaTabla( "select * from Productos where IdProducto <" + idProducto);


                    
                }


            }
            if (txtCategoria.Text != "" && txtProducto.Text=="")
            {
                if (ddlCategoria.SelectedIndex == 0)
                {
                    
                    string idCategoria = txtCategoria.Text;
                    consultaTabla("select * from Productos where IdCategoría =" + idCategoria);
                    
                }
                if (ddlCategoria.SelectedIndex == 1)
                {
                   
                    string idCategoria = txtCategoria.Text;
                    consultaTabla( "select * from Productos where IdCategoría >" + idCategoria);

                }
                if (ddlCategoria.SelectedIndex == 2)
                {
                    
                    string idCategoria = txtCategoria.Text;
                    consultaTabla( "select * from Productos where IdCategoría <" + idCategoria);
                }
            }
            
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            txtProducto.Text = "";
            txtCategoria.Text = "";
            

            consultaTabla( "select * from Productos ");
        }
    }
}
