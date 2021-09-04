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
    public partial class Ejercicio2b : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string TemaElegido;
            TemaElegido = Request.QueryString["IdTema"];
            string rutaBd = "Data Source=laptop-d5dkhvl7\\sqlexpress01;Initial Catalog=Libreria;Integrated Security=True";
            string consultaBd = "select * from Libros where Libros.IdTema =" + TemaElegido;


            if (!IsPostBack)
            {
                SqlConnection cn = new SqlConnection(rutaBd);
                SqlCommand cmd = new SqlCommand(consultaBd, cn);

                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                gvLibro.DataSource = dr;
                gvLibro.DataBind();
                cn.Close();
            }
        }

        protected void btnOtroTema_Click(object sender, EventArgs e)
        {
            Server.Transfer("Ejercicio3a.aspx");
        }
    }
}