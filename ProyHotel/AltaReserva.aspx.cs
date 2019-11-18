using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoHotelFechas
{
    public partial class AltaReserva : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source = SEGUNDO150; Initial Catalog = AVAN_iban; Integrated Security = True");
            SqlCommand insertDia = new SqlCommand("numHabitacion", conn);
            insertDia.CommandType = CommandType.StoredProcedure;

        }
    }
}