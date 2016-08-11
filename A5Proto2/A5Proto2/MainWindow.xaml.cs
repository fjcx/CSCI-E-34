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
using A5Proto2.Views;

namespace A5Proto2 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        public void gotToPronGuide(string selectedWord)
        {
            if (mainTabControl.SelectedIndex == 4)
            {
                ConvoView cv = (ConvoView)((TabItem)mainTabControl.SelectedItem).Content;
                cv.reInit();
            }
            // got to pron word and select word
            mainTabControl.SelectedIndex = 2;
            titleLabel.Content = "Pronunciation Guide";
            SearchBox.Visibility = Visibility.Visible;
            A5Proto2.Views.PronGuideView pGuide = (A5Proto2.Views.PronGuideView)nav2.Content;
            pGuide.selectWord(selectedWord);
        }

        public void gotToConvoView()
        {
            // got to conversationScreen
            mainTabControl.SelectedIndex = 4;
            titleLabel.Content = "Introductions (Meeting New Business Partner)";
            SearchBox.Visibility = Visibility.Hidden;
        }

        private void ButtonClick(object sender, RoutedEventArgs e) {
            toggleNavMenu();
        }

        private void toggleNavMenu() {
            this.Menu.Visibility = this.Menu.Visibility == Visibility.Visible
                                ? Visibility.Collapsed
                                : Visibility.Visible;
        }

        private void nav0Pressed(object sender, RoutedEventArgs e) {
            if (mainTabControl.SelectedIndex == 4)
            {
                ConvoView cv = (ConvoView)((TabItem)mainTabControl.SelectedItem).Content;
                cv.reInit();
            }
            mainTabControl.SelectedIndex = 0;
            titleLabel.Content = "Introductions";
            SearchBox.Visibility = Visibility.Hidden;
            toggleNavMenu();
        }

        private void nav1Pressed(object sender, RoutedEventArgs e) {
            if (mainTabControl.SelectedIndex == 4)
            {
                ConvoView cv = (ConvoView)((TabItem)mainTabControl.SelectedItem).Content;
                cv.reInit();
            }
            mainTabControl.SelectedIndex = 1;
            titleLabel.Content = "Review Progress";
            SearchBox.Visibility = Visibility.Visible;
            toggleNavMenu();
        }

        private void nav2Pressed(object sender, RoutedEventArgs e) {
            if (mainTabControl.SelectedIndex == 4)
            {
                ConvoView cv = (ConvoView)((TabItem)mainTabControl.SelectedItem).Content;
                cv.reInit();
            }
            mainTabControl.SelectedIndex = 2;
            titleLabel.Content = "Pronunciation Guide";
            SearchBox.Visibility = Visibility.Visible;
            toggleNavMenu();
        }

        private void nav3Pressed(object sender, RoutedEventArgs e) {
            if(mainTabControl.SelectedIndex == 4) {
                ConvoView cv = (ConvoView)((TabItem)mainTabControl.SelectedItem).Content;
                cv.reInit();
            }
            mainTabControl.SelectedIndex = 3;
            titleLabel.Content = "Car Mode";
            SearchBox.Visibility = Visibility.Visible;
            toggleNavMenu();
        }

        private void exitPressed(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void nav4Pressed(object sender, RoutedEventArgs e)
        {
            mainTabControl.SelectedIndex = 4;
            titleLabel.Content = "Introductions";
            SearchBox.Visibility = Visibility.Visible;
            toggleNavMenu();
            
        }
    }
}
