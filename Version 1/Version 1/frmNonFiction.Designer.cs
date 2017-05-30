namespace Version_1
{
    partial class frmNonFiction
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
            this.txtDewey = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtDewey
            // 
            this.txtDewey.Location = new System.Drawing.Point(92, 252);
            this.txtDewey.Name = "txtDewey";
            this.txtDewey.Size = new System.Drawing.Size(100, 22);
            this.txtDewey.TabIndex = 14;
            // 
            // frmNonFiction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(446, 361);
            this.Controls.Add(this.txtDewey);
            this.Name = "frmNonFiction";
            this.Controls.SetChildIndex(this.txtDewey, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDewey;
    }
}
