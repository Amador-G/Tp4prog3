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
                CreacionDdlProvInicio();

            }

            else
            {
                string idProvincia;
                idProvincia = ddlProvinicio.SelectedValue;
                // lblTest.Text = "hgoasdasdasdla";

                if (ddlProvinicio.SelectedIndex != 0)
                {
                    CreacionDdlLocInicio(idProvincia);
                    CreacionDdlProvDestino(idProvincia);
                }
                else
                {
                    ddlLocinicio.Items.Clear();
                    ddlProvDestino.Items.Clear();
                    ddlLocDestino.Items.Clear();
                }
               
            }
           
            
            
        }

        private void CreacionDdlProvDestino(string idProvincia)
        {
            SqlConnection cn = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=Viajes;Integrated Security=True");
            cn.Open();
            String ConsultaProvDest = "select NombreProvincia,IdProvincia from Provincias WHERE IdProvincia != '" + idProvincia + "'";
            SqlCommand cmd = new SqlCommand(ConsultaProvDest, cn);

            SqlDataReader dr = cmd.ExecuteReader();
            ddlProvDestino.DataSource = dr;

            ddlProvDestino.DataTextField = "NombreProvincia";
            ddlProvDestino.DataValueField= "IdProvincia";
            ddlProvDestino.DataBind();
            ddlProvDestino.Items.Insert(0, "-- Seleccione Provincia --");

            cn.Close();

           
        }

        private void CreacionDdlLocInicio(string idProvincia)
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

        private void CreacionDdlProvInicio()
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

        protected void ddlProvDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTest.Text = "eaeaeae";
            if (ddlProvDestino.SelectedIndex != 0)
            {
                lblTest.Text = "holas";
                SqlConnection cn = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=Viajes;Integrated Security=True");
                cn.Open();
                SqlCommand cmd = new SqlCommand("select NombreLocalidad,IdProvincia from Localidades where Localidades.IdProvincia = " + ddlProvDestino.SelectedValue, cn);
                SqlDataReader dr = cmd.ExecuteReader();

                ddlLocDestino.DataSource = dr;

                ddlLocDestino.DataTextField = "NombreLocalidad";
                ddlLocDestino.DataValueField = "IdProvincia";

                ddlLocDestino.DataBind();

                ddlLocDestino.Items.Insert(0, "-- Seleccione Localidad --");
                cn.Close();


            }
            else
            {
                ddlLocDestino.Items.Clear();
            }
        }

        private void CreacionLocDest()
        {
            lblTest.Text = "asdaasdasdasdsd";
            if (ddlProvDestino.SelectedIndex != 0)
            {
                SqlConnection cn = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=Viajes;Integrated Security=True");
                cn.Open();
                SqlCommand cmd = new SqlCommand("select NombreLocalidad,IdProvincia from Localidades where Localidades.IdProvincia = " + ddlProvDestino.SelectedValue, cn);
                SqlDataReader dr = cmd.ExecuteReader();

                ddlLocDestino.DataSource = dr;

                ddlLocDestino.DataTextField = "NombreLocalidad";
                ddlLocDestino.DataValueField = "IdProvincia";

                ddlLocDestino.DataBind();

                ddlLocDestino.Items.Insert(0, "-- Seleccione Localidad --");
                cn.Close();


            }
            else
            {
                ddlLocDestino.Items.Clear();
            }

        }

    }
}