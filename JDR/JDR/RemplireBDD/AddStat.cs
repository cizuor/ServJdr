using JDR.BDD;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDR.RemplireBDD
{
    public partial class AddStat : Form
    {
        Connection conn;
        DataSet dsTable;
        NpgsqlDataAdapter daTable;
        DataTable table;
        DataSet dsJointure;
        NpgsqlDataAdapter daJointure;
        DataTable jointure;
        public AddStat()
        {
            InitializeComponent();
            cbTable.Items.Add("stat");
            cbTable.Items.Add("race");
            cbTable.Items.Add("classe");
            cbTable.Items.Add("sousrace");
            cbTable.Items.Add("zoneeffect");
            cbTable.Items.Add("perso");
            cbTable.Items.Add("arme");
            cbTable.Items.Add("genre");
            cbTable.Items.Add("materiel");
            cbTable.Items.Add("objet");
            cbTable.Items.Add("qualite");
            cbTable.Items.Add("comp");

            cbTableJointure.Items.Add("statcalculer");
            cbTableJointure.Items.Add("statclasse");
            cbTableJointure.Items.Add("statrace");
            cbTableJointure.Items.Add("statsousrace");
            cbTableJointure.Items.Add("statperso");
            cbTableJointure.Items.Add("sousracerace");
            cbTableJointure.Items.Add("objetperso");
            conn = Connection.GetConnection();

        }
        /// <summary>
        /// sauvegarde les donné de la table mis a jour
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnValider_Click(object sender, EventArgs e)
        {
            conn.SubmitDataSetChanges(daTable, dsTable);
        }
        /// <summary>
        /// affiche les donné de la table choisi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            table = conn.GetTable(cbTable.SelectedItem.ToString(), out dsTable, out daTable);
            this.bindingSourcetable.DataSource = table;

            this.dataGridViewTable.DataSource =
                this.bindingSourcetable;
            int i = 0;
            for (i = 0 ; i< dataGridViewTable.ColumnCount; i++)
            {
                dataGridViewTable.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        /// <summary>
        /// affiche les donné de la table jointure choisi   
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbTableJointure_SelectedIndexChanged(object sender, EventArgs e)
        {
            jointure = conn.GetTable(cbTableJointure.SelectedItem.ToString(), out dsJointure, out daJointure);
            this.bindingSourceJointure.DataSource = jointure;
            // Attach the BindingSource to the DataGridView.
            this.dataGridViewJointure.DataSource =
                this.bindingSourceJointure;
        }
        /// <summary>
        /// sauvegarde la table jointure 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnValiderJointure_Click(object sender, EventArgs e)
        {
            conn.SubmitDataSetChanges(daJointure, dsJointure);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IHMAddRace screen = new IHMAddRace();
            screen.ShowDialog();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            IHMAddItem screen = new IHMAddItem();
            screen.ShowDialog();
        }
    }
}
