using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace TP4_PROG3
{
    public partial class Ejercicio3a : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string rutaBd = "Data Source=laptop-d5dkhvl7\\sqlexpress01;Initial Catalog=Libreria;Integrated Security=True";
            string consultaBd = "select * from Temas";

            if (!IsPostBack)
            {

                SqlConnection cn = new SqlConnection(rutaBd);
                SqlCommand cmd = new SqlCommand(consultaBd, cn);

                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                ddlLibro.DataSource = dr;
                ddlLibro.DataTextField = "Tema";
                ddlLibro.DataValueField = "IdTema";
                ddlLibro.DataBind();
                cn.Close();
            }
        }

        protected void btnLibro_Click(object sender, EventArgs e)
        {
            string temaElegido;
            temaElegido = ddlLibro.SelectedItem.Value;
            Response.Redirect("Ejercicio3b.aspx?IdTema=" + temaElegido);
        }
    }
}