using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AddReservationForm : Form
    {
        private string connectionString;

        public AddReservationForm(string connectionString)
        {
            this.connectionString = connectionString;
            InitializeComponent(); // вызывает метод из Designer.cs
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Reservations (BookID, BorrowerID, ReservationDate, Status) VALUES (@BookID, @BorrowerID, @ReservationDate, @Status)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BookID", txtBookID.Text);
                command.Parameters.AddWithValue("@BorrowerID", txtBorrowerID.Text);
                command.Parameters.AddWithValue("@ReservationDate", DateTime.Now);
                command.Parameters.AddWithValue("@Status", cmbStatus.SelectedItem.ToString());

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Reservation added successfully!");
                this.Close();
            }
        }
    }
}
