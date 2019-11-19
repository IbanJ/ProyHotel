using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace ProyHotel
{
    public partial class altaReserva : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source = SEGUNDO150; Initial Catalog = AVAN_iban; Integrated Security = True");
        SqlCommand insertFecha = new SqlCommand();
        SqlParameter prmSalida = new SqlParameter();
        protected void Page_Load(object sender, EventArgs e)
        {

            insertFecha.CommandType = CommandType.StoredProcedure;
            insertFecha.CommandText = "HOTEL.numHabitaciones";
            insertFecha.Connection = conn;

            insertFecha.Parameters.AddWithValue("@p_fechaEntrada", Session["fechaEntrada"]);
            insertFecha.Parameters.AddWithValue("@p_fechaSalida", Session["fechaSalida"]);
            insertFecha.Parameters.AddWithValue("@p_tipoHabitacion",DropDownList1.SelectedValue);

            prmSalida.ParameterName = "@p_salida";
            prmSalida.SqlDbType = SqlDbType.Int;
            prmSalida.Direction = ParameterDirection.Output;
            insertFecha.Parameters.Add(prmSalida);

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            Session["fechaEntrada"] = Calendar1.SelectedDate;
        }

       

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            Session["fechaSalida"] = Calendar1.SelectedDate;
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            conn.Open();
            insertFecha.ExecuteNonQuery();
           // int salida = insertFecha.Parameters["@p_salida"].;
            conn.Close();
            lblHabitaciones.Visible = true;
            lblHabitaciones.Text = "Habitaciones disp:" + prmSalida.Value.ToString();
 
        }
    }
}