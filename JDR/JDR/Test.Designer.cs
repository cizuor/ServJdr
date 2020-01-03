namespace JDR
{
    partial class Test
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
            this.listBoxPerso1 = new System.Windows.Forms.ListBox();
            this.listBoxPerso2 = new System.Windows.Forms.ListBox();
            this.listBoxItem = new System.Windows.Forms.ListBox();
            this.listBoxInventaire2 = new System.Windows.Forms.ListBox();
            this.listBoxInventaire1 = new System.Windows.Forms.ListBox();
            this.btnloot1 = new System.Windows.Forms.Button();
            this.btnloot2 = new System.Windows.Forms.Button();
            this.btnequip2 = new System.Windows.Forms.Button();
            this.btnDesequipe2 = new System.Windows.Forms.Button();
            this.btnequip1 = new System.Windows.Forms.Button();
            this.btnDesequipe1 = new System.Windows.Forms.Button();
            this.labelattaque = new System.Windows.Forms.Label();
            this.btnAttaque1 = new System.Windows.Forms.Button();
            this.btnAttaque2 = new System.Windows.Forms.Button();
            this.labelPV1 = new System.Windows.Forms.Label();
            this.labelPV2 = new System.Windows.Forms.Label();
            this.labelPos1 = new System.Windows.Forms.Label();
            this.labelPos2 = new System.Windows.Forms.Label();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnMove1 = new System.Windows.Forms.Button();
            this.btnMove2 = new System.Windows.Forms.Button();
            this.btnAddMove1 = new System.Windows.Forms.Button();
            this.btnAddMove2 = new System.Windows.Forms.Button();
            this.btnFinTour = new System.Windows.Forms.Button();
            this.labelPA1 = new System.Windows.Forms.Label();
            this.labelPM1 = new System.Windows.Forms.Label();
            this.labelPA2 = new System.Windows.Forms.Label();
            this.labelPM2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxPerso1
            // 
            this.listBoxPerso1.FormattingEnabled = true;
            this.listBoxPerso1.Location = new System.Drawing.Point(12, 12);
            this.listBoxPerso1.Name = "listBoxPerso1";
            this.listBoxPerso1.Size = new System.Drawing.Size(120, 95);
            this.listBoxPerso1.TabIndex = 0;
            this.listBoxPerso1.SelectedIndexChanged += new System.EventHandler(this.listBoxPerso1_SelectedIndexChanged);
            // 
            // listBoxPerso2
            // 
            this.listBoxPerso2.FormattingEnabled = true;
            this.listBoxPerso2.Location = new System.Drawing.Point(668, 12);
            this.listBoxPerso2.Name = "listBoxPerso2";
            this.listBoxPerso2.Size = new System.Drawing.Size(120, 95);
            this.listBoxPerso2.TabIndex = 1;
            this.listBoxPerso2.SelectedIndexChanged += new System.EventHandler(this.listBoxPerso2_SelectedIndexChanged);
            // 
            // listBoxItem
            // 
            this.listBoxItem.FormattingEnabled = true;
            this.listBoxItem.Location = new System.Drawing.Point(327, 12);
            this.listBoxItem.Name = "listBoxItem";
            this.listBoxItem.Size = new System.Drawing.Size(120, 95);
            this.listBoxItem.TabIndex = 2;
            // 
            // listBoxInventaire2
            // 
            this.listBoxInventaire2.FormattingEnabled = true;
            this.listBoxInventaire2.Location = new System.Drawing.Point(668, 125);
            this.listBoxInventaire2.Name = "listBoxInventaire2";
            this.listBoxInventaire2.Size = new System.Drawing.Size(120, 95);
            this.listBoxInventaire2.TabIndex = 3;
            // 
            // listBoxInventaire1
            // 
            this.listBoxInventaire1.FormattingEnabled = true;
            this.listBoxInventaire1.Location = new System.Drawing.Point(12, 125);
            this.listBoxInventaire1.Name = "listBoxInventaire1";
            this.listBoxInventaire1.Size = new System.Drawing.Size(120, 95);
            this.listBoxInventaire1.TabIndex = 4;
            // 
            // btnloot1
            // 
            this.btnloot1.Location = new System.Drawing.Point(199, 23);
            this.btnloot1.Name = "btnloot1";
            this.btnloot1.Size = new System.Drawing.Size(75, 23);
            this.btnloot1.TabIndex = 5;
            this.btnloot1.Text = "donné";
            this.btnloot1.UseVisualStyleBackColor = true;
            this.btnloot1.Click += new System.EventHandler(this.btnloot1_Click);
            // 
            // btnloot2
            // 
            this.btnloot2.Location = new System.Drawing.Point(514, 23);
            this.btnloot2.Name = "btnloot2";
            this.btnloot2.Size = new System.Drawing.Size(75, 23);
            this.btnloot2.TabIndex = 6;
            this.btnloot2.Text = "donné";
            this.btnloot2.UseVisualStyleBackColor = true;
            this.btnloot2.Click += new System.EventHandler(this.btnloot2_Click);
            // 
            // btnequip2
            // 
            this.btnequip2.Location = new System.Drawing.Point(514, 140);
            this.btnequip2.Name = "btnequip2";
            this.btnequip2.Size = new System.Drawing.Size(75, 23);
            this.btnequip2.TabIndex = 7;
            this.btnequip2.Text = "equip";
            this.btnequip2.UseVisualStyleBackColor = true;
            this.btnequip2.Click += new System.EventHandler(this.btnequip2_Click);
            // 
            // btnDesequipe2
            // 
            this.btnDesequipe2.Location = new System.Drawing.Point(514, 179);
            this.btnDesequipe2.Name = "btnDesequipe2";
            this.btnDesequipe2.Size = new System.Drawing.Size(75, 23);
            this.btnDesequipe2.TabIndex = 8;
            this.btnDesequipe2.Text = "déséquipe";
            this.btnDesequipe2.UseVisualStyleBackColor = true;
            this.btnDesequipe2.Click += new System.EventHandler(this.btnDesequipe2_Click);
            // 
            // btnequip1
            // 
            this.btnequip1.Location = new System.Drawing.Point(199, 140);
            this.btnequip1.Name = "btnequip1";
            this.btnequip1.Size = new System.Drawing.Size(75, 23);
            this.btnequip1.TabIndex = 9;
            this.btnequip1.Text = "equip";
            this.btnequip1.UseVisualStyleBackColor = true;
            this.btnequip1.Click += new System.EventHandler(this.btnequip1_Click);
            // 
            // btnDesequipe1
            // 
            this.btnDesequipe1.Location = new System.Drawing.Point(199, 179);
            this.btnDesequipe1.Name = "btnDesequipe1";
            this.btnDesequipe1.Size = new System.Drawing.Size(75, 23);
            this.btnDesequipe1.TabIndex = 10;
            this.btnDesequipe1.Text = "déséquipe";
            this.btnDesequipe1.UseVisualStyleBackColor = true;
            this.btnDesequipe1.Click += new System.EventHandler(this.btnDesequipe1_Click);
            // 
            // labelattaque
            // 
            this.labelattaque.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelattaque.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelattaque.Location = new System.Drawing.Point(280, 110);
            this.labelattaque.Name = "labelattaque";
            this.labelattaque.Size = new System.Drawing.Size(228, 66);
            this.labelattaque.TabIndex = 11;
            this.labelattaque.Text = "result";
            this.labelattaque.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAttaque1
            // 
            this.btnAttaque1.Location = new System.Drawing.Point(292, 179);
            this.btnAttaque1.Name = "btnAttaque1";
            this.btnAttaque1.Size = new System.Drawing.Size(75, 23);
            this.btnAttaque1.TabIndex = 12;
            this.btnAttaque1.Text = "Attaque";
            this.btnAttaque1.UseVisualStyleBackColor = true;
            this.btnAttaque1.Click += new System.EventHandler(this.btnAttaque1_Click);
            // 
            // btnAttaque2
            // 
            this.btnAttaque2.Location = new System.Drawing.Point(421, 179);
            this.btnAttaque2.Name = "btnAttaque2";
            this.btnAttaque2.Size = new System.Drawing.Size(75, 23);
            this.btnAttaque2.TabIndex = 13;
            this.btnAttaque2.Text = "Attaque";
            this.btnAttaque2.UseVisualStyleBackColor = true;
            this.btnAttaque2.Click += new System.EventHandler(this.btnAttaque2_Click);
            // 
            // labelPV1
            // 
            this.labelPV1.AutoSize = true;
            this.labelPV1.Location = new System.Drawing.Point(46, 223);
            this.labelPV1.Name = "labelPV1";
            this.labelPV1.Size = new System.Drawing.Size(21, 13);
            this.labelPV1.TabIndex = 14;
            this.labelPV1.Text = "PV";
            // 
            // labelPV2
            // 
            this.labelPV2.AutoSize = true;
            this.labelPV2.Location = new System.Drawing.Point(706, 223);
            this.labelPV2.Name = "labelPV2";
            this.labelPV2.Size = new System.Drawing.Size(21, 13);
            this.labelPV2.TabIndex = 15;
            this.labelPV2.Text = "PV";
            // 
            // labelPos1
            // 
            this.labelPos1.AutoSize = true;
            this.labelPos1.Location = new System.Drawing.Point(32, 256);
            this.labelPos1.Name = "labelPos1";
            this.labelPos1.Size = new System.Drawing.Size(35, 13);
            this.labelPos1.TabIndex = 16;
            this.labelPos1.Text = "label1";
            // 
            // labelPos2
            // 
            this.labelPos2.AutoSize = true;
            this.labelPos2.Location = new System.Drawing.Point(706, 256);
            this.labelPos2.Name = "labelPos2";
            this.labelPos2.Size = new System.Drawing.Size(35, 13);
            this.labelPos2.TabIndex = 17;
            this.labelPos2.Text = "label1";
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(347, 223);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(100, 20);
            this.textBoxX.TabIndex = 18;
            this.textBoxX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(347, 249);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(100, 20);
            this.textBoxY.TabIndex = 19;
            this.textBoxY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(306, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(306, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Y";
            // 
            // btnMove1
            // 
            this.btnMove1.Location = new System.Drawing.Point(199, 219);
            this.btnMove1.Name = "btnMove1";
            this.btnMove1.Size = new System.Drawing.Size(75, 23);
            this.btnMove1.TabIndex = 22;
            this.btnMove1.Text = "Move";
            this.btnMove1.UseVisualStyleBackColor = true;
            this.btnMove1.Click += new System.EventHandler(this.btnMove1_Click);
            // 
            // btnMove2
            // 
            this.btnMove2.Location = new System.Drawing.Point(514, 213);
            this.btnMove2.Name = "btnMove2";
            this.btnMove2.Size = new System.Drawing.Size(75, 23);
            this.btnMove2.TabIndex = 23;
            this.btnMove2.Text = "Move";
            this.btnMove2.UseVisualStyleBackColor = true;
            this.btnMove2.Click += new System.EventHandler(this.btnMove2_Click);
            // 
            // btnAddMove1
            // 
            this.btnAddMove1.Location = new System.Drawing.Point(199, 275);
            this.btnAddMove1.Name = "btnAddMove1";
            this.btnAddMove1.Size = new System.Drawing.Size(75, 23);
            this.btnAddMove1.TabIndex = 24;
            this.btnAddMove1.Text = "addMove";
            this.btnAddMove1.UseVisualStyleBackColor = true;
            this.btnAddMove1.Click += new System.EventHandler(this.btnAddMove1_Click);
            // 
            // btnAddMove2
            // 
            this.btnAddMove2.Location = new System.Drawing.Point(514, 275);
            this.btnAddMove2.Name = "btnAddMove2";
            this.btnAddMove2.Size = new System.Drawing.Size(75, 23);
            this.btnAddMove2.TabIndex = 25;
            this.btnAddMove2.Text = "addMove";
            this.btnAddMove2.UseVisualStyleBackColor = true;
            this.btnAddMove2.Click += new System.EventHandler(this.btnAddMove2_Click);
            // 
            // btnFinTour
            // 
            this.btnFinTour.Location = new System.Drawing.Point(359, 275);
            this.btnFinTour.Name = "btnFinTour";
            this.btnFinTour.Size = new System.Drawing.Size(75, 23);
            this.btnFinTour.TabIndex = 26;
            this.btnFinTour.Text = "Fin tour";
            this.btnFinTour.UseVisualStyleBackColor = true;
            this.btnFinTour.Click += new System.EventHandler(this.btnFinTour_Click);
            // 
            // labelPA1
            // 
            this.labelPA1.AutoSize = true;
            this.labelPA1.Location = new System.Drawing.Point(12, 285);
            this.labelPA1.Name = "labelPA1";
            this.labelPA1.Size = new System.Drawing.Size(35, 13);
            this.labelPA1.TabIndex = 27;
            this.labelPA1.Text = "label1";
            // 
            // labelPM1
            // 
            this.labelPM1.AutoSize = true;
            this.labelPM1.Location = new System.Drawing.Point(53, 285);
            this.labelPM1.Name = "labelPM1";
            this.labelPM1.Size = new System.Drawing.Size(35, 13);
            this.labelPM1.TabIndex = 28;
            this.labelPM1.Text = "label4";
            // 
            // labelPA2
            // 
            this.labelPA2.AutoSize = true;
            this.labelPA2.Location = new System.Drawing.Point(733, 280);
            this.labelPA2.Name = "labelPA2";
            this.labelPA2.Size = new System.Drawing.Size(35, 13);
            this.labelPA2.TabIndex = 29;
            this.labelPA2.Text = "label5";
            // 
            // labelPM2
            // 
            this.labelPM2.AutoSize = true;
            this.labelPM2.Location = new System.Drawing.Point(692, 280);
            this.labelPM2.Name = "labelPM2";
            this.labelPM2.Size = new System.Drawing.Size(35, 13);
            this.labelPM2.TabIndex = 30;
            this.labelPM2.Text = "label6";
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelPM2);
            this.Controls.Add(this.labelPA2);
            this.Controls.Add(this.labelPM1);
            this.Controls.Add(this.labelPA1);
            this.Controls.Add(this.btnFinTour);
            this.Controls.Add(this.btnAddMove2);
            this.Controls.Add(this.btnAddMove1);
            this.Controls.Add(this.btnMove2);
            this.Controls.Add(this.btnMove1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxY);
            this.Controls.Add(this.textBoxX);
            this.Controls.Add(this.labelPos2);
            this.Controls.Add(this.labelPos1);
            this.Controls.Add(this.labelPV2);
            this.Controls.Add(this.labelPV1);
            this.Controls.Add(this.btnAttaque2);
            this.Controls.Add(this.btnAttaque1);
            this.Controls.Add(this.labelattaque);
            this.Controls.Add(this.btnDesequipe1);
            this.Controls.Add(this.btnequip1);
            this.Controls.Add(this.btnDesequipe2);
            this.Controls.Add(this.btnequip2);
            this.Controls.Add(this.btnloot2);
            this.Controls.Add(this.btnloot1);
            this.Controls.Add(this.listBoxInventaire1);
            this.Controls.Add(this.listBoxInventaire2);
            this.Controls.Add(this.listBoxItem);
            this.Controls.Add(this.listBoxPerso2);
            this.Controls.Add(this.listBoxPerso1);
            this.Name = "Test";
            this.Text = "Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxPerso1;
        private System.Windows.Forms.ListBox listBoxPerso2;
        private System.Windows.Forms.ListBox listBoxItem;
        private System.Windows.Forms.ListBox listBoxInventaire2;
        private System.Windows.Forms.ListBox listBoxInventaire1;
        private System.Windows.Forms.Button btnloot1;
        private System.Windows.Forms.Button btnloot2;
        private System.Windows.Forms.Button btnequip2;
        private System.Windows.Forms.Button btnDesequipe2;
        private System.Windows.Forms.Button btnequip1;
        private System.Windows.Forms.Button btnDesequipe1;
        private System.Windows.Forms.Label labelattaque;
        private System.Windows.Forms.Button btnAttaque1;
        private System.Windows.Forms.Button btnAttaque2;
        private System.Windows.Forms.Label labelPV1;
        private System.Windows.Forms.Label labelPV2;
        private System.Windows.Forms.Label labelPos1;
        private System.Windows.Forms.Label labelPos2;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnMove1;
        private System.Windows.Forms.Button btnMove2;
        private System.Windows.Forms.Button btnAddMove1;
        private System.Windows.Forms.Button btnAddMove2;
        private System.Windows.Forms.Button btnFinTour;
        private System.Windows.Forms.Label labelPA1;
        private System.Windows.Forms.Label labelPM1;
        private System.Windows.Forms.Label labelPA2;
        private System.Windows.Forms.Label labelPM2;
    }
}