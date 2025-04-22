namespace WindowsFormsApp1
{
    partial class AddReservationForm
    {
        
        private System.ComponentModel.IContainer components = null;

        
        /// <param name="disposing">Если значение параметра равно true, удаляются управляемые ресурсы; если false, удаляются только неуправляемые ресурсы.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором формы

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtBookID = new System.Windows.Forms.TextBox();
            this.txtBorrowerID = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtBookID
            // 
            this.txtBookID.Location = new System.Drawing.Point(54, 68);
            this.txtBookID.Name = "txtBookID";
            this.txtBookID.Size = new System.Drawing.Size(200, 22);
            this.txtBookID.TabIndex = 0;
            this.txtBookID.TextChanged += new System.EventHandler(this.txtBookID_TextChanged);
            // 
            // txtBorrowerID
            // 
            this.txtBorrowerID.Location = new System.Drawing.Point(309, 68);
            this.txtBorrowerID.Name = "txtBorrowerID";
            this.txtBorrowerID.Size = new System.Drawing.Size(200, 22);
            this.txtBorrowerID.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(191, 219);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(158, 59);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Сохранить ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Зарезервирована",
            "Занята"});
            this.cmbStatus.Location = new System.Drawing.Point(170, 154);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(200, 24);
            this.cmbStatus.TabIndex = 3;
            // 
            // textBox12
            // 
            this.textBox12.Enabled = false;
            this.textBox12.HideSelection = false;
            this.textBox12.Location = new System.Drawing.Point(54, 23);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(200, 22);
            this.textBox12.TabIndex = 6;
            this.textBox12.Text = "id Книги";
            // 
            // textBox21
            // 
            this.textBox21.Enabled = false;
            this.textBox21.HideSelection = false;
            this.textBox21.Location = new System.Drawing.Point(309, 23);
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new System.Drawing.Size(200, 22);
            this.textBox21.TabIndex = 7;
            this.textBox21.Text = "Id Человека";
            // 
            // AddReservationForm
            // 
            this.ClientSize = new System.Drawing.Size(575, 392);
            this.Controls.Add(this.textBox21);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtBorrowerID);
            this.Controls.Add(this.txtBookID);
            this.Name = "AddReservationForm";
            this.Text = "Add Reservation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBookID;
        private System.Windows.Forms.TextBox txtBorrowerID;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox21;
        private System.Windows.Forms.ComboBox cmbStatus;

        private void txtBookID_TextChanged(object sender, System.EventArgs e)
        {

        }
    }
}
