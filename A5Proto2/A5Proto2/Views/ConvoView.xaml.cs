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

namespace A5Proto2.Views
{
    /// <summary>
    /// Interaction logic for ConvoView.xaml
    /// </summary>
    public partial class ConvoView : UserControl
    {

        private SpeechSynthesizer spchOut;
        MainWindowViewModel vm;
        SpeechRecognitionEngine recogEng = new SpeechRecognitionEngine();
        bool inputDeviceOK = true;
        ItemsControl currSentance;
        PhraseFlyout currFlyout;
        int spokenWordIndx;
        Boolean listening = false;
        Boolean inReinit = false;

        public ConvoView() {
            InitializeComponent();
            vm = new MainWindowViewModel();
            currSentance = sent0;

            spchOut = new SpeechSynthesizer();
            spchOut.SpeakCompleted += new EventHandler<SpeakCompletedEventArgs>(spchOut_SpeakCompleted);

            Choices commands = new Choices();
            commands.Add(new string[] { "Hello","Nice","to meet you","My name is","John","Yusuke","too"
                        ,"I have","heard","great","things","about","your","work","Thanks","I'm","walking",
                        "looking forward to","working","with you" });
            
            GrammarBuilder gGbuilder = new GrammarBuilder();
            gGbuilder.Append(commands);
            Grammar grammar = new Grammar(gGbuilder);

            recogEng.LoadGrammarAsync(grammar);
            try
            {
                recogEng.SetInputToDefaultAudioDevice();
                recogEng.SpeechRecognized += recogEng_SpeechRecognized;
            }
            catch (Exception e)
            {
                inputDeviceOK = false;
                MessageBox.Show("There is a problem with your microphone/input device.\n Speech Recognition will not be enabled.");

            }
            disableMicBtn();
            this.Loaded += new RoutedEventHandler(ConvoView_Loaded);
            /* // to disable */
            //recogEng.RecognizeAsyncStop();
        }

        void ConvoView_Loaded(object sender, RoutedEventArgs e)
        {
            speaksent0();
        }

        public void reInit()
        {
            inReinit = true;
            Console.WriteLine("reinit");
            currSentance = sent0;
            spokenWordIndx = 0;
            Boolean endloop = false;
            while (endloop == false)
            {
                while (spokenWordIndx < currSentance.Items.Count)
                {
                    UIElement uiElement = (UIElement)currSentance.ItemContainerGenerator.ContainerFromIndex(spokenWordIndx);
                    currFlyout = GetChild<PhraseFlyout>(uiElement);
                    currFlyout.Background = Brushes.Transparent;
                    currFlyout.normalText();
                    spokenWordIndx++;
                }
                //done with sentance
                if (currSentance == sent3)
                {
                    endloop = true;
                } else {
                    goToNextSentance();
                }
            }
            currSentance = sent0;
            spokenWordIndx = 0;
            inReinit = false;
        }

        private void disableMicBtn() {
            micBtn.IsEnabled = false;
            micBtnImg.BeginInit();
            micBtnImg.Source = new BitmapImage(new Uri("../Assets/Images/mic2Disabled.jpg", UriKind.RelativeOrAbsolute));
            micBtnImg.EndInit();
        }

        private void enableMicBtn()
        {
            micBtn.IsEnabled = true;
            micBtnImg.BeginInit();
            micBtnImg.Source = new BitmapImage(new Uri("../Assets/Images/mic3.jpg", UriKind.RelativeOrAbsolute));
            micBtnImg.EndInit();
        }
        

        private void micBtnClick(object sender, RoutedEventArgs e) {
            listenForWord();
        }

        private void speaksent0()
        {
            spokenWordIndx = 0;
            currSentance = sent0;
            speakNextPhrase();
        }

        private void goToNextSentance()
        {
            spokenWordIndx = 0;
            if (currSentance == sent0)
            {
                currSentance = sent1;
                if (!inReinit)
                {
                    enableMicBtn();     // or just start listening ???
                }
            }
            else if (currSentance == sent1)
            {
                disableMicBtn();
                
                currSentance = sent2;
                if (!inReinit)
                { 
                    speakNextPhrase();
                }
            }
            else if (currSentance == sent2)
            {
                currSentance = sent3;
                if (!inReinit)
                {
                    enableMicBtn();
                }
            }
            else
            {
                // end of sentances !!
                disableMicBtn();
            }
        }

        void listenForWord()
        {
            if (spokenWordIndx < currSentance.Items.Count)
            {
                UIElement uiElement = (UIElement)currSentance.ItemContainerGenerator.ContainerFromIndex(spokenWordIndx);
                currFlyout = GetChild<PhraseFlyout>(uiElement);
                currFlyout.Background = Brushes.PaleGreen;
                Phrase spreakPhrase = (Phrase)currSentance.Items.GetItemAt(spokenWordIndx);
                currFlyout.boldText();
                if (inputDeviceOK == true)
                {
                    if (listening != true)
                    {
                        listening = true;
                        recogEng.RecognizeAsync(RecognizeMode.Multiple);
                        listeningLabel.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    MessageBox.Show("Your machine's input device is not enabled.\n Cannot listen for word.\n Please try on a different machine.");
                }
            }
            else
            {
                recogEng.RecognizeAsyncStop();
                listening = false;
                listeningLabel.Visibility = Visibility.Hidden;
                //done with sentance
                goToNextSentance();
            }
        }

        void recogEng_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            
            String wordSpoken = e.Result.Text;
            if (wordSpoken.CompareTo(currFlyout.flyoutBtn.Content.ToString().Replace(".", "").Replace(",", "")) == 0)
            {
                // word matched !!
                currFlyout.expectedWordMatched();
            }
            else
            {
                // words didn't match expected !!
                foreach (Phrase phr in vm.Phrases)
                {
                    if (wordSpoken.Equals(phr.PhraseText.Replace(".", "").Replace(",", "")))
                    {
                        currFlyout.suppliedWordIncorrect(phr);
                    }
                    else
                    {
                        // create new phrase, recognition list is set, so this can't happen
                    }
                }
            }
            currFlyout.Background = Brushes.Transparent;
            spokenWordIndx++;
            listenForWord();
        }

        private void speakNextPhrase() {
            if (spokenWordIndx < currSentance.Items.Count)
            {
                UIElement uiElement = (UIElement)currSentance.ItemContainerGenerator.ContainerFromIndex(spokenWordIndx);
                currFlyout = GetChild<PhraseFlyout>(uiElement);
                currFlyout.Background = Brushes.Gold;
                Phrase spreakPhrase = (Phrase)currSentance.Items.GetItemAt(spokenWordIndx);
                currFlyout.heardText();
                spchOut.SpeakAsync(spreakPhrase.PhraseText);
            }
            else
            {
                //done with sentance
                goToNextSentance();
            }
        }

        //event handler
        void spchOut_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            currFlyout.Background = Brushes.Transparent;
            spokenWordIndx++;
            speakNextPhrase();
        }

        private void speaksent2()
        {
            spokenWordIndx = 0;
            currSentance = sent2;
            speakNextPhrase();
        }

        private void sent0Hear(object sender, RoutedEventArgs e)
        {
            string textOut = "";
            foreach(Phrase phrase in vm.Sentance0) {
                textOut += phrase.PhraseText + " ";
            }
            Console.Out.WriteLine(textOut);
            spchOut.Speak(textOut);
        }

        private void sent1Hear(object sender, RoutedEventArgs e)
        {
            string textOut = "";
            foreach (Phrase phrase in vm.Sentance1)
            {
                textOut += phrase.PhraseText + " ";
            }
            Console.Out.WriteLine(textOut);
            spchOut.Speak(textOut);
        }

        private void sent2Hear(object sender, RoutedEventArgs e)
        {
            string textOut = "";
            foreach (Phrase phrase in vm.Sentance2)
            {
                textOut += phrase.PhraseText + " ";
            }
            Console.Out.WriteLine(textOut);
            spchOut.Speak(textOut);
        }

        private void sent3Hear(object sender, RoutedEventArgs e)
        {
            string textOut = "";
            foreach (Phrase phrase in vm.Sentance3)
            {
                textOut += phrase.PhraseText + " ";
            }
            Console.Out.WriteLine(textOut);
            spchOut.Speak(textOut);
        }

        private void toggleSent(object sender, RoutedEventArgs e)
        {
            foreach (Phrase phr in vm.Phrases)
            {
                if ("walking".Equals(phr.PhraseText.Replace(".", "").Replace(",", "")))
                {
                    currFlyout.suppliedWordIncorrect(phr);
                }
            }
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

        private void toggleSent0(object sender, RoutedEventArgs e)
        {
            toggleSentLanguage(sent0);
        }

        private void toggleSent1(object sender, RoutedEventArgs e)
        {
            toggleSentLanguage(sent1);
        }

        private void toggleSent2(object sender, RoutedEventArgs e)
        {
            toggleSentLanguage(sent2);
        }

        private void toggleSent3(object sender, RoutedEventArgs e)
        {
            toggleSentLanguage(sent3);
        }

        private void toggleSentLanguage(ItemsControl sentanceControl)
        {
            for (int i = 0; i < sentanceControl.Items.Count; i++)
            {
                UIElement uiElement = (UIElement)sentanceControl.ItemContainerGenerator.ContainerFromIndex(i);
                PhraseFlyout sflyout = GetChild<PhraseFlyout>(uiElement);
                sflyout.togglePhraseText();
            }
        }

    }
}
