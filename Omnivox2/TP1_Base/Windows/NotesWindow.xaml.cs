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
    /// Logique d'interaction pour NotesWindow.xaml
    /// </summary>
    public partial class NotesWindow : Window
    {
        public NotesWindow(Evaluation evalChoisie)
        {
            InitializeComponent();
            evalName.Content = evalChoisie.Name + " " + evalChoisie.Value + "%";

            foreach(var result in evalChoisie.StudentResults)
            {
                Student student;
                App.Current.Students.TryGetValue(result.Key, out student);

                string studentName = student.FirstName + " " + student.LastName;

                listeNotes.Items.Add($"[{result.Key}] {studentName} - {result.Value}%");
            }
        }

        private void addNote_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
