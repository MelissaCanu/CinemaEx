<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="CinemaEx.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>CINEMA FUFFA</h1>
           <div class="card">
    <div class="card-body">
        <h5 class="card-title">Prenotazione Biglietti</h5>

        <!--aggiungo dropdown per selezionare la sala--> 
        <div class="form-group"> 
            <label for="DropDownListSala">Seleziona Sala:</label>
            <asp:DropDownList ID="DropDownListSala" runat="server" CssClass="form-control" Width="200px">
                <asp:ListItem Value="1" Text="SALA NORD" />
                <asp:ListItem Value="2" Text="SALA EST" />
                <asp:ListItem Value="3" Text="SALA SUD" />
            </asp:DropDownList>
        </div>

        <!--aggiungo un campo per inserire il nome e il cognome del cliente-->

        <div class="form-group">
            <label for="TextBoxNome">Nome:</label>
            <asp:TextBox ID="TextBoxNome" runat="server" CssClass="form-control" placeholder="Nome" />
        </div>

        <div class="form-group">
            <label for="TextBoxCognome">Cognome:</label>
            <asp:TextBox ID="TextBoxCognome" runat="server" CssClass="form-control" placeholder="Cognome" />
        </div>

       
        <!--aggiungo un campo per selezionare biglietto ridotto-->
        <div class="form-group">
            <div class="form-check">
                <asp:CheckBox ID="CheckBoxRidotto" runat="server" CssClass="form-check-input" Text="Biglietto ridotto" />
            </div>
        </div>

        <!--aggiungo un bottone per prenotare i biglietti-->
        <asp:Button ID="ButtonPrenota" runat="server" CssClass="btn btn-primary" Text="Prenota" onClick="ButtonPrenota_Click"   />

        <br />

        <asp:Label ID="LabelMessaggio" runat="server" CssClass="text-success"></asp:Label>
    </div>
</div>
           

        </div>
    </form>
</body>
</html>
