using JDR.BDD;
using JDR.Model.Objet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDR.RemplireBDD
{
    public partial class IHMAddItem : Form
    {
        GestionBDD conn;
        private SortedList<int, TextBox> listTextBox;
        private int positionX = 20;// position en X
        private int positionY = 40; // position en Y
        private Boolean isNew = true; // sert a savoir si on doi crée une ligne pour l'objet ou juste la mettre a jour
        private DataRow[] rowTable;
        private int id;
        private String type;
        public IHMAddItem()
        {
            InitializeComponent();
            conn = new GestionBDD();
            SetupUI();
        }

        public void SetupUI()
        {
            listTextBox = new SortedList<int, TextBox>();
            // getStatRace 
            DataTable tStat = conn.GetStat();
            DataRow[] drStat = tStat.Select();

            foreach (DataRow stat in drStat)
            {
                Label labelStat = null;
                Label labelStatDetail = null;
                labelStat = AddLabel(stat["nom"].ToString(), 100, 20, 0);
                panelAffichage.Controls.Add(labelStat);
                positionX = positionX + 150;
                labelStatDetail = AddLabel(stat["definition"].ToString(), 100, 20, 0);
                panelAffichage.Controls.Add(labelStatDetail);
                positionX = positionX + 150;
                TextBox tbNewRef = AddTextBox(100, 20, 0);
                panelAffichage.Controls.Add(tbNewRef);
                positionY = positionY + 30;
                positionX -= 300;
                listTextBox.Add(Int32.Parse(stat["id"].ToString()), tbNewRef);
            }

            cbItem.Items.Add(Genre.TypeObjet.Arme);
            cbItem.Items.Add(Genre.TypeObjet.Armure);
            cbItem.Items.Add(Genre.TypeObjet.Composant);
            cbItem.Items.Add(Genre.TypeObjet.Consommable);
            cbItem.Items.Add(Genre.TypeObjet.Utilitaire);

        }


        /// <summary>
        ///  renvoi un label adapté
        /// </summary>
        /// <param name="nom"> text du label </param>
        /// <param name="start"> position en X du label </param>
        /// <param name="end"> position en Y du label </param>
        /// <param name="width"> taille en X du label </param>
        /// <param name="height"> taille en Y du label </param>
        /// <param name="left"> décalage a gauche</param>
        /// <returns></returns>
        private Label AddLabel(string nom, int width, int height, int left)
        {
            Label l = new Label
            {
                Text = nom,
                ForeColor = Color.Black,
                BackColor = Color.White,
                Font = new Font("Serif", 8, FontStyle.Regular),
                Width = width,
                Height = height,
                Left = left,
                Location = new Point(positionX, positionY),
                TextAlign = ContentAlignment.MiddleCenter,
                Margin = new Padding(5)
            };

            return l;
        }

        /// <summary>
        /// renvoi une textbox adapté
        /// </summary>
        /// <param name="start"> position en X de la text box </param>
        /// <param name="end"> position en Y de la text box </param>
        /// <param name="width"> taille en X de la text box </param>
        /// <param name="height"> taille en Y de la text box </param>
        /// <param name="left"> décalage a gauche</param>
        /// <returns></returns>
        private TextBox AddTextBox(int width, int height, int left)
        {
            TextBox t = new TextBox
            {
                ForeColor = Color.Black,
                BackColor = Color.White,
                Font = new Font("Serif", 8, FontStyle.Regular),
                Width = width,
                Height = height,
                Left = left,
                Location = new Point(positionX, positionY),
                Margin = new Padding(5)
            };

            return t;
        }

        private void cbExistant_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selected = cbExistant.SelectedItem.ToString();
            if (selected != "nouveau")
            {
                foreach (DataRow item in rowTable)
                {
                    if (item["id"].ToString() + " : " + item["nom"].ToString() == selected)
                    {
                        id = Int32.Parse(item["id"].ToString());
                        tbNom.Text = item["nom"].ToString();
                        tbDef.Text = item["definition"].ToString();
                        tbTypeDee.Text = item["typedee"].ToString();
                        tbNBDee.Text = item["nbdee"].ToString();
                        tbPoid.Text = item["poid"].ToString();
                        tbPrix.Text = item["prix"].ToString();
                        tbDommage.Text = item["dommage"].ToString();
                        tbBaseDommage.Text = item["basedommage"].ToString();
                        tbRatioF.Text = item["ratiof"].ToString();
                        tbRatioAg.Text = item["ratioag"].ToString();
                        tbRatioInt.Text = item["ratioint"].ToString();
                        tbArmureBase.Text = item["armurebase"].ToString();
                        tbRMBase.Text = item["rmbase"].ToString();
                        tbBonusArmure.Text = item["armurebonus"].ToString();
                        tbBonusRM.Text = item["rmbonus"].ToString();
                        tbDegatsCrit.Text = item["dcrit"].ToString();
                        tbPSort.Text = item["psort"].ToString();
                        tbDurée.Text = item["duree"].ToString();
                        tbChanceCrit.Text = item["chanccrit"].ToString();
                        int typeitem = Int32.Parse(item["type"].ToString());

                        if (type == "genre")
                        {
                            cbLootable.Checked = Boolean.Parse(item["loot"].ToString());
                            tbNbMain.Text = item["nbmains"].ToString();
                            tbPorterMin.Text = item["portermin"].ToString();
                            tbPorterMax.Text = item["portermax"].ToString();
                        }
                        SetAllStat();
                    }
                }
            }
            else
            {
                id = -1;
            }
        }











        private void SetAllStat()
        {

            foreach (TextBox tb in listTextBox.Values)
            {
                tb.Text = "0";
            }
            DataTable tTable = null;
            switch (type)
            {
                case "genre":
                    tTable = conn.GetStatGenreByID(id);
                    break;
                case "materiel":
                    tTable = conn.GetStatMaterielByID(id);
                    break;
                case "qualite":
                    tTable = conn.GetStatQualiteByID(id);
                    break;
                default:

                    break;
            }

            DataRow[] rowStats = tTable.Select();
            foreach (DataRow item in rowStats)
            {
                listTextBox[Int32.Parse(item["id_stat"].ToString())].Text = item["valeur"].ToString();
            }

        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            String type = listtype.SelectedItem.ToString();



            //INSERT INTO ___.% s("RECNO", "NO", "COORD_X", "COORD_Y", "ADRESSE", "COMMUNE", "HEXACODE") VALUES(outilsql.nextrecno(\'%s\'::text,\'%s\'::text),no,\'0\',\'0\',\' \',\' \',\' \'); ', invue, schema, invue);
            if (id == -1)
            {
                DataTable ttype = null;
                switch (type)
                {
                    case "genre":
                        ttype = conn.GetGenre();
                        break;
                    case "materiel":
                        ttype = conn.GetMateriel();
                        break;
                    case "qualite":
                        ttype = conn.GetQualite();
                        break;
                    default:

                        break;
                }
                DataRow[] drtype = ttype.Select(null, "id DESC");
                int id = Int32.Parse(drtype[0]["id"].ToString());
                id++;
                DataRow item = ttype.NewRow();

                item["id"] = id;
                item["nom"] = tbNom.Text;
                item["definition"] = tbDef.Text;
                item["typedee"]= tbTypeDee.Text;
                item["nbdee"] = tbNBDee.Text;
                item["poid"]  = tbPoid.Text;
                item["prix"] = tbPrix.Text;
                item["dommage"] = tbDommage.Text;
                item["basedommage"]= tbBaseDommage.Text;
                item["ratiof"] = tbRatioF.Text;
                item["ratioag"] = tbRatioAg.Text;
                item["ratioint"]  = tbRatioInt.Text;
                item["armurebase"] = tbArmureBase.Text;
                item["rmbase"] = tbRMBase.Text;
                item["armurebonus"] = tbBonusArmure.Text;
                item["rmbonus"] = tbBonusRM.Text;
                item["dcrit"] = tbDegatsCrit.Text;
                item["psort"] = tbPSort.Text;
                item["duree"] = tbDurée.Text;
                item["chanccrit"] = tbChanceCrit.Text;
                if (type == "genre")
                {
                    item["loot"] = cbLootable.Checked;
                    item["nbmains"] = tbNbMain.Text;
                    item["portermin"] = tbPorterMin.Text;
                    item["portermax"] = tbPorterMax.Text;
                }

                ttype.Rows.Add(item);
                conn.SubmitDataSetChanges(type);
                foreach (int idStat in listTextBox.Keys)
                {
                    if (listTextBox[idStat].Text != null && listTextBox[idStat].Text != "")
                    {
                        int value = 0;
                        Int32.TryParse(listTextBox[idStat].Text, out value);
                        if (value != 0)
                        {
                            String sqlInsertStat = "insert into bdd.stat" + type + " ( id_stat , id_" + type + " , valeur ) VALUES  ( " + idStat + " , " + id + " , " + value + ") ";
                            conn.ExecuteQuery("stat" + type, sqlInsertStat);
                        }
                    }
                }
                
            }
            else
            {
                DataTable ttype = null;
                switch (type)
                {
                    case "genre":
                        ttype = conn.GetGenre();
                        break;
                    case "materiel":
                        ttype = conn.GetMateriel();
                        break;
                    case "qualite":
                        ttype = conn.GetQualite();
                        break;
                    default:

                        break;
                }
                DataRow[] rows = ttype.Select("id = "+id);
                DataRow item = rows[0];

                item["id"] = id;
                item["nom"] = tbNom.Text;
                item["definition"] = tbDef.Text;
                item["typedee"] = tbTypeDee.Text;
                item["nbdee"] = tbNBDee.Text;
                item["poid"] = tbPoid.Text;
                item["prix"] = tbPrix.Text;
                item["dommage"] = tbDommage.Text;
                item["basedommage"] = tbBaseDommage.Text;
                item["ratiof"] = tbRatioF.Text;
                item["ratioag"] = tbRatioAg.Text;
                item["ratioint"] = tbRatioInt.Text;
                item["armurebase"] = tbArmureBase.Text;
                item["rmbase"] = tbRMBase.Text;
                item["armurebonus"] = tbBonusArmure.Text;
                item["rmbonus"] = tbBonusRM.Text;
                item["dcrit"] = tbDegatsCrit.Text;
                item["psort"] = tbPSort.Text;
                item["duree"] = tbDurée.Text;
                item["chanccrit"] = tbChanceCrit.Text;
                if (type == "genre")
                {
                    item["loot"] = cbLootable.Checked;
                    item["nbmains"] = tbNbMain.Text;
                    item["portermin"] = tbPorterMin.Text;
                    item["portermax"] = tbPorterMax.Text;
                }
                conn.SubmitDataSetChanges(type);
                String sqlDelete = "delete from bdd.stat" + type + " where id_"+type+" = " + id;
                if (conn.ExecuteQuery(type, sqlDelete))
                {
                    foreach (int idStat in listTextBox.Keys)
                    {
                        if (listTextBox[idStat].Text != null && listTextBox[idStat].Text != "")
                        {
                            int value = 0;
                            Int32.TryParse(listTextBox[idStat].Text, out value);
                            if (value != 0)
                            {
                                String sqlInsertStat = "insert into bdd.stat" + type + " ( id_stat , id_" + type + " , valeur ) VALUES  ( " + idStat + " , " + id + " , " + value + ") ";
                                conn.ExecuteQuery("stat" + type, sqlInsertStat);
                            }
                        }
                    }
                }
                
            }
        }

        private void listtype_SelectedIndexChanged(object sender, EventArgs e)
        {

            type = listtype.SelectedItem.ToString();
            cbExistant.Items.Clear();
            cbExistant.Items.Add("nouveau");
            DataTable ttype = null;
            switch (type)
            {
                case "genre":
                    ttype = conn.GetGenre();
                    break;
                case "materiel":
                    ttype = conn.GetMateriel();
                    break;
                case "qualite":
                    ttype = conn.GetQualite();
                    break;
                default:

                    break;
            }
            rowTable = ttype.Select();
            foreach (DataRow item in rowTable)
            {
                cbExistant.Items.Add(item["id"].ToString() + " : " + item["nom"].ToString());
            }
            
        }
    }
}
