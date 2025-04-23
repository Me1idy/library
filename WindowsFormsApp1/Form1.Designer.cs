using System.Windows.Forms;
using System;

namespace WindowsFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewResults;
        private System.Windows.Forms.DataGridView dataGridViewUsers;
        private System.Windows.Forms.DataGridView dataGridViewReservations;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAddReservation;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnCancelReservation;
        private System.Windows.Forms.Button btnIssueBook;
        private System.Windows.Forms.ComboBox comboBoxStatusFilter; // Объявление здесь

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridViewResults = new System.Windows.Forms.DataGridView();
            this.dataGridViewUsers = new System.Windows.Forms.DataGridView();
            this.dataGridViewReservations = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAddReservation = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnCancelReservation = new System.Windows.Forms.Button();
            this.btnIssueBook = new System.Windows.Forms.Button();
            this.comboBoxStatusFilter = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReservations)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewResults
            // 
            this.dataGridViewResults.BackgroundColor = System.Drawing.Color.DimGray;
            this.dataGridViewResults.ColumnHeadersHeight = 29;
            this.dataGridViewResults.Location = new System.Drawing.Point(835, 23);
            this.dataGridViewResults.Name = "dataGridViewResults";
            this.dataGridViewResults.RowHeadersWidth = 51;
            this.dataGridViewResults.Size = new System.Drawing.Size(471, 300);
            this.dataGridViewResults.TabIndex = 0;
            // 
            // dataGridViewUsers
            // 
            this.dataGridViewUsers.BackgroundColor = System.Drawing.Color.DimGray;
            this.dataGridViewUsers.ColumnHeadersHeight = 29;
            this.dataGridViewUsers.Location = new System.Drawing.Point(835, 358);
            this.dataGridViewUsers.Name = "dataGridViewUsers";
            this.dataGridViewUsers.RowHeadersWidth = 51;
            this.dataGridViewUsers.Size = new System.Drawing.Size(471, 300);
            this.dataGridViewUsers.TabIndex = 1;
            // 
            // dataGridViewReservations
            // 
            this.dataGridViewReservations.BackgroundColor = System.Drawing.Color.DimGray;
            this.dataGridViewReservations.ColumnHeadersHeight = 29;
            this.dataGridViewReservations.Location = new System.Drawing.Point(186, 358);
            this.dataGridViewReservations.Name = "dataGridViewReservations";
            this.dataGridViewReservations.RowHeadersWidth = 51;
            this.dataGridViewReservations.Size = new System.Drawing.Size(544, 300);
            this.dataGridViewReservations.TabIndex = 6;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.YellowGreen;
            this.btnSearch.Location = new System.Drawing.Point(186, 40);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(151, 71);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Найти Книгу";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAddReservation
            // 
            this.btnAddReservation.BackColor = System.Drawing.Color.YellowGreen;
            this.btnAddReservation.Location = new System.Drawing.Point(378, 148);
            this.btnAddReservation.Name = "btnAddReservation";
            this.btnAddReservation.Size = new System.Drawing.Size(151, 71);
            this.btnAddReservation.TabIndex = 3;
            this.btnAddReservation.Text = "Зарезервировать книгу";
            this.btnAddReservation.UseVisualStyleBackColor = false;
            this.btnAddReservation.Click += new System.EventHandler(this.btnAddReservation_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.BackColor = System.Drawing.Color.YellowGreen;
            this.btnAddUser.Location = new System.Drawing.Point(186, 148);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(151, 71);
            this.btnAddUser.TabIndex = 4;
            this.btnAddUser.Text = "Добавить пользователя";
            this.btnAddUser.UseVisualStyleBackColor = false;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.BackColor = System.Drawing.Color.YellowGreen;
            this.btnDeleteUser.Location = new System.Drawing.Point(579, 148);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(151, 71);
            this.btnDeleteUser.TabIndex = 5;
            this.btnDeleteUser.Text = "Удалить пользователя";
            this.btnDeleteUser.UseVisualStyleBackColor = false;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnCancelReservation
            // 
            this.btnCancelReservation.BackColor = System.Drawing.Color.YellowGreen;
            this.btnCancelReservation.Location = new System.Drawing.Point(378, 40);
            this.btnCancelReservation.Name = "btnCancelReservation";
            this.btnCancelReservation.Size = new System.Drawing.Size(151, 71);
            this.btnCancelReservation.TabIndex = 7;
            this.btnCancelReservation.Text = "Отменить резервацию";
            this.btnCancelReservation.UseVisualStyleBackColor = false;
            this.btnCancelReservation.Click += new System.EventHandler(this.btnCancelReservation_Click);
            // 
            // btnIssueBook
            // 
            this.btnIssueBook.BackColor = System.Drawing.Color.YellowGreen;
            this.btnIssueBook.Location = new System.Drawing.Point(579, 40);
            this.btnIssueBook.Name = "btnIssueBook";
            this.btnIssueBook.Size = new System.Drawing.Size(151, 71);
            this.btnIssueBook.TabIndex = 8;
            this.btnIssueBook.Text = "Выдать книгу";
            this.btnIssueBook.UseVisualStyleBackColor = false;
            this.btnIssueBook.Click += new System.EventHandler(this.btnIssueBook_Click);
            // 
            // comboBoxStatusFilter
            // 
            this.comboBoxStatusFilter.Location = new System.Drawing.Point(378, 274);
            this.comboBoxStatusFilter.Name = "comboBoxStatusFilter";
            this.comboBoxStatusFilter.Size = new System.Drawing.Size(175, 24);
            this.comboBoxStatusFilter.TabIndex = 9;
            this.comboBoxStatusFilter.SelectedIndexChanged += new System.EventHandler(this.comboBoxStatusFilter_SelectedIndexChanged_1);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(1347, 729);
            this.Controls.Add(this.comboBoxStatusFilter);
            this.Controls.Add(this.btnIssueBook);
            this.Controls.Add(this.btnCancelReservation);
            this.Controls.Add(this.dataGridViewReservations);
            this.Controls.Add(this.btnDeleteUser);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.dataGridViewResults);
            this.Controls.Add(this.dataGridViewUsers);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnAddReservation);
            this.Name = "Form1";
            this.Text = "Search Book";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReservations)).EndInit();
            this.ResumeLayout(false);

        }
    }
}