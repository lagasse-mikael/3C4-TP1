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
    /// Logique d'interaction pour StudentSelectedWindow.xaml
    /// As ete completement changer pour correspondre a un Prof.
    /// Sera a changer bientot..?
    /// </summary>
    public partial class StudentSelectedWindow : Window
    {
        private Teacher Student { get => _student; }
        private Teacher _student;

        // Replace default constructor by adding parameter if window can only be opened with data
        public StudentSelectedWindow(Teacher student)
        {
            InitializeComponent();

            OkButton.Click += OkButton_Click;

            // Keep paramater inside window for use later
            _student = student;

            StudentIdTextBlock.Text = Student.Id.ToString();
            WindowHeader.Title = $"DEBUG | {Student.FirstName} {Student.LastName}";
            StudentFirstNameTextBlock.Text = Student.FirstName;
        }

        // Trick to open window with dummy data, keep a private constructor and send some dummy date to other constructor
        private StudentSelectedWindow() : this(App.Current.Teachers[0])
        {
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            // Ici on change ca un peu , on va ouvrir 'BetterOmnivox' avec le prof en question !
            // Mais on va garder l'ancien code en question , juste pour pas oublier mettons..
            Close();

            // Get any other window from App.Current.GetWindow<>()
            // var mainWindow = App.Current.GetWindow<MainWindow>();
            // mainWindow.DoSomethingFromOtherWindow();

            // _student est un prof , POUR LE MOMENT!
            var betterOmnivox = new BetterOmnivox(_student);
            betterOmnivox.Show();
        }
    }
}
