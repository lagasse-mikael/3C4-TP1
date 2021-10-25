using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TP1_Base_Prof
{
    /// <summary>
    /// Logique d'interaction pour NewEvaluation.xaml
    /// </summary>
    public partial class NewEvaluation : Window
    {
        private Course coursModif;
        public NewEvaluation(Course cours)
        {
            InitializeComponent();

            coursModif = cours;
            nomCours.Content = coursModif.Name;
        }

        private void addEval_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(nomEval.Text == "" || valEval.Text == "") { throw new Exception("intro a la profession"); }

                coursModif.Evaluations.Add(new Evaluation { Name = nomEval.Text,Value = Convert.ToInt32(valEval.Text)});

                MessageBox.Show("L'evaluation a ete ajouter!", "Evaluation ajouter", MessageBoxButton.OK, MessageBoxImage.Information);
                
                // Ajouter l'affaire pour pouvoir fermer la fenetre direct apres.
            }
            catch(Exception exception)
            {
                MessageBox.Show("Quelque chose n'est pas cohérent..","NON",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
    }
}
