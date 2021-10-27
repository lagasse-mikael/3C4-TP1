using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace TP1_Base_Prof
{
    /// <summary>
    /// Logique d'interaction pour BetterOmnivox.xaml
    /// </summary>
    public partial class Connexion : Window
    {
        private Dictionary<int, Student> infos_etudiants = App.Current.Students;
        private bool isEtudiant = true;
        public Connexion()
        {
            InitializeComponent();
        }

        private void UserIdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Login(object sender, RoutedEventArgs e)
        {
            // Icitte
        }

        private void choixLogin_Click(object sender, RoutedEventArgs e)
        {
            Button btnCast = (Button)sender;

            if(btnCast.Name == "choixLoginEtudiant")
            {
                btnCast.Style = (Style)App.Current.Resources["ButtonStyle"];
                choixLoginProf.Style = (Style)App.Current.Resources["DarkButton"];
            }
            else
            {
                btnCast.Style = (Style)App.Current.Resources["ButtonStyle"];
                choixLoginEtudiant.Style = (Style)App.Current.Resources["DarkButton"];
            }


        }
    }
}
