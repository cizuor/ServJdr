namespace JDR.RemplireBDD
{
    partial class IHMAddRace
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
            this.panelAffichage = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblValues = new System.Windows.Forms.Label();
            this.lbltype = new System.Windows.Forms.Label();
            this.listtype = new System.Windows.Forms.ListBox();
            this.lblNom = new System.Windows.Forms.Label();
            this.tbNom = new System.Windows.Forms.TextBox();
            this.tbDef = new System.Windows.Forms.TextBox();
            this.lblDef = new System.Windows.Forms.Label();
            this.cbJouable = new System.Windows.Forms.CheckBox();
            this.cbDomptable = new System.Windows.Forms.CheckBox();
            this.btnValider = new System.Windows.Forms.Button();
            this.cbExistant = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // panelAffichage
            // 
            this.panelAffichage.AutoScroll = true;
            this.panelAffichage.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.panelAffichage.Location = new System.Drawing.Point(12, 32);
            this.panelAffichage.Name = "panelAffichage";
            this.panelAffichage.Size = new System.Drawing.Size(463, 406);
            this.panelAffichage.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nom Stat";
            // 
            // lblValues
            // 
            this.lblValues.AutoSize = true;
            this.lblValues.Location = new System.Drawing.Point(382, 9);
            this.lblValues.Name = "lblValues";
            this.lblValues.Size = new System.Drawing.Size(59, 13);
            this.lblValues.TabIndex = 1;
            this.lblValues.Text = "Valeur Stat";
            // 
            // lbltype
            // 
            this.lbltype.AutoSize = true;
            this.lbltype.Location = new System.Drawing.Point(508, 9);
            this.lbltype.Name = "lbltype";
            this.lbltype.Size = new System.Drawing.Size(27, 13);
            this.lbltype.TabIndex = 2;
            this.lbltype.Text = "type";
            // 
            // listtype
            // 
            this.listtype.FormattingEnabled = true;
            this.listtype.Items.AddRange(new object[] {
            "race",
            "sousrace",
            "classe"});
            this.listtype.Location = new System.Drawing.Point(553, 9);
            this.listtype.Name = "listtype";
            this.listtype.Size = new System.Drawing.Size(55, 43);
            this.listtype.TabIndex = 3;
            this.listtype.SelectedIndexChanged += new System.EventHandler(this.listtype_SelectedIndexChanged);
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(508, 88);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(29, 13);
            this.lblNom.TabIndex = 4;
            this.lblNom.Text = "Nom";
            // 
            // tbNom
            // 
            this.tbNom.Location = new System.Drawing.Point(584, 88);
            this.tbNom.Name = "tbNom";
            this.tbNom.Size = new System.Drawing.Size(100, 20);
            this.tbNom.TabIndex = 5;
            // 
            // tbDef
            // 
            this.tbDef.Location = new System.Drawing.Point(584, 123);
            this.tbDef.Name = "tbDef";
            this.tbDef.Size = new System.Drawing.Size(100, 20);
            this.tbDef.TabIndex = 7;
            // 
            // lblDef
            // 
            this.lblDef.AutoSize = true;
            this.lblDef.Location = new System.Drawing.Point(508, 126);
            this.lblDef.Name = "lblDef";
            this.lblDef.Size = new System.Drawing.Size(51, 13);
            this.lblDef.TabIndex = 6;
            this.lblDef.Text = "Definition";
            // 
            // cbJouable
            // 
            this.cbJouable.AutoSize = true;
            this.cbJouable.Location = new System.Drawing.Point(584, 163);
            this.cbJouable.Name = "cbJouable";
            this.cbJouable.Size = new System.Drawing.Size(63, 17);
            this.cbJouable.TabIndex = 9;
            this.cbJouable.Text = "Jouable";
            this.cbJouable.UseVisualStyleBackColor = true;
            // 
            // cbDomptable
            // 
            this.cbDomptable.AutoSize = true;
            this.cbDomptable.Location = new System.Drawing.Point(584, 186);
            this.cbDomptable.Name = "cbDomptable";
            this.cbDomptable.Size = new System.Drawing.Size(77, 17);
            this.cbDomptable.TabIndex = 10;
            this.cbDomptable.Text = "Domptable";
            this.cbDomptable.UseVisualStyleBackColor = true;
            // 
            // btnValider
            // 
            this.btnValider.Location = new System.Drawing.Point(584, 296);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(75, 23);
            this.btnValider.TabIndex = 11;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = true;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // cbExistant
            // 
            this.cbExistant.FormattingEnabled = true;
            this.cbExistant.Location = new System.Drawing.Point(667, 9);
            this.cbExistant.Name = "cbExistant";
            this.cbExistant.Size = new System.Drawing.Size(121, 21);
            this.cbExistant.TabIndex = 12;
            this.cbExistant.SelectedIndexChanged += new System.EventHandler(this.cbExistant_SelectedIndexChanged);
            // 
            // IHMAddRace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbExistant);
            this.Controls.Add(this.btnValider);
            this.Controls.Add(this.cbDomptable);
            this.Controls.Add(this.cbJouable);
            this.Controls.Add(this.tbDef);
            this.Controls.Add(this.lblDef);
            this.Controls.Add(this.tbNom);
            this.Controls.Add(this.lblNom);
            this.Controls.Add(this.listtype);
            this.Controls.Add(this.lbltype);
            this.Controls.Add(this.lblValues);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelAffichage);
            this.Name = "IHMAddRace";
            this.Text = "IHMAddRace";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelAffichage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblValues;
        private System.Windows.Forms.Label lbltype;
        private System.Windows.Forms.ListBox listtype;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.TextBox tbNom;
        private System.Windows.Forms.TextBox tbDef;
        private System.Windows.Forms.Label lblDef;
        private System.Windows.Forms.CheckBox cbJouable;
        private System.Windows.Forms.CheckBox cbDomptable;
        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.ComboBox cbExistant;
    }
}