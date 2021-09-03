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
            string bdViajes = "Data Source=localhost\\sqlexpress;Initial Catalog=Viajes;Integrated Security=True";
            string consultaSql = "select * from Provincias";

            if (!IsPostBack)
            {
                DataSet ds = new DataSet();
                SqlConnection cn = new SqlConnection(bdViajes);
                cn.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter(consultaSql,bdViajes);
                adaptador.Fill(ds,"Provincias");

                ListItemCollection Coleccion = new ListItemCollection();

                Coleccion.Add(new ListItem("-- Seleccione Provincia --"));

                foreach(DataRow dr in ds.Tables["Provincias"].Rows)
                {
                    Coleccion.Add(new ListItem(dr["IdProvincia"] + " " + dr["NombreProvincia"], dr["IdProvincia"].ToString()) );
                }
                ddlProvinicio.DataSource = Coleccion;
                ddlProvinicio.DataBind();
                cn.Close();
                
                
            }
        }

        protected void ddlLocinicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void ddlProvinicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idProvincia;
            idProvincia = ddlProvinicio.SelectedValue;
            SqlConnection cn = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=Viajes;Integrated Security=True");
            cn.Open();

            string ConsultaLocInicio = "select NombreLocalidad from Provincias inner join Localidades on Provincias.IdProvincia = Localidades.IdProvincia where Localidades.IdProvincia = '";
            ConsultaLocInicio += idProvincia + "'";
            lblTest.Text = "Usted seleccionó el ID " + idProvincia;

            SqlCommand cmd = new SqlCommand(ConsultaLocInicio, cn);

            SqlDataReader dr = cmd.ExecuteReader();

            ddlLocinicio.DataSource = dr;

            ddlLocinicio.DataTextField = "NombreLocalidad";
            ddlLocinicio.DataValueField = "IdProvincia";
            
            ddlLocinicio.DataBind();



            cn.Close();
        }
    }
}