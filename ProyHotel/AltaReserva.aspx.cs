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
        SqlCommand selectHabDisp = new SqlCommand();
        SqlCommand insertReserva = new SqlCommand();
        SqlParameter prmSalida = new SqlParameter();
        protected void Page_Load(object sender, EventArgs e)
        {

            selectHabDisp.CommandType = CommandType.StoredProcedure;
            selectHabDisp.CommandText = "HOTEL.numHabitaciones";
            selectHabDisp.Connection = conn;

            selectHabDisp.Parameters.AddWithValue("@p_fechaEntrada", Session["fechaEntrada"]);
            selectHabDisp.Parameters.AddWithValue("@p_fechaSalida", Session["fechaSalida"]);
            selectHabDisp.Parameters.AddWithValue("@p_tipoHabitacion",DropDownList1.SelectedValue);

            prmSalida.ParameterName = "@p_salida";
            prmSalida.SqlDbType = SqlDbType.Int;
            prmSalida.Direction = ParameterDirection.Output;
            selectHabDisp.Parameters.Add(prmSalida);

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
            selectHabDisp.ExecuteNonQuery();
           // int salida = selectHabDisp.Parameters["@p_salida"].;
            conn.Close();
            lblHabitaciones.Visible = true;
            lblHabitaciones.Text = "Habitaciones disp:" + int.Parse(prmSalida.Value.ToString());
 
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}