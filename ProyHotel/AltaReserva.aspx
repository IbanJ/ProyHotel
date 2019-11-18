<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaReserva.aspx.cs" Inherits="ProyectoHotelFechas.AltaReserva" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Fecha de Entrada"></asp:Label>
            <asp:Label ID="Label2" runat="server" Text="FechaDeSalida"></asp:Label>
            <asp:Label ID="Label3" runat="server" Text="Tipo de Habitacion"></asp:Label>
            <asp:Label ID="Label4" runat="server" Text="NumeroDeHabitaciones"></asp:Label>
        </div>
        <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
        <asp:Calendar ID="Calendar2" runat="server"></asp:Calendar>
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlHabitacion" DataTextField="descripcion" DataValueField="Categoria" AutoPostBack="True">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlHabitacion" runat="server" ConnectionString="<%$ ConnectionStrings:AVAN_ibanConnectionString %>" SelectCommand="SELECT [Categoria], [descripcion] FROM hotel.[tipoHabitacion]"></asp:SqlDataSource>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Label ID="Label5" runat="server" Visible="False">Habitaciones disp: </asp:Label>
        <asp:Label ID="Label6" runat="server" Text="Camas" Visible="False"></asp:Label>
        <asp:Button ID="Button1" runat="server" Text="Button" />
    </form>
</body>
</html>
