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
using A5Proto2.Model;

namespace A5Proto2.Views
{
    /// <summary>
    /// Interaction logic for PhraseFlyout.xaml
    /// </summary>
    public partial class PhraseFlyout : UserControl
    {
        public PhraseFlyout()
        {
            InitializeComponent();
        }

        private void goToPronMode(object sender, RoutedEventArgs e)
        {
            Window mainWindow = Application.Current.MainWindow;
            ((A5Proto2.MainWindow)mainWindow).gotToPronGuide(flyoutBtn.Content.ToString());
        }


        private void pClick(object sender, RoutedEventArgs e)
        {
            Console.Out.WriteLine("clicked");
        }

        private void popClick(object sender, RoutedEventArgs e)
        {
            popInformation.IsOpen = true;
        }

        public void heardText()
        {
            flyoutBtn.Foreground = Brushes.MidnightBlue;
            flyoutBtn.FontWeight = FontWeights.Bold;
        }

        public void normalText()
        {
            flyoutBtn.Foreground = Brushes.SlateGray;
            flyoutBtn.FontWeight = FontWeights.Normal;
        }

        public void boldText()
        {
            flyoutBtn.Foreground = Brushes.Black;
            flyoutBtn.FontWeight = FontWeights.Bold;
        }

        public void expectedWordMatched()
        {
            flyoutBtn.Foreground = Brushes.Green;
            flyoutBtn.FontWeight = FontWeights.Bold;
            //Console.Out.WriteLine("fbtn: " + flyoutBtn.Content);
        }

        public void togglePhraseText()
        {
            if (flyoutBtn.Content.Equals(engTextLab.Content))
            {
                flyoutBtn.Content = natTextLab.Content;
            }
            else
            {
                flyoutBtn.Content = engTextLab.Content;
            }
        }

        public void suppliedWordIncorrect(Phrase incorrectWord)
        {
            //MessageBox.Show("I hear ya!");
            flyoutBtn.Foreground = Brushes.Red;
            flyoutBtn.FontWeight = FontWeights.Bold;
            expectedWordPanel.Visibility = Visibility.Visible;
            incorrectWordPanel.Visibility = Visibility.Visible;
            incorrectPhraseText.Content = incorrectWord.PhraseText;
            incorrectNativeText.Content = incorrectWord.NativeText;
            incorrectPhonemes.ItemsSource = incorrectWord.Phonemes;
            incorrectWordExEnglish.Text = incorrectWord.ExampleEnglish;
            incorrectWordExNative.Text = incorrectWord.ExampleNative;
            Console.Out.WriteLine("expected: " + flyoutBtn.Content + " got: " + incorrectWord);
        }

        public T GetChild<T>(DependencyObject obj) where T : DependencyObject
        {
            DependencyObject child = null;
            for (Int32 i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child.GetType() == typeof(T))
                {
                    break;
                }
                else if (child != null)
                {
                    child = GetChild<T>(child);
                    if (child != null && child.GetType() == typeof(T))
                    {
                        break;
                    }
                }
            }
            return child as T;
        }

        private void seePhonemeNow(object sender, DependencyPropertyChangedEventArgs e)
        {
            // delay to allow for virtualization  !?!
            Task.Delay(200).ContinueWith(_ =>
                {
                    for (int i = 0; i < incorrectPhonemes.Items.Count; i++)
                    {
                      //  UIElement uiElement = (UIElement)incorrectPhonemes.ItemContainerGenerator.ContainerFromIndex(i);
                     //   Button phrbtn = (Button)uiElement;
                        //Button phrbtn = GetChild<Button>(uiElement);
                      //  phrbtn.Background = Brushes.Red;
                    }
                }
            );
            /*for (int i = 0; i < incorrectPhonemes.Items.Count; i++)
            {
                UIElement uiElement = (UIElement)incorrectPhonemes.ItemContainerGenerator.ContainerFromIndex(i);
                Button phrbtn = GetChild<Button>(uiElement);
                phrbtn.Background = Brushes.Red;
            }*/
        }
    }
}
