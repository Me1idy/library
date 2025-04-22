
namespace WindowsFormsApp1
{
    partial class AddReservationForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtBookID;
        private System.Windows.Forms.TextBox txtBorrowerID;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblBookID;
        private System.Windows.Forms.Label lblBorrowerID;
        private System.Windows.Forms.Label lblStatus;

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
            this.txtBookID = new System.Windows.Forms.TextBox();
            this.txtBorrowerID = new System.Windows.Forms.TextBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblBookID = new System.Windows.Forms.Label();
            this.lblBorrowerID = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblBookID
            // 
            this.lblBookID.AutoSize = true;
            this.lblBookID.Location = new System.Drawing.Point(47, 50);
            this.lblBookID.Name = "lblBookID";
            this.lblBookID.Size = new System.Drawing.Size(62, 16);
            this.lblBookID.TabIndex = 4;
            this.lblBookID.Text = "ID книги";
            // 
            // lblBorrowerID
            // 
            this.lblBorrowerID.AutoSize = true;
            this.lblBorrowerID.Location = new System.Drawing.Point(47, 110);
            this.lblBorrowerID.Name = "lblBorrowerID";
            this.lblBorrowerID.Size = new System.Drawing.Size(97, 16);
            this.lblBorrowerID.TabIndex = 5;
            this.lblBorrowerID.Text = "ID пользователя";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(47, 170);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(52, 16);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Статус";
            // 
            // txtBookID
            // 
            this.txtBookID.Location = new System.Drawing.Point(50, 70);
            this.txtBookID.Name = "txtBookID";
            this.txtBookID.Size = new System.Drawing.Size(200, 22);
            this.txtBookID.TabIndex = 0;
            // 
            // txtBorrowerID
            // 
            this.txtBorrowerID.Location = new System.Drawing.Point(50, 130);
            this.txtBorrowerID.Name = "txtBorrowerID";
            this.txtBorrowerID.Size = new System.Drawing.Size(200, 22);
            this.txtBorrowerID.TabIndex = 1;
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(50, 190);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(200, 24);
            this.cmbStatus.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(50, 250);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(200, 64);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // AddReservationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 350);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblBorrowerID);
            this.Controls.Add(this.lblBookID);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.txtBorrowerID);
            this.Controls.Add(this.txtBookID);
            this.Name = "AddReservationForm";
            this.Text = "Добавить резервацию";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
