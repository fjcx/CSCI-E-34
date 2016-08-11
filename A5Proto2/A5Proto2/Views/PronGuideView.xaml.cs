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
using System.Windows.Threading;
using System.Windows.Controls.Primitives;
using System.Speech.Synthesis;
using Microsoft.Win32;
using System.ComponentModel;
using A5Proto2.Model;

namespace A5Proto2.Views
{
    /// <summary>
    /// Interaction logic for PronGuideView.xaml
    /// </summary>
    public partial class PronGuideView : UserControl
    {
        private SpeechSynthesizer spchOut;
        private string selectedPhoneme;

        public PronGuideView()
        {
            InitializeComponent();
            spchOut = new SpeechSynthesizer();
        }

        public void selectWord(string wordToSelect)
        {
            for(int i=0; i < phraseBox.Items.Count; i++) {
                if (phraseBox.Items.GetItemAt(i) is Phrase)
                {
                    Phrase phr = (Phrase)phraseBox.Items.GetItemAt(i);
                    if (wordToSelect.Replace(".", "").Replace(",", "").Equals(phr.PhraseText.Replace(".", "").Replace(",", "")))
                    {
                        phraseBox.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void playPron(object sender, RoutedEventArgs e)
        {
            Console.Out.WriteLine("ind" + selectedPhoneme);
            Console.Out.WriteLine(selectedPhrase.Items[0].ToString());
          //  spchOut.SpeakAsync(textOut);
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox lb = (ListBox)sender;
            selectedPhoneme = (string)lb.SelectedItem;
        }
    }
}
