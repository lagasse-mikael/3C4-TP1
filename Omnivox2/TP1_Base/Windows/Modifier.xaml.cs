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
    /// Logique d'interaction pour Modifier.xaml
    /// </summary>
    public partial class Modifier : Window
    {
        public Modifier()
        {
            InitializeComponent();
        }

        private void Leave(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ModifEtudiants(object sender, RoutedEventArgs e)
        {
            var windowEtudiant = new ModStudent();
            windowEtudiant.Show();
        }

        private void ModifProfs(object sender, RoutedEventArgs e)
        {
            var windowProfs = new ModTeacher();
            windowProfs.Show();
        }

        private void ModifHoraires(object sender, RoutedEventArgs e)
        {
            var windowHoraires = new Horaire();
            windowHoraires.Show();
        }
    }
}