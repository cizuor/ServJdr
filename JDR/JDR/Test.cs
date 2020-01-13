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

namespace JDR
{
    public partial class Test : Form
    {
        private GestionBDD bdd;
        private Perso perso1;
        private Perso perso2;
        private Terrain terrain;

        public Test()
        {
            InitializeComponent();
            bdd = new GestionBDD();
            DataTable tPerso = bdd.GetPersos();
            DataRow[] persos = tPerso.Select();

            foreach (DataRow row in persos)
            {
                listBoxPerso1.Items.Add(row["id"].ToString() + ":" + row["Nom"].ToString());
                listBoxPerso2.Items.Add(row["id"].ToString() + ":" + row["Nom"].ToString());
            }
            DataTable tItem = bdd.GetItems();
            DataRow[] items = tItem.Select();

            foreach (DataRow row in items)
            {
                listBoxItem.Items.Add(row["id"].ToString() + ":" + row["Nom"].ToString());
            }
        }



        private void listBoxPerso1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selected = listBoxPerso1.SelectedItem.ToString();
            String[] id = selected.Split(':');
            perso1 = new Perso(Int32.Parse(id[0]));
            ActualiseInventaire();
            labelPV1.Text = perso1.listStat[(int)Stat.stats.PV].GetValue().ToString();
            if(perso2 != null)
            {
                PreparationCombat();
            }
        }

        private void listBoxPerso2_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selected = listBoxPerso2.SelectedItem.ToString();
            String[] id = selected.Split(':');
            perso2 = new Perso(Int32.Parse(id[0]));
            ActualiseInventaire();
            labelPV2.Text = perso2.listStat[(int)Stat.stats.PV].GetValue().ToString();
            if (perso1 != null)
            {
                PreparationCombat();
            }
        }

        private void PreparationCombat()
        {
            terrain = new Terrain();
            terrain.AddPerso(perso1, 0, 0, 0, false);
            terrain.AddPerso(perso2, 10, 10, 1, false);
            listBoxPerso1.Enabled = false;
            listBoxPerso2.Enabled = false;
            btnAttaque1.Enabled = false;
            btnAttaque2.Enabled = false;
            GestionCombat();
            ActualiseIHM();
        }

        private void GestionCombat()
        {
            Perso p = terrain.NextToPlay();
            if(p.id == perso1.id)
            {
                perso1 = p;
                btnAttaque1.Enabled = true;
                btnAttaque2.Enabled = false;
                btnAddMove1.Enabled = true;
                btnAddMove2.Enabled = false;
                btnMove1.Enabled = true;
                btnMove2.Enabled = false;
                textBoxX.Text = perso1.positionX.ToString();
                textBoxY.Text = perso1.positionY.ToString();
                perso1.NewTour();
            }
            else
            {
                perso2 = p;
                btnAttaque1.Enabled = false;
                btnAttaque2.Enabled = true;
                btnAddMove1.Enabled = false;
                btnAddMove2.Enabled = true;
                btnMove1.Enabled = false;
                btnMove2.Enabled = true;
                textBoxX.Text = perso2.positionX.ToString();
                textBoxY.Text = perso2.positionY.ToString();
                perso2.NewTour();
            }
        }

        private void ActualiseInventaire()
        {
            listBoxInventaire1.Items.Clear();
            listBoxInventaire2.Items.Clear();
            try
            {
                DataTable tinv = bdd.GetObjetPersoByID(perso1.id);
                DataRow[] inv = tinv.Select();

                foreach (DataRow row in inv)
                {
                    listBoxInventaire1.Items.Add(row["id"].ToString() + ":" + row["Nom"].ToString());
                }
            }
            catch (Exception ex) // cas ou il n'y a rien 
            {

            }
            try
            {
                DataTable tinv = bdd.GetObjetPersoByID(perso2.id);
                DataRow[] inv = tinv.Select();

                foreach (DataRow row in inv)
                {
                    listBoxInventaire2.Items.Add(row["id"].ToString() + ":" + row["Nom"].ToString());
                }
            }
            catch (Exception ex) // cas ou il n'y a rien 
            {

            }
        }
        private void ActualiseIHM()
        {
            if (perso1 != null)
            {
                labelPos1.Text = perso1.positionX + " : " + perso1.positionY;
                labelPA1.Text = "PA:"+(perso1.PARestant / 100).ToString();
                labelPM1.Text = "PM:"+(perso1.MouvementRestant).ToString();
            }
            if (perso2 != null)
            {
                labelPos2.Text = perso2.positionX + " : " + perso2.positionY;
                labelPA2.Text = "PA:"+(perso2.PARestant / 100).ToString();
                labelPM2.Text = "PM:"+(perso2.MouvementRestant).ToString();
            }
        }


        private void btnloot1_Click(object sender, EventArgs e)
        {
            String selected = listBoxItem.SelectedItem.ToString();
            String[] id = selected.Split(':');
            int type;
            Items item = Items.GetItems(Int32.Parse(id[0]), out type);
            if (perso1.Ramasser(item))
            {
                ActualiseInventaire();
            }
        }

        private void btnloot2_Click(object sender, EventArgs e)
        {
            String selected = listBoxItem.SelectedItem.ToString();
            String[] id = selected.Split(':');
            int type;
            Items item = Items.GetItems(Int32.Parse(id[0]), out type);
            if (perso2.Ramasser(item))
            {
                ActualiseInventaire();
            }
        }

        private void btnequip1_Click(object sender, EventArgs e)
        {
            String selected = listBoxInventaire1.SelectedItem.ToString();
            String[] id = selected.Split(':');
            int type;
            Items item = Items.GetItems(Int32.Parse(id[0]), out type);
            if (type == (int)Genre.TypeObjet.Arme || type == (int)Genre.TypeObjet.Armure)
            {
                if (perso1.Equipe((Equipement)item))
                {
                }
            }
            ActualiseIHM();
        }

        private void btnequip2_Click(object sender, EventArgs e)
        {
            String selected = listBoxInventaire2.SelectedItem.ToString();
            String[] id = selected.Split(':');
            int type;
            Items item = Items.GetItems(Int32.Parse(id[0]), out type);
            if (type == (int)Genre.TypeObjet.Arme || type == (int)Genre.TypeObjet.Armure)
            {
                if (perso2.Equipe((Equipement)item))
                {
                }
            }
            ActualiseIHM();
        }

        private void btnDesequipe1_Click(object sender, EventArgs e)
        {

            String selected = listBoxInventaire1.SelectedItem.ToString();
            String[] id = selected.Split(':');
            int type;
            Items item = Items.GetItems(Int32.Parse(id[0]), out type);
            if (type == (int)Genre.TypeObjet.Arme)
            {
                if (perso1.UnEquipe((Equipement)item))
                {
                }
            }
            ActualiseIHM();
        }

        private void btnDesequipe2_Click(object sender, EventArgs e)
        {
            String selected = listBoxInventaire2.SelectedItem.ToString();
            String[] id = selected.Split(':');
            int type;
            Items item = Items.GetItems(Int32.Parse(id[0]), out type);
            if (type == (int)Genre.TypeObjet.Arme)
            {
                if (perso2.UnEquipe((Equipement)item))
                {
                }
            }
            ActualiseIHM();
        }

        private void btnAttaque1_Click(object sender, EventArgs e)
        {

            List<ResultatAttaque> result = perso1.Attaque(perso2);
            Message(result);
            labelPV2.Text = perso2.PVActuelle.ToString();
            ActualiseIHM();
        }

        private void btnAttaque2_Click(object sender, EventArgs e)
        {
            List<ResultatAttaque> result = perso2.Attaque(perso1);
            Message(result);
            labelPV1.Text = perso1.PVActuelle.ToString();
            ActualiseIHM();
        }


        private void Message(List<ResultatAttaque> listResult)
        {
            String message = "";
            foreach (ResultatAttaque result in listResult)
            {
                if (result.erreur == null)
                {
                    if (result.reussite)
                    {
                        message += " toucher avec :" + result.resultat + " sur :" + result.chanceToucher + " \n";
                        if (result.reussiteCrit)
                        {
                            message += " critique avec :" + result.resultatCrit + " sur :" + result.chanceCrit + " \n";
                        }
                        message += " dégat :" + result.degats + " dégats subit par l'énemie : " + result.degatSubit;
                    }
                    else
                    {
                        message += " echec ";
                    }
                }
                else
                {
                    message += result.erreur;

                }
            }
            
            labelattaque.Text = message;
        }

        private void btnMove1_Click(object sender, EventArgs e)
        {
            int x;
            int y;
            if(Int32.TryParse(textBoxX.Text.ToString(),out x))
            {
                if(Int32.TryParse(textBoxY.Text.ToString(), out y))
                {
                    if (perso1.Deplacement(x, y))
                    {
                    }
                }
            }
            ActualiseIHM();

        }

        private void btnMove2_Click(object sender, EventArgs e)
        {
            int x;
            int y;
            if (Int32.TryParse(textBoxX.Text.ToString(), out x))
            {
                if (Int32.TryParse(textBoxY.Text.ToString(), out y))
                {
                    if (perso2.Deplacement(x, y))
                    {
                    }
                }
            }
            ActualiseIHM();
        }

        private void btnAddMove1_Click(object sender, EventArgs e)
        {
            if (!perso1.AddMove())
            {
                labelattaque.Text = "PA insufisant";
            }
            ActualiseIHM();
        }

        private void btnAddMove2_Click(object sender, EventArgs e)
        {
            if (!perso2.AddMove())
            {
                labelattaque.Text = "PA insufisant";
            }
            ActualiseIHM();
        }

        private void btnFinTour_Click(object sender, EventArgs e)
        {
            GestionCombat();
            ActualiseIHM();
        }
    }
}
