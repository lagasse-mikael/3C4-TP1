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
    /// Logique d'interaction pour AddResult.xaml
    /// </summary>
    public partial class AddResult : Window
    {
        private Evaluation evaluation;
        public AddResult(Evaluation evalChoisie)
        {
            evaluation = evalChoisie;

            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                int idElevenum = Convert.ToInt32(idEleve.Text);
                int noteAttribuer = Convert.ToInt32(noteEval.Text);

                if (App.Current.Students.ContainsKey(idElevenum) && (evaluation.StudentResults != null && evaluation.StudentResults.ContainsKey(idElevenum)))
                {
                    int noteEleve;
                    evaluation.StudentResults.TryGetValue(idElevenum,out noteEleve);

                    MessageBoxResult msgResult = MessageBox.Show($"Voulez vous remplacer la note a {idElevenum} de {noteEleve}% pour {noteAttribuer}% ?", "", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);

                    if(msgResult == MessageBoxResult.Yes)
                    {
                        evaluation.StudentResults[idElevenum] = noteAttribuer;
                        //evaluation.StudentResults.Add(idElevenum, noteAttribuer);

                        MessageBox.Show("La note a ete attribuer avec succees!");
                    }
                    else
                    {
                        MessageBox.Show("L'operation a ete canceller!");
                    }
                }
                else if (App.Current.Students.ContainsKey(idElevenum) && (evaluation.StudentResults == null || !evaluation.StudentResults.ContainsKey(idElevenum)))
                {
                    evaluation.StudentResults.Add(idElevenum, noteAttribuer);

                    MessageBox.Show($"La note de {noteAttribuer} a ete attribuer a {idElevenum} !");
                }
                else
                {
                    MessageBox.Show("Cet etudiant n'est pas enregistrer dans le systeme! Veuillez l'enregister!","",MessageBoxButton.OK,MessageBoxImage.Information);
                }
                this.Close();
            }
            catch(Exception excep)
            {
                MessageBox.Show(excep.ToString());
                return;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
