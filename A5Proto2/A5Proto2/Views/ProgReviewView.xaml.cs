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
using System.ComponentModel;
using A5Proto2.Model;

namespace A5Proto2.Views
{
    /// <summary>
    /// Interaction logic for ProgReviewView.xaml
    /// </summary>
    public partial class ProgReviewView : UserControl
    {
        public string _filterString;

        public ProgReviewView()
        {
            InitializeComponent();
        }

        private void goToPronMode(object sender, RoutedEventArgs e)
        {
            Window mainWindow = Application.Current.MainWindow;
            Phrase phr = (Phrase)ReviewGrid.SelectedItem;
            ((A5Proto2.MainWindow)mainWindow).gotToPronGuide(phr.PhraseText);
            Console.Out.WriteLine("clicked");
        }

    }
}
