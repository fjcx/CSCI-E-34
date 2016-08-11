using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Media;
using A5Proto2.Model;

namespace A5Proto2 {
    class MainWindowViewModel {
        public ICollectionView Phrases { get; private set; }
        public ICollectionView Sentance0 { get; private set; }
        public ICollectionView Sentance1 { get; private set; }
        public ICollectionView Sentance2 { get; private set; }
        public ICollectionView Sentance3 { get; private set; }
        public string _pfilterString;

        public MainWindowViewModel() {

            _pfilterString = "*";
            Dictionary<string, Phrase> phraseDict2 = new Dictionary<string, Phrase>() {
                {"Hello", new Phrase {
                            PhraseText = "Hello!",
                            NativeText = "こんにちは",
                            RomanizedNativeText = "Kon'nichiwa",
                            AppearanceCnt = 50,
                            PhraseScore = 90,
                            ExampleEnglish = "used to express a greeting, answer a telephone, or attract attention\n "+
                                            "\"She gave me a warm hello.\"",
                            ExampleNative = "、挨拶を表現し、電話に答えるか、注目を集めるために使用\n\"彼女は私に暖かいハローを与えた.\"",
                            PronounceProbs = "<A selection of example problems with pronouncing the word>",
                            ConfuseWith = "<A list of similar sounding words here>",
                            Phonemes = CollectionViewSource.GetDefaultView(new List<string>(){"hel","oh"}),
                            TextColor = Brushes.SlateGray}
                 },
                 {"Nice", new Phrase {
                            PhraseText = "Nice",
                            NativeText = "ニース",
                            RomanizedNativeText = "Nīsu",
                            AppearanceCnt = 20,
                            PhraseScore = 70,
                            ExampleEnglish = "pleasing; agreeable; delightful\n\"a nice visit.\"",
                            ExampleNative = "楽しい。快い。楽しい\n\"素敵な訪問.\"",
                            PronounceProbs = "<A selection of example problems with pronouncing the word>",
                            ConfuseWith = "<A list of similar sounding words here>",
                            Phonemes = CollectionViewSource.GetDefaultView(new List<string>(){"nahys"}),
                            TextColor = Brushes.SlateGray }
                 },
                 {"to meet you", new Phrase {
                            PhraseText = "to meet you",
                            NativeText = "あなたを満たすために",
                            RomanizedNativeText = "Anata o mitasu tame ni",
                            AppearanceCnt = 30,
                            PhraseScore = 70,
                            ExampleEnglish = "to come upon; come into the presence of; encounter\n\"I would meet him on the street at unexpected moments.\"",
                            ExampleNative = "上に来て、の存在に入る。出会い\n\"私は、予期しない瞬間に路上で彼に会うだろう.\"",
                            PronounceProbs = "<A selection of example problems with pronouncing the word>",
                            ConfuseWith = "<A list of similar sounding words here>",
                            Phonemes = CollectionViewSource.GetDefaultView(new List<string>(){"too","meet","yoo"}),
                            TextColor = Brushes.SlateGray }
                 },
                 {"My name is", new Phrase {
                            PhraseText = "My name is",
                            NativeText = "私の名前は",
                            RomanizedNativeText = "Watashinonamaeha",
                            AppearanceCnt = 80,
                            PhraseScore = 85,
                            ExampleEnglish = "a word or a combination of words by which a person, place, or thing, a body or class, or any object of thought is designated, called, or known\n\"My name is John.\"",
                            ExampleNative = "単語や人、場所、または物、身体またはクラス、または思考の任意のオブジェクトは、指定されたと呼ばれていることにより、単語の組み合わせ、または既知の\n\"私の名前はジョンです.\"",
                            PronounceProbs = "<A selection of example problems with pronouncing the word>",
                            ConfuseWith = "<A list of similar sounding words here>",
                            Phonemes = CollectionViewSource.GetDefaultView(new List<string>(){"mahy","neym","iz"}),
                            TextColor = Brushes.SlateGray }
                 }, 
                 {"John", new Phrase {
                            PhraseText = "John.",
                            NativeText = "ジョン",
                            RomanizedNativeText = "Jon",
                            AppearanceCnt = 50,
                            PhraseScore = 94,
                            ExampleEnglish = "The name of a person\n\"John spilled the milk.\"",
                            ExampleNative = "人物の名前\n\"ジョンは牛乳をこぼした.\"",
                            PronounceProbs = "<A selection of example problems with pronouncing the word>",
                            ConfuseWith = "<A list of similar sounding words here>",
                            Phonemes = CollectionViewSource.GetDefaultView(new List<string>(){"jon"}),
                            TextColor = Brushes.SlateGray }
                 },
                 // sentance 2
                 {"Yusuke", new Phrase {
                            PhraseText = "Yusuke.",
                            NativeText = "雄介",
                            RomanizedNativeText = "Yusuke",
                            AppearanceCnt = 70,
                            PhraseScore = 100,
                            ExampleEnglish = "The name of a person\n\"Yusuke spilled the milk.\"",
                            ExampleNative = "人物の名前\n\"雄介は牛乳をこぼした.\"",
                            PronounceProbs = "<A selection of example problems with pronouncing the word>",
                            ConfuseWith = "<A list of similar sounding words here>",
                            Phonemes = CollectionViewSource.GetDefaultView(new List<string>(){"Yus", "ke"}),
                            TextColor = Brushes.SlateGray }
                 },
                 {"too", new Phrase {
                            PhraseText = "too",
                            NativeText = "あまりに",
                            RomanizedNativeText = "Amarini",
                            AppearanceCnt = 30,
                            PhraseScore = 97,
                            ExampleEnglish = "in addition; also; furthermore; moreover\n\"young, clever, and rich too.\"",
                            ExampleNative = "加えて;また、さらに、さらに\n\"、若い賢い、そして豊かなあまりに.\"",
                            PronounceProbs = "<A selection of example problems with pronouncing the word>",
                            ConfuseWith = "<A list of similar sounding words here>",
                            Phonemes = CollectionViewSource.GetDefaultView(new List<string>(){"too"}),
                            TextColor = Brushes.SlateGray }
                 },
                 // sentance 3
                 {"I have", new Phrase {
                            PhraseText = "I have",
                            NativeText = "私が持っている",
                            RomanizedNativeText = "Watashi ga motte iru",
                            AppearanceCnt = 50,
                            PhraseScore = 60,
                            ExampleEnglish = "to possess; own; hold for use\n\"He has property. The work has an index.\"",
                            ExampleNative = "所有する。自身。使用するために保持する\n\"彼は、プロパティを持っています。作業は、インデックスを持つ.\"",
                            PronounceProbs = "<A selection of example problems with pronouncing the word>",
                            ConfuseWith = "<A list of similar sounding words here>",
                            Phonemes = CollectionViewSource.GetDefaultView(new List<string>(){"ahy","hav"}),
                            TextColor = Brushes.SlateGray }
                 },
                 {"heard", new Phrase {
                            PhraseText = "heard",
                            NativeText = "聞いた",
                            RomanizedNativeText = "Kiita",
                            AppearanceCnt = 20,
                            PhraseScore = 25,
                            ExampleEnglish = "to perceive by the ear\n\"Didn't you hear the doorbell.\"",
                            ExampleNative = "耳で知覚する\n\"あなたが呼び鈴を聞いていない.\"",
                            PronounceProbs = "<A selection of example problems with pronouncing the word>",
                            ConfuseWith = "<A list of similar sounding words here>",
                            Phonemes = CollectionViewSource.GetDefaultView(new List<string>(){"herd"}),
                            TextColor = Brushes.SlateGray }
                 },
                 {"great", new Phrase {
                            PhraseText = "great",
                            NativeText = "素晴らしい",
                            RomanizedNativeText = "Subarashī",
                            AppearanceCnt = 40,
                            PhraseScore = 87,
                            ExampleEnglish = "wonderful; first-rate; very good\n\"We had a great time. That's great.\"",
                            ExampleNative = "素晴らしい。一流。とても良い\n\"我々は素晴らしい時間を過ごしました。それは素晴らしいことです.\"",
                            PronounceProbs = "<A selection of example problems with pronouncing the word>",
                            ConfuseWith = "<A list of similar sounding words here>",
                            Phonemes = CollectionViewSource.GetDefaultView(new List<string>(){"greyt"}),
                            TextColor = Brushes.SlateGray }
                 },
                 {"things", new Phrase {
                            PhraseText = "things",
                            NativeText = "物事",
                            RomanizedNativeText = "Monogoto",
                            AppearanceCnt = 20,
                            PhraseScore = 25,
                            ExampleEnglish = "a material object without life or consciousness; an inanimate object\n\"Things are going well now.\"",
                            ExampleNative = "生活や意識のない材料オブジェクト。無生物\n\"ものは今うまくいっている.\"",
                            PronounceProbs = "<A selection of example problems with pronouncing the word>",
                            ConfuseWith = "<A list of similar sounding words here>",
                            Phonemes = CollectionViewSource.GetDefaultView(new List<string>(){"thingz"}),
                            TextColor = Brushes.SlateGray }
                 },
                 {"about", new Phrase {
                            PhraseText = "about",
                            NativeText = "約",
                            RomanizedNativeText = "Yaku",
                            AppearanceCnt = 25,
                            PhraseScore = 70,
                            ExampleEnglish = "connected or associated with\n\"There was an air of mystery about him.\"",
                            ExampleNative = "接続されるか、または関連付けられている\n\"彼について謎の空気をがありました.\"",
                            PronounceProbs = "<A selection of example problems with pronouncing the word>",
                            ConfuseWith = "<A list of similar sounding words here>",
                            Phonemes = CollectionViewSource.GetDefaultView(new List<string>(){"uh","bout"}),
                            TextColor = Brushes.SlateGray }
                 },
                 {"your", new Phrase {
                            PhraseText = "your",
                            NativeText = "あなたの",
                            RomanizedNativeText = "Anata no",
                            AppearanceCnt = 30,
                            PhraseScore = 50,
                            ExampleEnglish = "form of the possessive case of you\n\"Your jacket is in that closet.\"",
                            ExampleNative = "あなたの所有格の形\n\"あなたのジャケットはそのクローゼットの中にある.\"",
                            PronounceProbs = "<A selection of example problems with pronouncing the word>",
                            ConfuseWith = "<A list of similar sounding words here>",
                            Phonemes = CollectionViewSource.GetDefaultView(new List<string>(){"yoo","r"}),
                            TextColor = Brushes.SlateGray }
                 },
                 {"work", new Phrase {
                            PhraseText = "work",
                            NativeText = "仕事",
                            RomanizedNativeText = "Shigoto",
                            AppearanceCnt = 15,
                            PhraseScore = 55,
                            ExampleEnglish = "exertion or effort directed to produce or accomplish something; labor\n\"The students finished their work in class.\"",
                            ExampleNative = "生産または何かを達成するように指示労作または努力。労働\n\"生徒はクラスで自分の仕事を終え.\"",
                            PronounceProbs = "<A selection of example problems with pronouncing the word>",
                            ConfuseWith = "<A list of similar sounding words here>",
                            Phonemes = CollectionViewSource.GetDefaultView(new List<string>(){"wurk"}),
                            TextColor = Brushes.SlateGray }
                 },
                 // sentance 4
                 {"working", new Phrase {
                            PhraseText = "working",
                            NativeText = "仕事",
                            RomanizedNativeText = "Shigoto",
                            AppearanceCnt = 15,
                            PhraseScore = 55,
                            ExampleEnglish = "exertion or effort directed to produce or accomplish something; labor\n\"The students finished their work in class.\"",
                            ExampleNative = "生産または何かを達成するように指示労作または努力。労働\n\"生徒はクラスで自分の仕事を終え.\"",
                            PronounceProbs = "<A selection of example problems with pronouncing the word>",
                            ConfuseWith = "<A list of similar sounding words here>",
                            Phonemes = CollectionViewSource.GetDefaultView(new List<string>(){"wur","king"}),
                            TextColor = Brushes.SlateGray }
                 },
                 {"with you", new Phrase {
                            PhraseText = "with you",
                            NativeText = "あなたと",
                            RomanizedNativeText = "Anata to",
                            AppearanceCnt = 25,
                            PhraseScore = 85,
                            ExampleEnglish = "accompanied by; accompanying\n\"I will go with you.\"",
                            ExampleNative = "を伴う。付随の\n\"私はあなたと行きます.\"",
                            PronounceProbs = "<A selection of example problems with pronouncing the word>",
                            ConfuseWith = "<A list of similar sounding words here>",
                            Phonemes = CollectionViewSource.GetDefaultView(new List<string>(){"with","yoo"}),
                            TextColor = Brushes.SlateGray }
                 },
                 {"looking forward to", new Phrase {
                            PhraseText = "looking forward to",
                            NativeText = "楽しみにして",
                            RomanizedNativeText = "Tanoshimini shite",
                            AppearanceCnt = 15,
                            PhraseScore = 75,
                            ExampleEnglish = "to expect; to anticipate; be sure of\n\"to look forward to a favorable decision.\"",
                            ExampleNative = "期待する。予測する。のを確認してください\n\"有利な判決を予想する.\"",
                            PronounceProbs = "<A selection of example problems with pronouncing the word>",
                            ConfuseWith = "<A list of similar sounding words here>",
                            Phonemes = CollectionViewSource.GetDefaultView(new List<string>(){"loo","king","fawr","werd","too"}),
                            TextColor = Brushes.SlateGray }
                 },
                 {"I'm", new Phrase {
                            PhraseText = "I'm",
                            NativeText = "私は今",
                            RomanizedNativeText = "Watashi wa ima",
                            AppearanceCnt = 97,
                            PhraseScore = 85,
                            ExampleEnglish = "contraction of I am\n\"I'm happy to see you.\"",
                            ExampleNative = "私はの収縮\n\"私はあなたを見て満足している.\"",
                            PronounceProbs = "<A selection of example problems with pronouncing the word>",
                            ConfuseWith = "<A list of similar sounding words here>",
                            Phonemes = CollectionViewSource.GetDefaultView(new List<string>(){"ahym"}),
                            TextColor = Brushes.SlateGray }
                 },
                 {"Thanks", new Phrase {
                            PhraseText = "Thanks,",
                            NativeText = "ありがとう",
                            RomanizedNativeText = "Arigatō",
                            AppearanceCnt = 97,
                            PhraseScore = 85,
                            ExampleEnglish = "contraction of Thank you\n\"Thanks for the duck.\"",
                            ExampleNative = "の収縮がありがとうございます\n\"アヒルをありがとう.\"",
                            PronounceProbs = "<A selection of example problems with pronouncing the word>",
                            ConfuseWith = "<A list of similar sounding words here>",
                            Phonemes = CollectionViewSource.GetDefaultView(new List<string>(){"thangkz"}),
                            TextColor = Brushes.SlateGray }
                 },
                 {"walking", new Phrase {
                            PhraseText = "walking",
                            NativeText = "ウォーキング",
                            RomanizedNativeText = "U~ōkingu",
                            AppearanceCnt = 20,
                            PhraseScore = 15,
                            ExampleEnglish = "the act or action of a person or thing that walks\n\"Walking was the best exercise for him.\"",
                            ExampleNative = "歩く行為や人の行動や物\n\"彼のために最善の練習したウォーキング.\"",
                            PronounceProbs = "<A selection of example problems with pronouncing the word>",
                            ConfuseWith = "<A list of similar sounding words here>",
                            Phonemes = CollectionViewSource.GetDefaultView(new List<string>(){"waw","king"}),
                            TextColor = Brushes.SlateGray }
                 }

            };


            var _phraseList = new List<Phrase>();
            var _sentance0 = new List<Phrase>(){
                phraseDict2["Hello"],
                phraseDict2["Nice"],
                phraseDict2["to meet you"],
                phraseDict2["My name is"],
                phraseDict2["John"]
            };
            var _sentance1 = new List<Phrase>(){
                phraseDict2["My name is"],
                phraseDict2["Yusuke"],
                phraseDict2["Nice"],
                phraseDict2["to meet you"],
                phraseDict2["too"]
            };
            var _sentance2 = new List<Phrase>(){
                phraseDict2["I have"],
                phraseDict2["heard"],
                phraseDict2["great"],
                phraseDict2["things"],
                phraseDict2["about"],
                phraseDict2["your"],
                phraseDict2["work"]
            };
            var _sentance3 = new List<Phrase>(){
                phraseDict2["Thanks"],
                phraseDict2["I'm"],
                phraseDict2["looking forward to"],
                phraseDict2["working"],
                phraseDict2["with you"]
            };

            foreach (KeyValuePair<string, Phrase> pair in phraseDict2)
            {
                _phraseList.Add(pair.Value);
            }

            Phrases = CollectionViewSource.GetDefaultView(_phraseList);
            Sentance0 = CollectionViewSource.GetDefaultView(_sentance0);
            Sentance1 = CollectionViewSource.GetDefaultView(_sentance1);
            Sentance2 = CollectionViewSource.GetDefaultView(_sentance2);
            Sentance3 = CollectionViewSource.GetDefaultView(_sentance3);

            // setting up filters
            //Phrases.Filter = PhraseFilter;
            _pfilterString = "Thanks";
            Phrases.SortDescriptions.Add(new SortDescription("PhraseText", ListSortDirection.Ascending));
        }

        private bool PhraseFilter(object item)
        {
            Phrase phrase = item as Phrase;
            return phrase.PhraseText.Contains(_pfilterString);
        }
        /*
        public string FilterString
        {
            get { return _filterString; }
            set
            {
                _filterString = value;
                NotifyPropertyChanged("FilterString");
                _customerView.Refresh();
            }
        }*/
        // http://wpftutorial.net/DataViews.html
    }
}
