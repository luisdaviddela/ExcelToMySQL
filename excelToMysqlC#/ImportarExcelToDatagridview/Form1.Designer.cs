namespace ImportarExcelToDatagridview
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.BBrowse = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BBrowse
            // 
            this.BBrowse.BackColor = System.Drawing.SystemColors.HighlightText;
            this.BBrowse.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BBrowse.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BBrowse.Image = ((System.Drawing.Image)(resources.GetObject("BBrowse.Image")));
            this.BBrowse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BBrowse.Location = new System.Drawing.Point(46, 55);
            this.BBrowse.Name = "BBrowse";
            this.BBrowse.Size = new System.Drawing.Size(141, 45);
            this.BBrowse.TabIndex = 193;
            this.BBrowse.Text = "Seleccionar Excel";
            this.BBrowse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BBrowse.UseVisualStyleBackColor = false;
            this.BBrowse.Click += new System.EventHandler(this.BBrowse_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.button2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(70, 106);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 37);
            this.button2.TabIndex = 195;
            this.button2.Text = "Go";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(244, 274);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.BBrowse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excel to MySQL";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Button BBrowse;
        private System.Windows.Forms.Button button2;
    }
}

