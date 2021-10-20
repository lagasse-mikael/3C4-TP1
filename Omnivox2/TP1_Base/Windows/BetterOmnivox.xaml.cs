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
    /// Logique d'interaction pour BetterOmnivox.xaml
    /// </summary>
    public partial class BetterOmnivox : Window
    {
        private Course coursObj;
        public BetterOmnivox(Teacher prof)
        {
            InitializeComponent();

            userLoggedIn.Text = $"{prof.FirstName} {prof.LastName}";

            foreach (var cours in App.Current.Courses)
            {
                if (cours.TeacherId == prof.Id)
                    listeCours.Items.Add($"{cours.Id} - {cours.Name}");
            }
        }

        private void listeCours_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listeEleves.Items.Clear();

            coursObj = App.Current.Courses[listeCours.SelectedIndex];

            string[] coursEnTexte = listeCours.SelectedItem.ToString().Split('-');
            
            selectedItemID.Text = coursEnTexte[0].Trim();
            selectedItemName.Text = coursEnTexte[1].Trim();

            foreach(var eleveID in coursObj.StudentIds)
            {
                Student eleveObj;
                App.Current.Students.TryGetValue(eleveID, out eleveObj);

                listeEleves.Items.Add($"{eleveObj.FirstName} {eleveObj.LastName} - {eleveObj.Id}");
            }

        }
    }
}
