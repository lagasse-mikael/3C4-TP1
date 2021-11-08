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
    /// Logique d'interaction pour Note.xaml
    /// </summary>
    public partial class Note : Window
    {
        private Course coursChoisie;
        public Note(Course coursImporter)
        {
            coursChoisie = coursImporter;

            InitializeComponent();

            InitMenu();
        }

        private void InitMenu()
        {
            listeEval.Items.Clear();
            foreach (var eval in coursChoisie.Evaluations)
            {
                listeEval.Items.Add(eval.Name);
            }
        }

        private void listeEval_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<int> notes = new List<int>();

            listeElevesNotes.Items.Clear();
            ponderationText.Text = "";
            moyenneText.Text = "";

            if (listeEval.SelectedIndex > -1 && coursChoisie.Evaluations[listeEval.SelectedIndex].StudentResults != null)
            {
                foreach (var note in coursChoisie.Evaluations[listeEval.SelectedIndex].StudentResults)
                {
                    Student eleve;
                    App.Current.Students.TryGetValue(note.Key, out eleve);

                    string stringFormat = $" {eleve.Id} - {eleve.FirstName} {eleve.LastName} - {note.Value}";
                    notes.Add(note.Value);

                    listeElevesNotes.Items.Add(stringFormat);
                }
                ponderationText.Text = coursChoisie.Evaluations[listeEval.SelectedIndex].Value.ToString();
                moyenneText.Text = (coursChoisie.Evaluations[listeEval.SelectedIndex].StudentResults.Values.ToArray().Sum() / coursChoisie.Evaluations[listeEval.SelectedIndex].StudentResults.Values.Count).ToString();

            }
        }

        private void ponderationText_KeyUp(object sender, KeyEventArgs e)
        {
            if (listeEval.SelectedIndex != -1 && ponderationText.Text != "")
            {
                try
                {
                    coursChoisie.Evaluations[listeEval.SelectedIndex].Value = Convert.ToInt32(ponderationText.Text);
                }
                catch (Exception excep)
                {
                    return;
                }

            }
        }

        private void listeElevesNotes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listeEval.SelectedIndex != -1 && listeElevesNotes.SelectedIndex != -1)
            {
                Student eleveTrouver;
                int idTrouver;

                var selectedItem = listeElevesNotes.SelectedItem;
                idTrouver = Convert.ToInt32(selectedItem.ToString().Split('-')[0].Trim());

                idEleve.Text = idTrouver.ToString();

                App.Current.Students.TryGetValue(idTrouver, out eleveTrouver);

                refreshNotesEleve(eleveTrouver);
            }
        }

        private void refreshNotesEleve(Student eleve)
        {
            resumerNotes.Items.Clear();

            firstnameEleve.Text = eleve.FirstName;
            lastnameEleve.Text = eleve.LastName;

            foreach (var evaluation in coursChoisie.Evaluations)
            {
                if (evaluation.StudentResults.ContainsKey(eleve.Id))
                {
                    int noteEleve;
                    evaluation.StudentResults.TryGetValue(eleve.Id, out noteEleve);

                    string formatString = $"{evaluation.Name}\t{noteEleve}/{evaluation.Value}\tMoyenne:{evaluation.StudentResults.Values.Sum() / evaluation.StudentResults.Values.Count()}";
                    resumerNotes.Items.Add(formatString);
                }
            }
        }

        private void idEleve_KeyUp(object sender, KeyEventArgs e)
        {
            resumerNotes.Items.Clear();
            firstnameEleve.Text = "";
            lastnameEleve.Text = "";
            try
            {
                int idAChercher = Convert.ToInt32(idEleve.Text);

                if (App.Current.Students.ContainsKey(idAChercher))
                {
                    Student eleveTrouver;
                    App.Current.Students.TryGetValue(idAChercher, out eleveTrouver);
                    refreshNotesEleve(eleveTrouver);

                    return;
                }
            }
            catch (Exception exception)
            {
                return;
            }
        }

        private void ajoutEval_Click(object sender, RoutedEventArgs e)
        {
            var ajoutEvalWindow = new NewEvaluation(coursChoisie);
            ajoutEvalWindow.Closed += ajoutEvalClosed;

            ajoutEvalWindow.Show();

            return;
        }

        private void ajoutEvalClosed(object sender, System.EventArgs e)
        {
            InitMenu();
        }

        private void ajoutResultat(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("TO DO ", "", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
