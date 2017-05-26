namespace Version_1
{
    partial class frmFiction
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt3letter = new System.Windows.Forms.TextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt3letter
            // 
            this.txt3letter.Location = new System.Drawing.Point(92, 256);
            this.txt3letter.Name = "txt3letter";
            this.txt3letter.Size = new System.Drawing.Size(100, 22);
            this.txt3letter.TabIndex = 14;
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(270, 256);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(100, 22);
            this.txtType.TabIndex = 15;
            // 
            // frmFiction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(446, 361);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.txt3letter);
            this.Name = "frmFiction";
            this.Text = "Fiction";
            this.Controls.SetChildIndex(this.txt3letter, 0);
            this.Controls.SetChildIndex(this.txtType, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt3letter;
        private System.Windows.Forms.TextBox txtType;
    }
}
