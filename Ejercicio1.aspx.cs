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
                

                ddlProvinicio.DataSource = dr;

                ddlProvinicio.DataTextField = "NombreProvincia";
                ddlProvinicio.DataValueField = "IdProvincia";

                ddlProvinicio.DataBind();
                ddlProvinicio.Items.Insert(0, "-- Seleccione Provincia --");
                



                cn.Close();
                
            }

            else
            {
                string idProvincia;
                idProvincia = ddlProvinicio.SelectedValue;
                // lblTest.Text = "hgoasdasdasdla";

                if (ddlProvinicio.SelectedIndex != 0)
                {
                    SqlConnection cn2 = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=Viajes;Integrated Security=True");
                    cn2.Open();
                    SqlCommand cmd2 = new SqlCommand("select NombreLocalidad,IdProvincia from Localidades where Localidades.IdProvincia = " + idProvincia, cn2);

                    SqlDataReader dr2 = cmd2.ExecuteReader();

                    ddlLocinicio.DataSource = dr2;

                    ddlLocinicio.DataTextField = "NombreLocalidad";
                    ddlLocinicio.DataValueField = "IdProvincia";

                    ddlLocinicio.DataBind();

                    ddlLocinicio.Items.Insert(0, "-- Seleccione Localidad --");
                    cn2.Close();

                }
                else
                {
                    ddlLocinicio.Items.Clear();
                    ddlProvDestino.Items.Clear();
                    ddlLocDestino.Items.Clear();
                }
               
            }
           
            
            
        }
    }
}