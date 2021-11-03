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
            string user = UserIdTextBox.Text;
            int userID;
            string password = UserPasswordTextBox.Text;

            Teacher possibleTeacher;
            Student possibleStudent;

            if(user == "admin" && password == "admin")
            {
                MessageBox.Show("ADMIN ADMIN");

                var windowAdmin = new Modifier();
                windowAdmin.Show();

                return;
            }

            try
            {
                userID = Convert.ToInt32(user);
            }
            catch(FormatException fe)
            {
                MessageBox.Show("met un id qui fait du sens");
                return;
            }

            if (isEtudiant)
            {
                if(App.Current.Students.TryGetValue(Convert.ToInt32(user),out possibleStudent) && possibleStudent.Password == password)
                {
                    MessageBox.Show("Bienvenue l'etudiant!");
                    // Omnivox en tant qu'etudiant
                }
                else
                {
                    MessageBox.Show("Mauvais mot de passe pour l'etudiant");
                }
            }
            else
            {
                if (App.Current.Teachers.TryGetValue(Convert.ToInt32(user), out possibleTeacher) && possibleTeacher.Password == password)
                {
                    MessageBox.Show("Bienvenue le prof!");
                    // Omnivox en tant que prof
                }
                else
                {
                    MessageBox.Show("Mauvais mot de passe pour le prof");
                }
            }
        }

        private void choixLogin_Click(object sender, RoutedEventArgs e)
        {
            Button btnCast = (Button)sender;

            if (btnCast.Name == "choixLoginEtudiant")
            {
                btnCast.Style = (Style)App.Current.Resources["ButtonStyleConnexion"];
                choixLoginProf.Style = (Style)App.Current.Resources["DarkButtonConnexion"];
                isEtudiant = true;
            }
            else
            {
                btnCast.Style = (Style)App.Current.Resources["ButtonStyleConnexion"];
                choixLoginEtudiant.Style = (Style)App.Current.Resources["DarkButtonConnexion"];
                isEtudiant = false;
            }


        }
    }
}
