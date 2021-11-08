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
    /// Logique d'interaction pour AddTeacher.xaml
    /// </summary>
    public partial class AddTeacher : Window
    {
        public AddTeacher()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void newProf_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int idProfNum = Convert.ToInt32(idProf.Text);

                MessageBoxResult msgResult = MessageBox.Show($"Voulez vous ajouter {prenomProf.Text} {nomProf.Text} comme prof ayant {idProfNum} comme ID ?", "", MessageBoxButton.YesNo, MessageBoxImage.Information);

                if (msgResult == MessageBoxResult.Yes)
                {
                    string defaultPass = $"{prenomProf.Text[0]}{nomProf.Text}".ToLower();

                    App.Current.Teachers.Add(idProfNum, new Teacher { Id = idProfNum, FirstName = prenomProf.Text, LastName = nomProf.Text, Password = defaultPass });
                    MessageBox.Show($"Le prof {prenomProf.Text} - {idProfNum} a ete enregistrer avec succees!");
                }
            }
            catch
            {
                MessageBox.Show("Veuillez entrer des informations coherentes!","",MessageBoxButton.OK);
            }
            this.Close();
        }
    }
}
