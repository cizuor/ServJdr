using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDR.RemplireBDD
{
    public partial class AddRace : Form
    {
        public AddRace()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getCSV();
        }


        private void getCSV()
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                InitialDirectory = Environment.CurrentDirectory,
                Filter = "Fichier csv|*.csv;dedale"
            };

            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                string chemin = ofd.FileName;
                ouvrireCSV(chemin);
            }
        }


        private void ouvrireCSV(String chemin)
        {
            if (File.Exists(chemin))
            {
                FileStream fs = null;
                StreamReader sr = null;
                try
                {
                    fs = new FileStream(chemin, FileMode.Open, FileAccess.Read);
                    sr = new StreamReader(fs);
                    if (fs != null && sr != null)
                    {
                        GestionDonneCsv(sr,chemin);
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }


        private void GestionDonneCsv(StreamReader sr,String chemin)
        {
            Racetmp racetmp = new Racetmp();
            String[] nom = chemin.Split('.');
            nom = nom[0].Split('\\');
            try
            {
                racetmp.nom = nom[nom.Length-1];
                string ligne = sr.ReadLine();
                String[] info = ligne.Split(';');
                racetmp.taille = Int32.Parse(info[10]);
                racetmp.nbdtaille = Int32.Parse(info[11]);
                racetmp.typeDtaille = Int32.Parse(info[12]);
                if (info[15] == "Jouable")
                {
                    racetmp.jouable = true;
                }
                else
                {
                    racetmp.jouable = false;
                }

                ligne = sr.ReadLine();
                info = ligne.Split(';');
                racetmp.CC = Int32.Parse(info[1]);
                racetmp.nbdCC = Int32.Parse(info[2]);
                racetmp.typeDCC = Int32.Parse(info[3]);

                racetmp.poid = Int32.Parse(info[10]);
                racetmp.nbdpoid = Int32.Parse(info[11]);
                racetmp.typeDpoid = Int32.Parse(info[12]);

                ligne = sr.ReadLine();
                info = ligne.Split(';');
                racetmp.CT = Int32.Parse(info[1]);
                racetmp.nbdCT = Int32.Parse(info[2]);
                racetmp.typeDCT = Int32.Parse(info[3]);

                racetmp.Age = Int32.Parse(info[10]);
                racetmp.nbdAge = Int32.Parse(info[11]);
                racetmp.typeDAge = Int32.Parse(info[12]);

                ligne = sr.ReadLine();
                info = ligne.Split(';');
                racetmp.Ag = Int32.Parse(info[1]);
                racetmp.nbdAg = Int32.Parse(info[2]);
                racetmp.typeDAg = Int32.Parse(info[3]);

                racetmp.Mouvement = Int32.Parse(info[10]);
                racetmp.nbdMouvement = 0;
                racetmp.typeDMouvement = 0;


                ligne = sr.ReadLine();
                info = ligne.Split(';');
                racetmp.F = Int32.Parse(info[1]);
                racetmp.nbdF = Int32.Parse(info[2]);
                racetmp.typeDF = Int32.Parse(info[3]);

                ligne = sr.ReadLine();
                info = ligne.Split(';');
                racetmp.E = Int32.Parse(info[1]);
                racetmp.nbdE = Int32.Parse(info[2]);
                racetmp.typeDE = Int32.Parse(info[3]);

                ligne = sr.ReadLine();
                info = ligne.Split(';');
                racetmp.At = Int32.Parse(info[1]);
                racetmp.nbdAt = Int32.Parse(info[2]);
                racetmp.typeDAt = Int32.Parse(info[3]);

                ligne = sr.ReadLine();
                info = ligne.Split(';');
                racetmp.Int = Int32.Parse(info[1]);
                racetmp.nbdInt = Int32.Parse(info[2]);
                racetmp.typeDInt = Int32.Parse(info[3]);

                ligne = sr.ReadLine();
                info = ligne.Split(';');
                racetmp.FM = Int32.Parse(info[1]);
                racetmp.nbdFM = Int32.Parse(info[2]);
                racetmp.typeDFM = Int32.Parse(info[3]);

                ligne = sr.ReadLine();
                info = ligne.Split(';');
                racetmp.Magie = Int32.Parse(info[1]);
                racetmp.nbdMagie = Int32.Parse(info[2]);
                racetmp.typeDMagie = Int32.Parse(info[3]);

                ligne = sr.ReadLine();
                info = ligne.Split(';');
                racetmp.P = Int32.Parse(info[1]);
                racetmp.nbdP = Int32.Parse(info[2]);
                racetmp.typeDP = Int32.Parse(info[3]);

                ligne = sr.ReadLine();
                info = ligne.Split(';');
                racetmp.Soc = Int32.Parse(info[1]);
                racetmp.nbdSoc = Int32.Parse(info[2]);
                racetmp.typeDSoc = Int32.Parse(info[3]);

                ligne = sr.ReadLine();
                info = ligne.Split(';');
                racetmp.PV = Int32.Parse(info[1]);
                racetmp.nbdPV = Int32.Parse(info[2]);
                racetmp.typeDPV = Int32.Parse(info[3]);

                ligne = sr.ReadLine();
                info = ligne.Split(';');
                racetmp.CA = Int32.Parse(info[1]);
                racetmp.nbdCA = Int32.Parse(info[2]);
                racetmp.typeDCA = Int32.Parse(info[3]);

                ligne = sr.ReadLine();
                info = ligne.Split(';');
                racetmp.CD = Int32.Parse(info[1]);
                racetmp.nbdCD = Int32.Parse(info[2]);
                racetmp.typeDCD = Int32.Parse(info[3]);

                ligne = sr.ReadLine();
                info = ligne.Split(';');
                racetmp.Armure = Int32.Parse(info[1]);
                racetmp.nbdArmure = Int32.Parse(info[2]);
                racetmp.typeDArmure = Int32.Parse(info[3]);

                ligne = sr.ReadLine();
                info = ligne.Split(';');
                racetmp.RM = Int32.Parse(info[1]);
                racetmp.nbdRM = Int32.Parse(info[2]);
                racetmp.typeDRM = Int32.Parse(info[3]);

                ligne = sr.ReadLine();
                info = ligne.Split(';');
                racetmp.Crit = 50;
                racetmp.nbdCrit = 0;
                racetmp.typeDCrit = 0;

                ligne = sr.ReadLine();
                info = ligne.Split(';');
                //regen

                ligne = sr.ReadLine();
                info = ligne.Split(';');
                racetmp.Dos = 0;
                racetmp.nbdDos = 0;
                racetmp.typeDDos = 0;

                ligne = sr.ReadLine();
                info = ligne.Split(';');
                racetmp.PS = Int32.Parse(info[1]);
                racetmp.nbdPS = Int32.Parse(info[2]);
                racetmp.typeDPS = Int32.Parse(info[3]);

                ligne = sr.ReadLine();
                info = ligne.Split(';');
                racetmp.Resistance_echo = Int32.Parse(info[1]);
                racetmp.nbdResistance_echo = Int32.Parse(info[2]);
                racetmp.typeDResistance_echo = Int32.Parse(info[3]);

                ligne = sr.ReadLine();
                info = ligne.Split(';');
                racetmp.Dégâts = Int32.Parse(info[1]);
                racetmp.nbdDégâts = Int32.Parse(info[2]);
                racetmp.typeDDégâts = Int32.Parse(info[3]);

            }
            catch (Exception ex)
            {

            }
        }




        private class Racetmp
        {
            public String nom;
            public Boolean jouable;
            public int Mouvement;
            public int CC;
            public int CT;
            public int Ag;
            public int F;
            public int E;
            public int At;
            public int Int;
            public int FM;
            public int Magie;
            public int P;
            public int Soc;
            public int PV;
            public int CA;
            public int CD;
            public int Armure;
            public int RM;
            public int Crit;
            public int Regen;
            public int Dos;
            public int PS;
            public int Resistance_echo;
            public int Dégâts;
            public int taille;
            public int poid;
            public int Age;

            public int nbdMouvement;
            public int nbdCC;
            public int nbdCT;
            public int nbdAg;
            public int nbdF;
            public int nbdE;
            public int nbdAt;
            public int nbdInt;
            public int nbdFM;
            public int nbdMagie;
            public int nbdP;
            public int nbdSoc;
            public int nbdPV;
            public int nbdCA;
            public int nbdCD;
            public int nbdArmure;
            public int nbdRM;
            public int nbdCrit;
            public int nbdRegen;
            public int nbdDos;
            public int nbdPS;
            public int nbdResistance_echo;
            public int nbdDégâts;
            public int nbdtaille;
            public int nbdpoid;
            public int nbdAge;


            public int typeDMouvement;
            public int typeDCC;
            public int typeDCT;
            public int typeDAg;
            public int typeDF;
            public int typeDE;
            public int typeDAt;
            public int typeDInt;
            public int typeDFM;
            public int typeDMagie;
            public int typeDP;
            public int typeDSoc;
            public int typeDPV;
            public int typeDCA;
            public int typeDCD;
            public int typeDArmure;
            public int typeDRM;
            public int typeDCrit;
            public int typeDRegen;
            public int typeDDos;
            public int typeDPS;
            public int typeDResistance_echo;
            public int typeDDégâts;
            public int typeDtaille;
            public int typeDpoid;
            public int typeDAge;




        }

    }
}
