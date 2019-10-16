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
    public partial class SelectRace : Form
    {
        GestionBDD conn;
        DataTable tRace;
        DataRow[] raceJouable;
        DataRow racePick;
        DataTable tSousRace;
        DataRow[] sousRaceJouable;
        DataRow sousRacePick;
        public SelectRace()
        {
            InitializeComponent();
            initialiseIHM();
        }



        public void initialiseIHM()
        {
            conn = new GestionBDD();
            tRace = conn.GetRaces();
            raceJouable = tRace.Select("jouable = TRUE");
            foreach(DataRow row in raceJouable)
            {
                cbRace.Items.Add(row["nom"].ToString());
            }
        }

        private void cbRace_SelectedIndexChanged(object sender, EventArgs e)
        {
            MiseAJourDescriptionEtSousRace(cbRace.SelectedItem.ToString());
        }


        private void MiseAJourDescriptionEtSousRace(String nom)
        {
            btnValider.Enabled = false;
            cbSousRace.Items.Clear();
            int id = 0; ;
            String description;
            foreach (DataRow row in raceJouable)
            {
                if( nom == row["nom"].ToString())
                {
                    id = Int32.Parse(row["id"].ToString());
                    description = row["definition"].ToString();
                    lbDescriptionRace.Text = description;
                    racePick = row;
                    break;
                }
            }
            tSousRace = conn.GetSousRaceByRaceId(id);
            sousRaceJouable = tSousRace.Select("jouable = TRUE");
 
            foreach (DataRow row in sousRaceJouable)
            {
                cbSousRace.Items.Add(row["nom"].ToString());
            }
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            
            SelectClass screen = new SelectClass(conn,racePick,sousRacePick);
            this.Hide();
            screen.ShowDialog();
            this.Close();
        }

        private void cbSousRace_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSousRace(cbSousRace.SelectedItem.ToString());
        }

        private void GetSousRace(String nom)
        {
            String description;
            foreach (DataRow row in sousRaceJouable)
            {
                if (nom == row["nom"].ToString())
                {
                    description = row["definition"].ToString();
                    lbDescriptionSousRace.Text = description;
                    sousRacePick = row;
                    btnValider.Enabled = true ;
                    break;
                }
            }
        }
    }
}
