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
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

       public DataSet Consulta(string consulta)
        {
            string rutabd = "Data Source=localhost\\sqlexpress;Initial Catalog=Neptuno;Integrated Security=True";
            SqlConnection cn = new SqlConnection(rutabd);
            cn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(consulta, cn);
            da.Fill(ds);
            cn.Close();
            return ds;

        }
        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            bool aux = false;
            
            if (txtProducto.Text.Length != 0 && txtProducto.Text.Length != 0)
            {
                if (int.Parse(ddlProducto.SelectedValue) == 0 && int.Parse(ddlCategoria.SelectedValue) == 0)
                {
                    grdProductos.DataSource = Consulta("select * from Productos where IdProducto =" + int.Parse(txtProducto.Text) + "and IdCategoría = " + int.Parse(txtCategoria.Text) + "order by IdCategoría");
                    grdProductos.DataBind();
                }
                if (int.Parse(ddlProducto.SelectedValue) == 0 && int.Parse(ddlCategoria.SelectedValue) == 1)
                {
                    grdProductos.DataSource = Consulta("select * from Productos where IdProducto =" + int.Parse(txtProducto.Text) + "and IdCategoría > " + int.Parse(txtCategoria.Text) + "order by IdCategoría");
                    grdProductos.DataBind();
                }
                if (int.Parse(ddlProducto.SelectedValue) == 0 && int.Parse(ddlCategoria.SelectedValue) == 2)
                {
                    grdProductos.DataSource = Consulta("select * from Productos where IdProducto =" + int.Parse(txtProducto.Text) + "and IdCategoría < " + int.Parse(txtCategoria.Text) + "order by IdCategoría");
                    grdProductos.DataBind();
                }

                if (int.Parse(ddlProducto.SelectedValue) == 1 && int.Parse(ddlCategoria.SelectedValue) == 0)
                {
                    grdProductos.DataSource = Consulta("select * from Productos where IdProducto > " + int.Parse(txtProducto.Text) + "and IdCategoría = " + int.Parse(txtCategoria.Text) + "order by IdCategoría");
                    grdProductos.DataBind();
                }
                if (int.Parse(ddlProducto.SelectedValue) == 1 && int.Parse(ddlCategoria.SelectedValue) == 1)
                {
                    grdProductos.DataSource = Consulta("select * from Productos where IdProducto > " + int.Parse(txtProducto.Text) + "and IdCategoría >" + int.Parse(txtCategoria.Text) + "order by IdCategoría");
                    grdProductos.DataBind();
                }
                if (int.Parse(ddlProducto.SelectedValue) == 1 && int.Parse(ddlCategoria.SelectedValue) == 2)
                {
                    grdProductos.DataSource = Consulta("select * from Productos where IdProducto >" + int.Parse(txtProducto.Text) + "and IdCategoría < " + int.Parse(txtCategoria.Text) + "order by IdCategoría");
                    grdProductos.DataBind();
                }

                if (int.Parse(ddlProducto.SelectedValue) == 2 && int.Parse(ddlCategoria.SelectedValue) == 0)
                {
                    grdProductos.DataSource = Consulta("select * from Productos where IdProducto <" + int.Parse(txtProducto.Text) + "and IdCategoría = " + int.Parse(txtCategoria.Text) + "order by IdCategoría");
                    grdProductos.DataBind();
                }
                if (int.Parse(ddlProducto.SelectedValue) == 2 && int.Parse(ddlCategoria.SelectedValue) == 1)
                {
                    grdProductos.DataSource = Consulta("select * from Productos where IdProducto <" + int.Parse(txtProducto.Text) + "and IdCategoría > " + int.Parse(txtCategoria.Text) + "order by IdCategoría");
                    grdProductos.DataBind();
                }
                if (int.Parse(ddlProducto.SelectedValue) == 2 && int.Parse(ddlCategoria.SelectedValue) == 2)
                {
                    grdProductos.DataSource = Consulta("select * from Productos where IdProducto <" + int.Parse(txtProducto.Text) + "and IdCategoría < " + int.Parse(txtCategoria.Text) + "order by IdCategoría");
                    grdProductos.DataBind();
                }

                aux = true;
            }
            if(txtProducto.Text.Length != 0)
            {
                if(int.Parse(ddlProducto.SelectedValue) == 0 && aux == false)
                {
                    grdProductos.DataSource = Consulta("select * from Productos where IdProducto = " + int.Parse(txtProducto.Text));
                    grdProductos.DataBind();
                }
                if (int.Parse(ddlProducto.SelectedValue) == 1 && aux == false)
                {
                    grdProductos.DataSource = Consulta("select * from Productos where IdProducto > " + int.Parse(txtProducto.Text));
                    grdProductos.DataBind();
                }
                if (int.Parse(ddlProducto.SelectedValue) == 2 && aux == false)
                {
                    grdProductos.DataSource = Consulta("select * from Productos where IdProducto < " + int.Parse(txtProducto.Text));
                    grdProductos.DataBind();
                }
                txtProducto.Text = "";
            }
            if(txtCategoria.Text.Length != 0)
            {
                if(int.Parse(ddlCategoria.SelectedValue) == 0 && aux == false)
                {
                    grdProductos.DataSource = Consulta("select * from Productos where IdCategoría = " + int.Parse(txtCategoria.Text) + "order by IdCategoría");
                    grdProductos.DataBind();
                }
                if (int.Parse(ddlCategoria.SelectedValue) == 1 && aux == false)
                {
                    grdProductos.DataSource = Consulta("select * from Productos where IdCategoría > " + int.Parse(txtCategoria.Text) + "order by IdCategoría");
                    grdProductos.DataBind();
                }
                if (int.Parse(ddlCategoria.SelectedValue) == 2 && aux == false)
                {
                    grdProductos.DataSource = Consulta("select * from Productos where IdCategoría < " + int.Parse(txtCategoria.Text) + "order by IdCategoría");
                    grdProductos.DataBind();
                }
                txtCategoria.Text = "";
            }
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=Neptuno;Integrated Security=True");
            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from Productos", cn);
            SqlDataReader dr = cmd.ExecuteReader();

            grdProductos.DataSource = dr;
            grdProductos.DataBind();
        }
    }
}
