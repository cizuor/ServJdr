using JDR.BDD;
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
    public partial class IHMAddRace : Form
    {
        GestionBDD conn;
        private SortedList<int, TextBox> listTextBox;
        private int positionX = 20;// position en X
        private int positionY = 40; // position en Y
        private Boolean isNew = true; // sert a savoir si on doi crée une ligne pour l'objet ou juste la mettre a jour
        private DataRow[] rowTable;
        private int id;
        private String type;
        public IHMAddRace()
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
        private TextBox AddTextBox( int width, int height, int left)
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

        private void btnValider_Click(object sender, EventArgs e)
        {
            String type = listtype.SelectedItem.ToString();
            String nom = tbNom.Text;
            String definition = tbDef.Text;
            Boolean Jouable = cbJouable.Checked;
            Boolean Domptable = cbDomptable.Checked;

           

            //INSERT INTO ___.% s("RECNO", "NO", "COORD_X", "COORD_Y", "ADRESSE", "COMMUNE", "HEXACODE") VALUES(outilsql.nextrecno(\'%s\'::text,\'%s\'::text),no,\'0\',\'0\',\' \',\' \',\' \'); ', invue, schema, invue);
            if (id == -1)
            {
                DataTable ttype = null ;
                switch (type)
                {
                    case "race":
                        ttype = conn.GetRaces();
                        break;
                    case "sousrace":
                        ttype = conn.GetSousRaces();
                        break;
                    case "classe":
                        ttype = conn.GetClasses();
                        break;
                    default:
                        break;
                }
                DataRow[] drtype = ttype.Select(null, "id DESC");
                int id = Int32.Parse(drtype[0]["id"].ToString());
                id++;

                String sqlInsert = "insert into bdd."+ type + " ( id , nom , definition , jouable ) VALUES ( "+ id +" , '" + nom + "' , '" + definition + "' , " + Jouable + " ) ";
                
                if (conn.ExecuteQuery(type, sqlInsert)) {

                    foreach (int idStat in listTextBox.Keys)
                    {
                        if (listTextBox[idStat].Text != null && listTextBox[idStat].Text != "")
                        {
                            int value = 0;
                            Int32.TryParse(listTextBox[idStat].Text,out value);
                            if (value != 0)
                            {
                                String sqlInsertStat = "insert into bdd.stat" + type + " ( id_stat , id_" + type + " , valeur ) VALUES  ( " + idStat + " , " + id + " , " + value + ") ";
                                conn.ExecuteQuery("stat" + type, sqlInsertStat);
                            }
                        }
                    }
                }

                /*switch(type)
                {
                    case "race":
                    case "sousrace":
                        sqlInsert = sqlInsert + " domptable ";
                        Console.WriteLine("Case 1");
                        break;
                    case "classe":
                    default:
                        break;
                }*/
            }
            else
            {
                String sqlupdate = "update bdd." + type + " set  nom  = '" + nom + "', definition = '" + definition + "' , jouable = " + Jouable + " where id = " + id;
                if (conn.ExecuteQuery(type, sqlupdate))
                {
                    String sqlDelete = "delete from bdd.stat" + type + " where id = " + id;
                    if (conn.ExecuteQuery(type, sqlupdate))
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
                        cbJouable.Checked = Boolean.Parse(item["jouable"].ToString());
                        SetAllStat();
                    }
                }
            }
            else
            {
                id = -1;
            }
        }

        private void listtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            type = listtype.SelectedItem.ToString();
            cbExistant.Items.Clear();
            cbExistant.Items.Add("nouveau");
            DataTable tTable = null;
            switch (type)
            {
                case "race":
                    tTable = conn.GetRaces();
                    break;
                case "sousrace":
                    tTable = conn.GetSousRaces();
                    break;

                case "classe":
                    tTable = conn.GetClasses();
                    break;
                default:

                    break;
            }
            rowTable = tTable.Select();
            foreach (DataRow item in rowTable)
            {
                cbExistant.Items.Add(item["id"].ToString() + " : " + item["nom"].ToString());
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
                case "race":
                    tTable = conn.GetStatRaceByID(id);
                    break;
                case "sousrace":
                    tTable = conn.GetStatSousRaceByID(id);
                    break;
                case "classe":
                    tTable = conn.GetStatClasseByID(id);
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


    }
}
