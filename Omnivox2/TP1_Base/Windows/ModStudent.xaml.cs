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
    /// Logique d'interaction pour ModStudent.xaml
    /// </summary>
    public partial class ModStudent : Window
    {
        private string searchBarContent;
        public ModStudent()
        {
            InitializeComponent();
            InitAllStudent();
        }

        private void InitAllStudent(string keyword = "")
        {
            listeEtudiants.Items.Clear();
            foreach (var etudiant in App.Current.Students)
            {
                Student etudiantTrouver;
                App.Current.Students.TryGetValue(etudiant.Key, out etudiantTrouver);

                if (etudiantTrouver.FirstName.ToLower().Contains(keyword) || etudiantTrouver.LastName.ToLower().Contains(keyword) || etudiantTrouver.Id.ToString().Contains(keyword))
                {
                    string formatString = $"{etudiantTrouver.Id} - {etudiantTrouver.FirstName} {etudiantTrouver.LastName}";

                    listeEtudiants.Items.Add(formatString);
                }
            }
        }
        private void newInput(object sender, KeyEventArgs e)
        {
            searchBarContent = keywordSearch.Text.ToLower();
            InitAllStudent(searchBarContent);
        }

        private void deleteStudent_Click(object sender, RoutedEventArgs e)
        {
            int formatId = Convert.ToInt32(listeEtudiants.SelectedItem.ToString().Split('-')[0].Trim());

            MessageBoxResult msgResult = MessageBox.Show($"Etes vous sure de vouloir supprimer l'etudiant {listeEtudiants.SelectedItem.ToString()} ? ", "", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (msgResult == MessageBoxResult.Yes)
            {
                MessageBoxResult deuxiemeConfirmation = MessageBox.Show($"Cette action est irreversible , etes-vous vraiment sure ? ", "", MessageBoxButton.YesNo, MessageBoxImage.Error);

                if (deuxiemeConfirmation == MessageBoxResult.Yes)
                {
                    App.Current.Students.Remove(formatId);

                    foreach (var cours in App.Current.Courses)
                    {
                        if (cours.StudentIds.Contains(formatId))
                        {
                            cours.StudentIds.RemoveAt(cours.StudentIds.IndexOf(formatId));
                        }
                        foreach (var eval in cours.Evaluations)
                        {
                            if (eval.StudentResults.ContainsKey(formatId))
                            {
                                eval.StudentResults.Remove(formatId);
                            }
                        }
                    }

                    MessageBox.Show($"L'eleve {listeEtudiants.SelectedItem.ToString()} a ete supprimer de partout!", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            InitAllStudent();
        }
    }
}
