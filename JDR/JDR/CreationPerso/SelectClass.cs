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

namespace JDR.CreationPerso
{
    public partial class SelectClass : Form
    {

        GestionBDD conn;
        DataRow race;
        DataRow sousRace;
        DataTable tClasse;
        DataRow[] classeJouables;
        DataRow classe;
        public SelectClass(GestionBDD conn, DataRow race , DataRow sousRace)
        {
            this.conn = conn;
            this.race = race;
            this.sousRace = sousRace;
            InitializeComponent();
            initialiseIHM();
        }


        private void initialiseIHM()
        {
            tClasse = conn.GetClasses();
            classeJouables = tClasse.Select("jouable = TRUE");
            foreach (DataRow row in classeJouables)
            {
                cbClasse.Items.Add(row["nom"].ToString());
            }
        }

        private void cbClasse_SelectedIndexChanged(object sender, EventArgs e)
        {
            MiseAJourDescription(cbClasse.SelectedItem.ToString());
        }


        private void MiseAJourDescription(String nom)
        {
            String description;
            foreach (DataRow row in classeJouables)
            {
                if (nom == row["nom"].ToString())
                {
                    description = row["definition"].ToString();
                    lbDescriptionClasse.Text = description;
                    classe = row;
                    btnValider.Enabled = true;
                    break;
                }
            }
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            SelectHistoire screen = new SelectHistoire(conn, race, sousRace,classe);
            this.Hide();
            screen.ShowDialog();
            this.Close();
        }
    }
}
