using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Media;

namespace A5Proto2.Model {

    public class Phrase
    {
        private string _phraseText;
        private string _nativeText;
        private string _romanizedNativeText;
        private int _appearanceCnt;
        private double _phraseScore;
        private string _exampleEnglish;
        private string _exampleNative;
        private string _pronounceProbs;
        private string _confuseWith;
        private ICollectionView _phonemes;
        private Brush _textColor;

        public string PhraseText {
            get { return _phraseText; }
            set {
                _phraseText = value;
                NotifyPropertyChanged("PhraseText");
            }
        }

        public string NativeText {
            get { return _nativeText; }
            set {
                _nativeText = value;
                NotifyPropertyChanged("NativeText");
            }
        }

        public string RomanizedNativeText {
            get { return _romanizedNativeText; }
            set {
                _romanizedNativeText = value;
                NotifyPropertyChanged("NativeText");
            }
        }

        public int AppearanceCnt {
            get { return _appearanceCnt; }
            set {
                _appearanceCnt = value;
                NotifyPropertyChanged("AppearanceCnt");
            }
        }

        public double PhraseScore {
            get { return _phraseScore; }
            set {
                _phraseScore = value;
                NotifyPropertyChanged("PhraseScore");
            }
        }

        public string ExampleEnglish {
            get { return _exampleEnglish; }
            set {
                _exampleEnglish = value;
                NotifyPropertyChanged("ExampleEnglish");
            }
        }

        public string ExampleNative {
            get { return _exampleNative; }
            set {
                _exampleNative = value;
                NotifyPropertyChanged("ExampleNative");
            }
        }

        public string PronounceProbs {
            get { return _pronounceProbs; }
            set {
                _pronounceProbs = value;
                NotifyPropertyChanged("PronounceProbs");
            }
        }

        public string ConfuseWith {
            get { return _confuseWith; }
            set {
                _confuseWith = value;
                NotifyPropertyChanged("ConfuseWith");
            }
        }

        public ICollectionView Phonemes
        {
            get { return _phonemes; }
            set
            {
                _phonemes = value;
                NotifyPropertyChanged("Phonemes");
            }
        }

        public Brush TextColor
        {
            get { return _textColor; }
            set
            {
                _textColor = value;
                NotifyPropertyChanged("TextColor");
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Private Helpers

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                Console.Out.WriteLine("changed: " + propertyName);
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
