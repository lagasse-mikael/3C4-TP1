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
    /// Logique d'interaction pour AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        public AddStudent()
        {
            InitializeComponent();

        }

        private void newEtudiant_Window(object sender, RoutedEventArgs e)
        {
            try
            {
                int idEleveNum = Convert.ToInt32(idEleve.Text);

                MessageBoxResult msgResult = MessageBox.Show($"Voulez vous ajouter {prenomEleve.Text} {nomEleve.Text} comme eleve ayant {idEleveNum} comme ID ?", "", MessageBoxButton.YesNo, MessageBoxImage.Information);

                if (msgResult == MessageBoxResult.Yes)
                {
                    string defaultPass = $"{prenomEleve.Text[0]}{nomEleve.Text}".ToLower();

                    App.Current.Students.Add(idEleveNum, new Student { Id = idEleveNum, FirstName = prenomEleve.Text, LastName = nomEleve.Text, Password = defaultPass });
                    MessageBox.Show($"L'eleve {prenomEleve.Text} - {idEleveNum} a ete enregistrer avec succees!");
                }
            }
            catch
            {
                MessageBox.Show("Veuillez entrer des informations coherentes!", "", MessageBoxButton.OK);
            }
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
