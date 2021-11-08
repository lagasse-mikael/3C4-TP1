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
    /// Logique d'interaction pour Omnivox.xaml
    /// </summary>
    public partial class Omnivox : Window
    {
        bool isEtudiant = false;
        Teacher profImporter;
        Student etudiantImporter;

        public Omnivox(Student etudiant)
        {
            isEtudiant = true;
            etudiantImporter = etudiant;

            InitializeComponent();

            nomUser.Content = $"{etudiant.FirstName} {etudiant.LastName}";
            initListeCours();
        }

        public Omnivox(Teacher prof)
        {
            isEtudiant = false;
            profImporter = prof;

            InitializeComponent();

            nomUser.Content = $"{prof.FirstName} {prof.LastName}";
            initListeCours();
        }

        private void initListeCours()
        {
            if (listeSemester.SelectedItem == null)
                return;

            var semesterTexte = (ComboBoxItem)listeSemester.SelectedItem;

            listeCours.Items.Clear();
            // App.Current.Students
            if (isEtudiant)
            {
                foreach (var cours in App.Current.Courses)
                {
                    if (cours.StudentIds.Contains(etudiantImporter.Id) && cours.Semester.ToString() == semesterTexte.Content.ToString())
                        listeCours.Items.Add($"{cours.Id} - Groupe 00{cours.Group}");
                }
            }
            else
            {
                foreach (var cours in App.Current.Courses)
                {
                    if (cours.TeacherId == profImporter.Id && cours.Semester.ToString() == semesterTexte.Content.ToString())
                        listeCours.Items.Add($"{cours.Id} - Groupe 00{cours.Group}");
                }
            }
        }

        private void listeSemester_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            initListeCours();
        }

        private void listeCours_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isEtudiant)
            {
                MessageBox.Show("TO DO", "", MessageBoxButton.OK,MessageBoxImage.Error);
            }
            else
            {
                var noteWindow = new Note(App.Current.Courses[listeCours.SelectedIndex]);
                noteWindow.Show();
            }
            return;
        }
    }
}
