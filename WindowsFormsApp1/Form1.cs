using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=DESKTOP-F0PU6HS\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True;";

        public Form1()
        {
            InitializeComponent();
            InitializeStatusFilter();
        }

        private void InitializeStatusFilter()
        {
            comboBoxStatusFilter.Items.Add("Все");
            comboBoxStatusFilter.Items.Add("Зарезервирована");
            comboBoxStatusFilter.Items.Add("Занята");
            comboBoxStatusFilter.Items.Add("Отменена");
            comboBoxStatusFilter.SelectedIndex = 0; // По умолчанию "Все"
            comboBoxStatusFilter.SelectedIndexChanged += ComboBoxStatusFilter_SelectedIndexChanged;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadBooks();
            LoadUsers();
            LoadReservations();
        }

        private void LoadBooks()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT BookID, Title, GenreID, PublicationYear FROM Books";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable books = new DataTable();
                adapter.Fill(books);
                dataGridViewResults.DataSource = books;
            }
        }

        private void LoadUsers()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT BorrowerID, FirstName, LastName, Email, Phone FROM Borrowers";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable borrowers = new DataTable();
                adapter.Fill(borrowers);
                dataGridViewUsers.DataSource = borrowers;
            }
        }

        private void LoadReservations()
        {
            string selectedStatus = comboBoxStatusFilter.SelectedItem?.ToString() ?? "Все";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT r.ReservationID, r.ReservationDate, r.Status,
                           b.FirstName + ' ' + b.LastName AS BorrowerName, 
                           bk.Title AS BookTitle
                    FROM Reservations r
                    JOIN Borrowers b ON r.BorrowerID = b.BorrowerID
                    JOIN Books bk ON r.BookID = bk.BookID";

                if (selectedStatus != "Все")
                    query += " WHERE r.Status = @Status";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (selectedStatus != "Все")
                        command.Parameters.AddWithValue("@Status", selectedStatus);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable reservations = new DataTable();
                    adapter.Fill(reservations);
                    dataGridViewReservations.DataSource = reservations;
                }

                dataGridViewReservations.Columns["ReservationID"].HeaderText = "ID резервации";
                dataGridViewReservations.Columns["ReservationDate"].HeaderText = "Дата резервации";
                dataGridViewReservations.Columns["Status"].HeaderText = "Статус";
                dataGridViewReservations.Columns["BorrowerName"].HeaderText = "Пользователь";
                dataGridViewReservations.Columns["BookTitle"].HeaderText = "Книга";
                dataGridViewReservations.Columns["ReservationDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
                dataGridViewReservations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                foreach (DataGridViewRow row in dataGridViewReservations.Rows)
                {
                    string status = row.Cells["Status"].Value?.ToString() ?? "";
                    if (status == "Занята")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                    else if (status == "Зарезервирована")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightYellow;
                    }
                    else if (status == "Отменена")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGray;
                    }
                    else if (string.IsNullOrEmpty(status))
                    {
                        row.DefaultCellStyle.BackColor = Color.LightPink;
                    }
                }
            }
        }

        private void ComboBoxStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadReservations();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchBookForm searchForm = new SearchBookForm(connectionString);
            searchForm.ShowDialog();
        }

        private void btnAddReservation_Click(object sender, EventArgs e)
        {
            AddReservationForm addReservationForm = new AddReservationForm(connectionString);
            addReservationForm.FormClosed += (s, args) => LoadReservations();
            addReservationForm.ShowDialog();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AddUserForm addUserForm = new AddUserForm(connectionString);
            addUserForm.FormClosed += (s, args) => LoadUsers();
            addUserForm.ShowDialog();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.CurrentRow == null)
            {
                MessageBox.Show("Выберите пользователя для удаления!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int borrowerId = Convert.ToInt32(dataGridViewUsers.CurrentRow.Cells["BorrowerID"].Value);
            string userName = dataGridViewUsers.CurrentRow.Cells["FirstName"].Value.ToString() + " " +
                              dataGridViewUsers.CurrentRow.Cells["LastName"].Value.ToString();

            DialogResult result = MessageBox.Show($"Вы уверены, что хотите удалить пользователя {userName}?",
                "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Borrowers WHERE BorrowerID = @BorrowerID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BorrowerID", borrowerId);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Пользователь успешно удалён!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении пользователя: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelReservation_Click(object sender, EventArgs e)
        {
            if (dataGridViewReservations.CurrentRow == null)
            {
                MessageBox.Show("Выберите резервацию для отмены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int reservationId = Convert.ToInt32(dataGridViewReservations.CurrentRow.Cells["ReservationID"].Value);
            string bookTitle = dataGridViewReservations.CurrentRow.Cells["BookTitle"].Value.ToString();
            string currentStatus = dataGridViewReservations.CurrentRow.Cells["Status"].Value?.ToString() ?? "";

            if (currentStatus == "Отменена")
            {
                MessageBox.Show("Эта резервация уже отменена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (string.IsNullOrEmpty(currentStatus))
            {
                MessageBox.Show("Статус резервации не указан!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show($"Вы уверены, что хотите отменить резервацию книги '{bookTitle}'?",
                "Подтверждение отмены", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Reservations SET Status = 'Отменена' WHERE ReservationID = @ReservationID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ReservationID", reservationId);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Резервация успешно отменена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadReservations();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отмене резервации: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            if (dataGridViewReservations.CurrentRow == null)
            {
                MessageBox.Show("Выберите резервацию для выдачи!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int reservationId = Convert.ToInt32(dataGridViewReservations.CurrentRow.Cells["ReservationID"].Value);
            string bookTitle = dataGridViewReservations.CurrentRow.Cells["BookTitle"].Value.ToString();
            string currentStatus = dataGridViewReservations.CurrentRow.Cells["Status"].Value?.ToString() ?? "";

            if (currentStatus == "Занята")
            {
                MessageBox.Show("Эта книга уже выдана!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (currentStatus == "Отменена")
            {
                MessageBox.Show("Эта резервация отменена и не может быть выдана!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrEmpty(currentStatus))
            {
                MessageBox.Show("Статус резервации не указан!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show($"Выдать книгу '{bookTitle}' пользователю?",
                "Подтверждение выдачи", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Reservations SET Status = 'Занята' WHERE ReservationID = @ReservationID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ReservationID", reservationId);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Книга успешно выдана!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadReservations();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при выдаче книги: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxStatusFilter_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}