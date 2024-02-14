using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CinemaEx
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonPrenota_Click(object sender, EventArgs e) // metodo che viene eseguito quando si clicca sul pulsante "Prenota" 
        {
            string nome = TextBoxNome.Text; // prende il valore inserito nel campo "Nome"
            string cognome = TextBoxCognome.Text; // prende il valore inserito nel campo "Cognome"
            string NomeSala =DropDownListSala.SelectedItem.Text; // prende il valore selezionato nel campo "Sala"
            string tipoBiglietto = CheckBoxRidotto.Checked ? "Ridotto" : "Intero"; // se il checkbox è selezionato, il tipo del biglietto è "Ridotto", altrimenti è "Intero"

            // Query per inserire i dati della prenotazione nel database e aggiornare il numero di biglietti venduti per la sala selezionata 
            string query = "INSERT INTO Prenotazioni (Nome, Cognome, NomeSala, TipoBiglietto) VALUES (@Nome, @Cognome, @NomeSala, @TipoBiglietto); " +
                               "UPDATE Prenotazioni SET BigliettiVenduti = BigliettiVenduti + 1 WHERE NomeSala = @NomeSala;";

            string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString.ToString(); // stringa di connessione al database 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@Cognome", cognome);
                    command.Parameters.AddWithValue("@NomeSala", NomeSala);
                    command.Parameters.AddWithValue("@TipoBiglietto", tipoBiglietto);
                    connection.Open(); // apre la connessione al database
                    command.ExecuteNonQuery(); // esegue la query  
                }
            }

            // Display confirmation message
            Response.Write("<script>alert('Prenotazione effettuata con successo!')</script>");
        }
    }
}