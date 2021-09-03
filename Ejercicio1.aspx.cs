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
            string bdViajes = "Data Source=localhost\\sqlexpress;Initial Catalog=Neptuno;Integrated Security=True";
            string consultaSql = "select * from Provincias";

            if (!IsPostBack)
            {
                DataSet ds = new DataSet();
                SqlConnection cn = new SqlConnection(bdViajes);
                cn.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter(consultaSql,bdViajes);
                adaptador.Fill(ds,"Provincias");

                foreach(DataRow dr in ds.Tables["Provincias"].Rows)
                {
                    ddlProvinicio.Items.Add(dr["IdProvincia"] + " " + dr["NombreProvincia"]);
                }
                cn.Close();
            }
        }
    }
}