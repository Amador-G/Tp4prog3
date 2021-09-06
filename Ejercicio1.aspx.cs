using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace TP4_PROG3
{
    public partial class Ejercicio1bis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPorigen();
            }

        }

        private void CargarPorigen()
        {
            ddlPorigen.DataSource = Consulta("select NombreProvincia,IdProvincia from Provincias");
            ddlPorigen.DataTextField = "NombreProvincia";
            ddlPorigen.DataValueField = "IdProvincia";
            ddlPorigen.DataBind();
            ddlPorigen.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
            ddlPdestino.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
            ddlLorigen.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
            ddlLdestino.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        }

        private DataSet Consulta(string consultaSQL)
        {
            string dbViajes = "Data Source=LocalHost\\SQLEXPRESS;Initial Catalog=Viajes;Integrated Security=True";
            SqlConnection cn = new SqlConnection(dbViajes);
            cn.Open();
            SqlCommand cmd = new SqlCommand(consultaSQL, cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cn.Close();
            return ds;
        }

        protected void OrigenSeleccionado(object sender, EventArgs e)
        {
            int IdProvinciaO = Convert.ToInt32(ddlPorigen.SelectedValue);
            ddlLorigen.DataSource = Consulta("select NombreLocalidad, IdProvincia from Localidades where IdProvincia = " + IdProvinciaO);
            ddlLorigen.DataTextField = "NombreLocalidad";
            ddlLorigen.DataValueField = "IdProvincia";
            ddlLorigen.DataBind();
            ddlLorigen.Items.Insert(0, new ListItem("[Seleccionar]", "0"));

            ddlPdestino.DataSource = Consulta("select NombreProvincia,IdProvincia from Provincias where not IdProvincia=" + IdProvinciaO);
            ddlPdestino.DataTextField = "NombreProvincia";
            ddlPdestino.DataValueField = "IdProvincia";
            ddlPdestino.DataBind();
            ddlPdestino.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
            ddlLdestino.Items.Clear();
            ddlLdestino.Items.Insert(0, new ListItem("[Seleccione provincia destino]", "0"));
        }

        protected void DestinoSeleccionado(object sender, EventArgs e)
        {
            ddlLdestino.Items.Clear();
            int IdProvinciaD = Convert.ToInt32(ddlPdestino.SelectedValue);
            ddlLdestino.DataSource = Consulta("select NombreLocalidad, IdProvincia from Localidades where IdProvincia = " + IdProvinciaD);
            ddlLdestino.DataTextField = "NombreLocalidad";
            ddlLdestino.DataValueField = "IdProvincia";
            ddlLdestino.DataBind();
            ddlLdestino.Items.Insert(0, new ListItem("[Seleccionar]", "0"));

        }
    }
}