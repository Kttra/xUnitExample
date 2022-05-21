namespace ratioScaler
{
    partial class Form_TransparentBack
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
            this.SuspendLayout();
            // 
            // Form_TransparentBack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 301);
            this.Name = "Form_TransparentBack";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transparent Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form_TransparentBack_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_TransparentBack_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_TransparentBack_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_TransparentBack_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form_TransparentBack_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}