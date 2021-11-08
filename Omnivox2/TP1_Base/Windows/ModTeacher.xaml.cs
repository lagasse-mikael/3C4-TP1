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
    /// Logique d'interaction pour ModTeacher.xaml
    /// </summary>
    public partial class ModTeacher : Window
    {
        private string searchBarContent;
        public ModTeacher()
        {
            InitializeComponent();
            InitAllTeachers();
        }

        private void InitAllTeachers(string keyword = "")
        {
            listeProf.Items.Clear();
            foreach (var teacher in App.Current.Teachers)
            {
                Teacher profTrouver;
                App.Current.Teachers.TryGetValue(teacher.Key, out profTrouver);

                if (profTrouver.FirstName.ToLower().Contains(keyword) || profTrouver.LastName.ToLower().Contains(keyword) || profTrouver.Id.ToString().Contains(keyword))
                {
                    string formatString = $"{profTrouver.Id} - {profTrouver.FirstName} {profTrouver.LastName}";

                    listeProf.Items.Add(formatString);
                }
            }
        }

        private void newInput(object sender, KeyEventArgs e)
        {
            searchBarContent = keywordSearch.Text.ToLower();
            InitAllTeachers(searchBarContent);
        }

        private void deleteTeacher_Click(object sender, RoutedEventArgs e)
        {
            int formatId = Convert.ToInt32(listeProf.SelectedItem.ToString().Split('-')[0].Trim());

            MessageBoxResult msgResult = MessageBox.Show($"Etes vous sure de vouloir supprimer le prof {listeProf.SelectedItem.ToString()} ? ", "", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (msgResult == MessageBoxResult.Yes)
            {
                MessageBoxResult deuxiemeConfirmation = MessageBox.Show($"Cette action est irreversible , etes-vous vraiment sure ? ", "", MessageBoxButton.YesNo, MessageBoxImage.Error);

                if (deuxiemeConfirmation == MessageBoxResult.Yes)
                {
                    App.Current.Teachers.Remove(formatId);

                    foreach (var cours in App.Current.Courses)
                    {
                        if (cours.TeacherId == formatId)
                        {
                            // Pas trop sure que deleter le cours au complet est logique.
                            cours.TeacherId = 0000;
                        }
                    }

                    MessageBox.Show($"Le prof {listeProf.SelectedItem.ToString()} a ete supprimer de partout!", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            InitAllTeachers();
        }

    }
}
