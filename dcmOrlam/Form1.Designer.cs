namespace dcmOrlam
{
	partial class Form1
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.button_VMAT = new System.Windows.Forms.Button();
			this.button_AutoBreast = new System.Windows.Forms.Button();
			this.textBox_result = new System.Windows.Forms.TextBox();
			this.status = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.textConsole = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// button_VMAT
			// 
			this.button_VMAT.Location = new System.Drawing.Point(708, 270);
			this.button_VMAT.Name = "button_VMAT";
			this.button_VMAT.Size = new System.Drawing.Size(133, 52);
			this.button_VMAT.TabIndex = 0;
			this.button_VMAT.Text = "VMAT";
			this.button_VMAT.UseVisualStyleBackColor = true;
			this.button_VMAT.Click += new System.EventHandler(this.button_VMAT_Click);
			// 
			// button_AutoBreast
			// 
			this.button_AutoBreast.Location = new System.Drawing.Point(847, 270);
			this.button_AutoBreast.Name = "button_AutoBreast";
			this.button_AutoBreast.Size = new System.Drawing.Size(133, 51);
			this.button_AutoBreast.TabIndex = 1;
			this.button_AutoBreast.Text = "AutoBreast";
			this.button_AutoBreast.UseVisualStyleBackColor = true;
			this.button_AutoBreast.Click += new System.EventHandler(this.button_AutoBreast_Click);
			// 
			// textBox_result
			// 
			this.textBox_result.Location = new System.Drawing.Point(126, 308);
			this.textBox_result.Name = "textBox_result";
			this.textBox_result.Size = new System.Drawing.Size(562, 22);
			this.textBox_result.TabIndex = 3;
			// 
			// status
			// 
			this.status.AutoSize = true;
			this.status.ForeColor = System.Drawing.Color.Black;
			this.status.Location = new System.Drawing.Point(9, 233);
			this.status.Name = "status";
			this.status.Size = new System.Drawing.Size(0, 17);
			this.status.TabIndex = 4;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(12, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(506, 162);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 5;
			this.pictureBox1.TabStop = false;
			// 
			// textConsole
			// 
			this.textConsole.Location = new System.Drawing.Point(708, 32);
			this.textConsole.Multiline = true;
			this.textConsole.Name = "textConsole";
			this.textConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textConsole.Size = new System.Drawing.Size(272, 232);
			this.textConsole.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(705, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(147, 17);
			this.label1.TabIndex = 7;
			this.label1.Text = "Résultat Modification :";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 308);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(111, 17);
			this.label3.TabIndex = 9;
			this.label3.Text = "Nom du Fichier :";
			// 
			// label2
			// 
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label2.Location = new System.Drawing.Point(9, 262);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(687, 40);
			this.label2.TabIndex = 10;
			this.label2.Text = "Il incombe à l\'utilisateur d\'effectuer toutes les vérifications de la conformité " +
    "du fichier modifié par rapport à la dosimétrie initiale ";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(995, 338);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textConsole);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.status);
			this.Controls.Add(this.textBox_result);
			this.Controls.Add(this.button_AutoBreast);
			this.Controls.Add(this.button_VMAT);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximumSize = new System.Drawing.Size(1013, 385);
			this.MinimumSize = new System.Drawing.Size(1013, 385);
			this.Name = "Form1";
			this.Text = "dcm Tool v2 29/03/18";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button_VMAT;
		private System.Windows.Forms.Button button_AutoBreast;
		private System.Windows.Forms.TextBox textBox_result;
		private System.Windows.Forms.Label status;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TextBox textConsole;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
	}
}

