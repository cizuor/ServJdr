namespace JDR.RemplireBDD
{
    partial class IHMAddItem
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
            this.cbExistant = new System.Windows.Forms.ComboBox();
            this.btnValider = new System.Windows.Forms.Button();
            this.cbLootable = new System.Windows.Forms.CheckBox();
            this.tbDef = new System.Windows.Forms.TextBox();
            this.lblDef = new System.Windows.Forms.Label();
            this.tbNom = new System.Windows.Forms.TextBox();
            this.lblNom = new System.Windows.Forms.Label();
            this.listtype = new System.Windows.Forms.ListBox();
            this.lbltype = new System.Windows.Forms.Label();
            this.lblValues = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelAffichage = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbEquip = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbItem = new System.Windows.Forms.ComboBox();
            this.tbPoid = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbNBDee = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbPrix = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbTypeDee = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbRatioAg = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbBaseDommage = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbRatioF = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbDommage = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbChanceCrit = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbBonusRM = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbDegatsCrit = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbRMBase = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbBonusArmure = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbArmureBase = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tbRatioInt = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tbNbMain = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.tbPorterMin = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.tbPSort = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.tbPorterMax = new System.Windows.Forms.TextBox();
            this.tbDurée = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbExistant
            // 
            this.cbExistant.FormattingEnabled = true;
            this.cbExistant.Location = new System.Drawing.Point(667, 11);
            this.cbExistant.Name = "cbExistant";
            this.cbExistant.Size = new System.Drawing.Size(121, 21);
            this.cbExistant.TabIndex = 25;
            this.cbExistant.SelectedIndexChanged += new System.EventHandler(this.cbExistant_SelectedIndexChanged);
            // 
            // btnValider
            // 
            this.btnValider.Location = new System.Drawing.Point(584, 415);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(75, 23);
            this.btnValider.TabIndex = 24;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = true;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // cbLootable
            // 
            this.cbLootable.AutoSize = true;
            this.cbLootable.Location = new System.Drawing.Point(695, 380);
            this.cbLootable.Name = "cbLootable";
            this.cbLootable.Size = new System.Drawing.Size(67, 17);
            this.cbLootable.TabIndex = 22;
            this.cbLootable.Text = "Lootable";
            this.cbLootable.UseVisualStyleBackColor = true;
            // 
            // tbDef
            // 
            this.tbDef.Location = new System.Drawing.Point(535, 89);
            this.tbDef.Name = "tbDef";
            this.tbDef.Size = new System.Drawing.Size(100, 20);
            this.tbDef.TabIndex = 21;
            // 
            // lblDef
            // 
            this.lblDef.AutoSize = true;
            this.lblDef.Location = new System.Drawing.Point(481, 92);
            this.lblDef.Name = "lblDef";
            this.lblDef.Size = new System.Drawing.Size(51, 13);
            this.lblDef.TabIndex = 20;
            this.lblDef.Text = "Definition";
            // 
            // tbNom
            // 
            this.tbNom.Location = new System.Drawing.Point(535, 63);
            this.tbNom.Name = "tbNom";
            this.tbNom.Size = new System.Drawing.Size(100, 20);
            this.tbNom.TabIndex = 19;
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(481, 63);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(29, 13);
            this.lblNom.TabIndex = 18;
            this.lblNom.Text = "Nom";
            // 
            // listtype
            // 
            this.listtype.FormattingEnabled = true;
            this.listtype.Items.AddRange(new object[] {
            "genre",
            "materiel",
            "qualite"});
            this.listtype.Location = new System.Drawing.Point(553, 11);
            this.listtype.Name = "listtype";
            this.listtype.Size = new System.Drawing.Size(55, 43);
            this.listtype.TabIndex = 17;
            this.listtype.SelectedIndexChanged += new System.EventHandler(this.listtype_SelectedIndexChanged);
            // 
            // lbltype
            // 
            this.lbltype.AutoSize = true;
            this.lbltype.Location = new System.Drawing.Point(508, 11);
            this.lbltype.Name = "lbltype";
            this.lbltype.Size = new System.Drawing.Size(27, 13);
            this.lbltype.TabIndex = 16;
            this.lbltype.Text = "type";
            // 
            // lblValues
            // 
            this.lblValues.AutoSize = true;
            this.lblValues.Location = new System.Drawing.Point(382, 11);
            this.lblValues.Name = "lblValues";
            this.lblValues.Size = new System.Drawing.Size(59, 13);
            this.lblValues.TabIndex = 15;
            this.lblValues.Text = "Valeur Stat";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Nom Stat";
            // 
            // panelAffichage
            // 
            this.panelAffichage.AutoScroll = true;
            this.panelAffichage.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.panelAffichage.Location = new System.Drawing.Point(12, 34);
            this.panelAffichage.Name = "panelAffichage";
            this.panelAffichage.Size = new System.Drawing.Size(463, 406);
            this.panelAffichage.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(641, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Type equip";
            // 
            // cbEquip
            // 
            this.cbEquip.FormattingEnabled = true;
            this.cbEquip.Items.AddRange(new object[] {
            "cac",
            "dist",
            "armure"});
            this.cbEquip.Location = new System.Drawing.Point(708, 61);
            this.cbEquip.Name = "cbEquip";
            this.cbEquip.Size = new System.Drawing.Size(80, 21);
            this.cbEquip.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(640, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Type item";
            // 
            // cbItem
            // 
            this.cbItem.FormattingEnabled = true;
            this.cbItem.Items.AddRange(new object[] {
            "cac",
            "dist",
            "armure"});
            this.cbItem.Location = new System.Drawing.Point(708, 89);
            this.cbItem.Name = "cbItem";
            this.cbItem.Size = new System.Drawing.Size(80, 21);
            this.cbItem.TabIndex = 29;
            // 
            // tbPoid
            // 
            this.tbPoid.Location = new System.Drawing.Point(535, 142);
            this.tbPoid.Name = "tbPoid";
            this.tbPoid.Size = new System.Drawing.Size(100, 20);
            this.tbPoid.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(482, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Poid";
            // 
            // tbNBDee
            // 
            this.tbNBDee.Location = new System.Drawing.Point(535, 116);
            this.tbNBDee.Name = "tbNBDee";
            this.tbNBDee.Size = new System.Drawing.Size(100, 20);
            this.tbNBDee.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(481, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Nb dée";
            // 
            // tbPrix
            // 
            this.tbPrix.Location = new System.Drawing.Point(695, 142);
            this.tbPrix.Name = "tbPrix";
            this.tbPrix.Size = new System.Drawing.Size(100, 20);
            this.tbPrix.TabIndex = 37;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(641, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Prix";
            // 
            // tbTypeDee
            // 
            this.tbTypeDee.Location = new System.Drawing.Point(695, 116);
            this.tbTypeDee.Name = "tbTypeDee";
            this.tbTypeDee.Size = new System.Drawing.Size(100, 20);
            this.tbTypeDee.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(640, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "Type dee";
            // 
            // tbRatioAg
            // 
            this.tbRatioAg.Location = new System.Drawing.Point(695, 195);
            this.tbRatioAg.Name = "tbRatioAg";
            this.tbRatioAg.Size = new System.Drawing.Size(100, 20);
            this.tbRatioAg.TabIndex = 45;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(640, 198);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 44;
            this.label8.Text = "Ratio Ag";
            // 
            // tbBaseDommage
            // 
            this.tbBaseDommage.Location = new System.Drawing.Point(695, 169);
            this.tbBaseDommage.Name = "tbBaseDommage";
            this.tbBaseDommage.Size = new System.Drawing.Size(100, 20);
            this.tbBaseDommage.TabIndex = 43;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(639, 172);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 42;
            this.label9.Text = "base dom";
            // 
            // tbRatioF
            // 
            this.tbRatioF.Location = new System.Drawing.Point(535, 195);
            this.tbRatioF.Name = "tbRatioF";
            this.tbRatioF.Size = new System.Drawing.Size(100, 20);
            this.tbRatioF.TabIndex = 41;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(481, 198);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 13);
            this.label10.TabIndex = 40;
            this.label10.Text = "ratio F";
            // 
            // tbDommage
            // 
            this.tbDommage.Location = new System.Drawing.Point(535, 169);
            this.tbDommage.Name = "tbDommage";
            this.tbDommage.Size = new System.Drawing.Size(100, 20);
            this.tbDommage.TabIndex = 39;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(474, 172);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 38;
            this.label11.Text = "Dommage";
            // 
            // tbChanceCrit
            // 
            this.tbChanceCrit.Location = new System.Drawing.Point(695, 300);
            this.tbChanceCrit.Name = "tbChanceCrit";
            this.tbChanceCrit.Size = new System.Drawing.Size(100, 20);
            this.tbChanceCrit.TabIndex = 61;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(639, 303);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 13);
            this.label12.TabIndex = 60;
            this.label12.Text = "chance crit";
            // 
            // tbBonusRM
            // 
            this.tbBonusRM.Location = new System.Drawing.Point(695, 274);
            this.tbBonusRM.Name = "tbBonusRM";
            this.tbBonusRM.Size = new System.Drawing.Size(100, 20);
            this.tbBonusRM.TabIndex = 59;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(639, 276);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 13);
            this.label13.TabIndex = 58;
            this.label13.Text = "bonus RM";
            // 
            // tbDegatsCrit
            // 
            this.tbDegatsCrit.Location = new System.Drawing.Point(534, 300);
            this.tbDegatsCrit.Name = "tbDegatsCrit";
            this.tbDegatsCrit.Size = new System.Drawing.Size(100, 20);
            this.tbDegatsCrit.TabIndex = 57;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(476, 303);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 13);
            this.label14.TabIndex = 56;
            this.label14.Text = "degats crit";
            // 
            // tbRMBase
            // 
            this.tbRMBase.Location = new System.Drawing.Point(535, 274);
            this.tbRMBase.Name = "tbRMBase";
            this.tbRMBase.Size = new System.Drawing.Size(100, 20);
            this.tbRMBase.TabIndex = 55;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(474, 276);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 13);
            this.label15.TabIndex = 54;
            this.label15.Text = "RM Base";
            // 
            // tbBonusArmure
            // 
            this.tbBonusArmure.Location = new System.Drawing.Point(695, 247);
            this.tbBonusArmure.Name = "tbBonusArmure";
            this.tbBonusArmure.Size = new System.Drawing.Size(100, 20);
            this.tbBonusArmure.TabIndex = 53;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(639, 250);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 13);
            this.label16.TabIndex = 52;
            this.label16.Text = "bonus Armure";
            // 
            // tbArmureBase
            // 
            this.tbArmureBase.Location = new System.Drawing.Point(534, 247);
            this.tbArmureBase.Name = "tbArmureBase";
            this.tbArmureBase.Size = new System.Drawing.Size(100, 20);
            this.tbArmureBase.TabIndex = 49;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(474, 250);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(67, 13);
            this.label18.TabIndex = 48;
            this.label18.Text = "Armure Base";
            // 
            // tbRatioInt
            // 
            this.tbRatioInt.Location = new System.Drawing.Point(535, 221);
            this.tbRatioInt.Name = "tbRatioInt";
            this.tbRatioInt.Size = new System.Drawing.Size(100, 20);
            this.tbRatioInt.TabIndex = 47;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(481, 224);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(47, 13);
            this.label19.TabIndex = 46;
            this.label19.Text = "Ratio Int";
            // 
            // tbNbMain
            // 
            this.tbNbMain.Location = new System.Drawing.Point(695, 326);
            this.tbNbMain.Name = "tbNbMain";
            this.tbNbMain.Size = new System.Drawing.Size(100, 20);
            this.tbNbMain.TabIndex = 68;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(639, 354);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 13);
            this.label17.TabIndex = 67;
            this.label17.Text = "porter max";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(639, 327);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(49, 13);
            this.label20.TabIndex = 66;
            this.label20.Text = "nb mains";
            // 
            // tbPorterMin
            // 
            this.tbPorterMin.Location = new System.Drawing.Point(534, 354);
            this.tbPorterMin.Name = "tbPorterMin";
            this.tbPorterMin.Size = new System.Drawing.Size(100, 20);
            this.tbPorterMin.TabIndex = 65;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(482, 354);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(53, 13);
            this.label21.TabIndex = 64;
            this.label21.Text = "porter min";
            // 
            // tbPSort
            // 
            this.tbPSort.Location = new System.Drawing.Point(534, 326);
            this.tbPSort.Name = "tbPSort";
            this.tbPSort.Size = new System.Drawing.Size(100, 20);
            this.tbPSort.TabIndex = 63;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(474, 327);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(52, 13);
            this.label22.TabIndex = 62;
            this.label22.Text = "Puiss sort";
            // 
            // tbPorterMax
            // 
            this.tbPorterMax.Location = new System.Drawing.Point(695, 354);
            this.tbPorterMax.Name = "tbPorterMax";
            this.tbPorterMax.Size = new System.Drawing.Size(100, 20);
            this.tbPorterMax.TabIndex = 69;
            // 
            // tbDurée
            // 
            this.tbDurée.Location = new System.Drawing.Point(534, 380);
            this.tbDurée.Name = "tbDurée";
            this.tbDurée.Size = new System.Drawing.Size(100, 20);
            this.tbDurée.TabIndex = 71;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(482, 380);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(34, 13);
            this.label23.TabIndex = 70;
            this.label23.Text = "durée";
            // 
            // IHMAddItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 452);
            this.Controls.Add(this.tbDurée);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.tbPorterMax);
            this.Controls.Add(this.tbNbMain);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.tbPorterMin);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.tbPSort);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.tbChanceCrit);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbBonusRM);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tbDegatsCrit);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.tbRMBase);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tbBonusArmure);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.tbArmureBase);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.tbRatioInt);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.tbRatioAg);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbBaseDommage);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbRatioF);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbDommage);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbPrix);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbTypeDee);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbPoid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbNBDee);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbItem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbEquip);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbExistant);
            this.Controls.Add(this.btnValider);
            this.Controls.Add(this.cbLootable);
            this.Controls.Add(this.tbDef);
            this.Controls.Add(this.lblDef);
            this.Controls.Add(this.tbNom);
            this.Controls.Add(this.lblNom);
            this.Controls.Add(this.listtype);
            this.Controls.Add(this.lbltype);
            this.Controls.Add(this.lblValues);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelAffichage);
            this.Name = "IHMAddItem";
            this.Text = "IHMAddItem";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbExistant;
        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.CheckBox cbLootable;
        private System.Windows.Forms.TextBox tbDef;
        private System.Windows.Forms.Label lblDef;
        private System.Windows.Forms.TextBox tbNom;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.ListBox listtype;
        private System.Windows.Forms.Label lbltype;
        private System.Windows.Forms.Label lblValues;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelAffichage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbEquip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbItem;
        private System.Windows.Forms.TextBox tbPoid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbNBDee;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbPrix;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbTypeDee;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbRatioAg;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbBaseDommage;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbRatioF;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbDommage;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbChanceCrit;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbBonusRM;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbDegatsCrit;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbRMBase;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbBonusArmure;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbArmureBase;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tbRatioInt;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tbNbMain;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox tbPorterMin;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox tbPSort;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox tbPorterMax;
        private System.Windows.Forms.TextBox tbDurée;
        private System.Windows.Forms.Label label23;
    }
}