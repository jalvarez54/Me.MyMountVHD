namespace WindowsFormsApplication
{
    partial class FormMain
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonAttach = new System.Windows.Forms.Button();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.buttonDetach = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonAttach
            // 
            this.buttonAttach.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonAttach.Location = new System.Drawing.Point(0, 0);
            this.buttonAttach.Name = "buttonAttach";
            this.buttonAttach.Size = new System.Drawing.Size(284, 23);
            this.buttonAttach.TabIndex = 0;
            this.buttonAttach.Text = "Attach";
            this.buttonAttach.UseVisualStyleBackColor = true;
            this.buttonAttach.Click += new System.EventHandler(this.buttonAttach_Click);
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBoxMessage.Location = new System.Drawing.Point(0, 52);
            this.textBoxMessage.Multiline = true;
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(284, 209);
            this.textBoxMessage.TabIndex = 1;
            // 
            // buttonDetach
            // 
            this.buttonDetach.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonDetach.Location = new System.Drawing.Point(0, 23);
            this.buttonDetach.Name = "buttonDetach";
            this.buttonDetach.Size = new System.Drawing.Size(284, 23);
            this.buttonDetach.TabIndex = 2;
            this.buttonDetach.Text = "Deatch";
            this.buttonDetach.UseVisualStyleBackColor = true;
            this.buttonDetach.Click += new System.EventHandler(this.buttonDetach_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.buttonDetach);
            this.Controls.Add(this.textBoxMessage);
            this.Controls.Add(this.buttonAttach);
            this.Name = "FormMain";
            this.Text = "WindowsFormsApplication";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAttach;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.Button buttonDetach;
    }
}

