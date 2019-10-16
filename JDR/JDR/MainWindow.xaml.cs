using JDR.BDD;
using JDR.CreationPerso;
using JDR.Outil;
using JDR.RemplireBDD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JDR
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            /* Connection conn =  Connection.GetConnection();
             DataTable race = conn.GetTable("race");
             DataRow[] rowsRace = race.Select();*/
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddStat screen = new AddStat();
            screen.ShowDialog();
        }

        private void NewPerso_Click(object sender, RoutedEventArgs e)
        {
            SelectRace screen = new SelectRace();
            this.Hide();
            screen.ShowDialog();
            this.Close();
        }
    }
}
