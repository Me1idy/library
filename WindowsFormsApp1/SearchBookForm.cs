using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class SearchBookForm : Form
    {
        private string connectionString;

        // Объявление элементов управления
        private TextBox txtTitle;
        private TextBox txtAuthor;
        private TextBox txtGenre;
        private DataGridView dataGridViewResults;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button btnSearch;

        public SearchBookForm(string connectionString)
        {
            this.connectionString = connectionString;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtGenre = new System.Windows.Forms.TextBox();
            this.dataGridViewResults = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(21, 60);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(200, 22);
            this.txtTitle.TabIndex = 0;
            this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(300, 60);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(200, 22);
            this.txtAuthor.TabIndex = 1;
            // 
            // txtGenre
            // 
            this.txtGenre.Location = new System.Drawing.Point(563, 60);
            this.txtGenre.Name = "txtGenre";
            this.txtGenre.Size = new System.Drawing.Size(200, 22);
            this.txtGenre.TabIndex = 2;
            this.txtGenre.TextChanged += new System.EventHandler(this.txtGenre_TextChanged);
            // 
            // dataGridViewResults
            // 
            this.dataGridViewResults.ColumnHeadersHeight = 29;
            this.dataGridViewResults.Location = new System.Drawing.Point(21, 215);
            this.dataGridViewResults.Name = "dataGridViewResults";
            this.dataGridViewResults.RowHeadersWidth = 51;
            this.dataGridViewResults.Size = new System.Drawing.Size(742, 300);
            this.dataGridViewResults.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.YellowGreen;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Location = new System.Drawing.Point(300, 118);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(200, 63);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Найти";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.HideSelection = false;
            this.textBox1.Location = new System.Drawing.Point(21, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 22);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "Введите книгу";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.HideSelection = false;
            this.textBox2.Location = new System.Drawing.Point(300, 12);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(200, 22);
            this.textBox2.TabIndex = 6;
            this.textBox2.Text = "Введите автора";
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.HideSelection = false;
            this.textBox3.Location = new System.Drawing.Point(563, 12);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(200, 22);
            this.textBox3.TabIndex = 7;
            this.textBox3.Text = "Введите жанр";
            // 
            // SearchBookForm
            // 
            this.ClientSize = new System.Drawing.Size(803, 575);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.txtGenre);
            this.Controls.Add(this.dataGridViewResults);
            this.Controls.Add(this.btnSearch);
            this.Name = "SearchBookForm";
            this.Text = "Search Book";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT 
                    b.Title, 
                    STRING_AGG(a.FirstName + ' ' + a.LastName, ', ') AS Authors, 
                    g.GenreName AS Genre, 
                    b.PublicationYear, 
                    CASE 
                        WHEN r.Status = 'Active' THEN 'Yes' 
                        ELSE 'No' 
                    END AS IsReserved
                FROM Books b
                LEFT JOIN BookAuthors ba ON b.BookID = ba.BookID
                LEFT JOIN Authors a ON ba.AuthorID = a.AuthorID
                LEFT JOIN Genres g ON b.GenreID = g.GenreID
                LEFT JOIN Reservations r ON b.BookID = r.BookID AND r.Status = 'Active'
                WHERE 
                    (b.Title LIKE @Title OR @Title IS NULL) AND 
                    (g.GenreName LIKE @Genre OR @Genre IS NULL) AND
                    ((a.FirstName + ' ' + a.LastName LIKE @Author) OR @Author IS NULL)
                GROUP BY 
                    b.Title, g.GenreName, b.PublicationYear, r.Status";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Title", string.IsNullOrEmpty(txtTitle.Text) || txtTitle.Text == "Title" ? (object)DBNull.Value : $"%{txtTitle.Text}%");
                command.Parameters.AddWithValue("@Genre", string.IsNullOrEmpty(txtGenre.Text) || txtGenre.Text == "Genre" ? (object)DBNull.Value : $"%{txtGenre.Text}%");
                command.Parameters.AddWithValue("@Author", string.IsNullOrEmpty(txtAuthor.Text) || txtAuthor.Text == "Author" ? (object)DBNull.Value : $"%{txtAuthor.Text}%");

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable resultsTable = new DataTable();
                adapter.Fill(resultsTable);
                dataGridViewResults.DataSource = resultsTable;
            }
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGenre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}