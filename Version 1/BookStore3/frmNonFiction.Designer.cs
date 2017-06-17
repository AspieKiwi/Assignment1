namespace BookUniversal
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
            this.lblDewey = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDewey
            // 
            this.txtDewey.Location = new System.Drawing.Point(167, 303);
            this.txtDewey.Name = "txtDewey";
            this.txtDewey.Size = new System.Drawing.Size(334, 22);
            this.txtDewey.TabIndex = 14;
            // 
            // lblDewey
            // 
            this.lblDewey.AutoSize = true;
            this.lblDewey.Location = new System.Drawing.Point(35, 306);
            this.lblDewey.Name = "lblDewey";
            this.lblDewey.Size = new System.Drawing.Size(104, 17);
            this.lblDewey.TabIndex = 15;
            this.lblDewey.Text = "Dewey Decimal";
            // 
            // frmNonFiction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(513, 411);
            this.Controls.Add(this.lblDewey);
            this.Controls.Add(this.txtDewey);
            this.Name = "frmNonFiction";
            this.Controls.SetChildIndex(this.txtDewey, 0);
            this.Controls.SetChildIndex(this.lblDewey, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDewey;
        private System.Windows.Forms.Label lblDewey;
    }
}
