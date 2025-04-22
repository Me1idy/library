
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AddReservationForm : Form
    {
        private readonly string connectionString;

        public AddReservationForm(string connectionString)
        {
            this.connectionString = connectionString;
            InitializeComponent();
            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            try
            {
                cmbStatus.Items.AddRange(new[] { "Зарезервирована", "Занята", "Отменена" });
                cmbStatus.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при инициализации ComboBox: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBookID.Text) || string.IsNullOrWhiteSpace(txtBorrowerID.Text) || cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Reservations (BookID, BorrowerID, ReservationDate, Status) VALUES (@BookID, @BorrowerID, @ReservationDate, @Status)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BookID", int.Parse(txtBookID.Text));
                        command.Parameters.AddWithValue("@BorrowerID", int.Parse(txtBorrowerID.Text));
                        command.Parameters.AddWithValue("@ReservationDate", DateTime.Now);
                        command.Parameters.AddWithValue("@Status", cmbStatus.SelectedItem.ToString());

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Резервация успешно добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("ID книги и пользователя должны быть числами!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Ошибка базы данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении резервации: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
