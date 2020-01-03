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
    public partial class SelectHistoire : Form
    {
        GestionBDD conn;
        DataRow race;
        DataRow sousRace;
        DataRow classe;
        public SelectHistoire(GestionBDD conn, DataRow race, DataRow sousRace , DataRow classe )
        {
            this.conn = conn;
            this.race = race;
            this.sousRace = sousRace;
            this.classe = classe;
            InitializeComponent();
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            CréationPerso();
        }

        private void CréationPerso()
        {
            int idRace;
            int idSousRace;
            int idClasse;
            String nom;
            String prenom;
            String description;
            Int32.TryParse(race["id"].ToString(), out idRace);
            Int32.TryParse(sousRace["id"].ToString(), out idSousRace);
            Int32.TryParse(classe["id"].ToString(), out idClasse);
            nom = tbNom.Text;
            prenom = tbPrenom.Text;
            description = tbDesc.Text;
            if (nom != null && nom != "" && prenom != null && prenom != "" && description != null && description != "")
            {

                CreationPerso creatNewPerso = new CreationPerso();
                int idPerso = creatNewPerso.CreatNewPerso(idRace, idClasse, idSousRace, 0,nom,prenom,description);
            }
            else
            {
                // message d'érreur;
            }
        }

    }
}
