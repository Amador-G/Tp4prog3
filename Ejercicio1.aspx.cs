using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace TP4_PROG3
{
    public partial class Ejercicio1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection cn = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=Viajes;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("select NombreProvincia,IdProvincia from Provincias", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                ddlProvinicio.Items.Add("-- Seleccione Provincia --");

                ddlProvinicio.DataSource = dr;

                ddlProvinicio.DataTextField = "NombreProvincia";
                ddlProvinicio.DataValueField = "IdProvincia";

                ddlProvinicio.DataBind();

           
                cn.Close();
                
            }

            else
            {
                string idProvincia;
                idProvincia = ddlProvinicio.SelectedValue;
               // lblTest.Text = "hgoasdasdasdla";

                SqlConnection cn2 = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=Viajes;Integrated Security=True");
                cn2.Open();

                //SqlCommand cmd = new SqlCommand("select * from Provincias inner join Localidades on Provincias.IdProvincia = Localidades.IdProvincia where Localidades.IdProvincia = " + idProvincia, cn);
                SqlCommand cmd2 = new SqlCommand("select NombreLocalidad,IdProvincia from Localidades where Localidades.IdProvincia = " + idProvincia, cn2);

                SqlDataReader dr2 = cmd2.ExecuteReader();

                ddlLocinicio.DataSource = dr2;

                ddlLocinicio.DataTextField = "NombreLocalidad";
                ddlLocinicio.DataValueField = "IdProvincia";

                ddlLocinicio.DataBind();

                cn2.Close();
            }
           
            
            
        }
    }
}