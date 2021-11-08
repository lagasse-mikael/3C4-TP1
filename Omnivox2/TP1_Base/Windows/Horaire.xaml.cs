using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

/// <summary>
/// Ne marche pas encore , mais faut bin que je push.
/// Manque donc les cours a mettres et l'horaire a afficher.
/// </summary>

namespace TP1_Base_Prof
{
    /// <summary>
    /// Logique d'interaction pour Horaire.xaml
    /// </summary>
    public partial class Horaire : Window
    {
        List<ToggleButton> cellulesChoisies = new List<ToggleButton>();
        public Horaire()
        {
            InitializeComponent();

            InitCours();
        }

        /// <summary>
        ///  Siboire.
        /// </summary>
        public void InitCours()
        {
            listeCours.Items.Clear();
            if (semesterList.SelectedIndex == -1)
                return;

            var semesterText = ((ComboBoxItem)semesterList.SelectedItem).Content.ToString();

            foreach (var cours in App.Current.Courses)
            {
                if (cours.Semester.ToString() == semesterText)
                {
                    listeCours.Items.Add($"{cours.Id} - Gr.00{cours.Group}");
                }

                InitHoraire(cours);
            }
        }

        private void InitHoraire(Course cours)
        {
            foreach (var coursePeriod in cours.CoursePeriods)
            {
                string formatRow = ((int)coursePeriod.DayOfWeek).ToString();

                for (int i = coursePeriod.PeriodStart; i < coursePeriod.PeriodLength; i++)
                {
                    string formatTag = $"{formatRow}-{i}";
                    var horaireGridChildrens = horaireGrid.Children;

                    for (int j = 17; j < horaireGridChildrens.Count; j++)
                    {
                        ToggleButton btn = (ToggleButton)horaireGridChildrens[j];
                        if (btn.Tag.ToString() == formatTag)
                        {
                            btn.Content = "OK!";
                            break;
                        }
                    }
                }
            }
        }

        private void semesterList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InitCours();
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButton hasBeenClicked = (ToggleButton)sender;
            string buttonInfo = hasBeenClicked.Tag.ToString();

            sessionText.Text = buttonInfo;

            if (!cellulesChoisies.Contains(hasBeenClicked))
            {
                if (cellulesChoisies.Count == 0)
                {
                    cellulesChoisies.Add((ToggleButton)sender);
                    return;
                }

                int row = Convert.ToInt32(buttonInfo.Split('-')[0]);
                int col = Convert.ToInt32(buttonInfo.Split('-')[1]);

                int derniereCelluleRow = Convert.ToInt32(cellulesChoisies[cellulesChoisies.Count - 1].Tag.ToString().Split('-')[0]);
                int derniereCelluleCol = Convert.ToInt32(cellulesChoisies[cellulesChoisies.Count - 1].Tag.ToString().Split('-')[1]);

                if (row == derniereCelluleRow && (col == derniereCelluleCol - 1 || col == derniereCelluleCol + 1))
                {
                    cellulesChoisies.Add((ToggleButton)sender);
                }
                else
                {
                    foreach (var button in cellulesChoisies)
                    {
                        button.IsChecked = false;
                    }
                    cellulesChoisies.Clear();
                    cellulesChoisies.Add((ToggleButton)sender);
                }
            }
        }

        private void listeCours_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InitHoraire(App.Current.Courses[listeCours.SelectedIndex]);
        }
    }
}
