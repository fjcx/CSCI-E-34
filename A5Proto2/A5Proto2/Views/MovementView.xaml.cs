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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using A5Proto2.Model;
using System.Windows.Media.Animation;

namespace A5Proto2.Views
{
    /// <summary>
    /// Interaction logic for ConvoView.xaml
    /// </summary>
    public partial class MovementView : UserControl
    {
        public MovementView()
        {
            InitializeComponent();

        }

        void MovementView_Loaded(object sender, RoutedEventArgs e)
        {
            //
        }


        private void goToConvoScreen(object sender, MouseButtonEventArgs e)
        {
            Window mainWindow = Application.Current.MainWindow;
            ((A5Proto2.MainWindow)mainWindow).gotToConvoView();
        }
    }
}
