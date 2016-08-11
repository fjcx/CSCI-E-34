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
using Microsoft.Win32;

namespace A5Proto2.Views
{
    /// <summary>
    /// Interaction logic for AudioPlayerView.xaml
    /// </summary>
    public partial class AudioPlayerView : UserControl
    {
        private bool mediaPlayerIsPlaying = false; 
        private bool userIsDraggingSlider = false;

        public AudioPlayerView()
        {
            InitializeComponent();
        }

        private void Open_CanExecute(object sender, CanExecuteRoutedEventArgs e) { 
            e.CanExecute = true; 
        }

        private void Open_Executed(object sender, ExecutedRoutedEventArgs e) { 
            OpenFileDialog openFileDialog = new OpenFileDialog(); 
            openFileDialog.Filter = "Media files (*.mp3;*.mpg;*.mpeg)|*.mp3;*.mpg;*.mpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                mePlayer.Source = new Uri(openFileDialog.FileName);
            }
        }

        private void Play_CanExecute(object sender, CanExecuteRoutedEventArgs e) { 
            e.CanExecute = (mePlayer != null) && (mePlayer.Source != null); 
        }

        private void Play_Executed(object sender, ExecutedRoutedEventArgs e) { 
            mePlayer.Play(); 
            mediaPlayerIsPlaying = true; 
        }

        private void Pause_CanExecute(object sender, CanExecuteRoutedEventArgs e) { 
            e.CanExecute = mediaPlayerIsPlaying; 
        }                

        private void Pause_Executed(object sender, ExecutedRoutedEventArgs e) { 
            mePlayer.Pause(); 
        }

        private void Stop_CanExecute(object sender, CanExecuteRoutedEventArgs e) { 
            e.CanExecute = mediaPlayerIsPlaying; 
        } 
               
        private void Stop_Executed(object sender, ExecutedRoutedEventArgs e) { 
            mePlayer.Stop(); 
            mediaPlayerIsPlaying = false; 
        }                
        private void sliProgress_DragStarted(object sender, DragStartedEventArgs e) { 
            userIsDraggingSlider = true; 
        }             
        
        private void Grid_MouseWheel(object sender, MouseWheelEventArgs e) { 
            mePlayer.Volume += (e.Delta > 0) ? 0.1 : -0.1; 
        }

        private void showPanel1(object sender, MouseButtonEventArgs e)
        {
            int marginleft = int.Parse(((Image)sender).Tag.ToString());
            panal1Poly.Margin = new Thickness(marginleft, 0, 0, 0);
            previewPanal2.Visibility = Visibility.Collapsed;
            previewPanal1.Visibility = Visibility.Visible;
        }

        private void showPanel2(object sender, MouseButtonEventArgs e)
        {
            int marginleft = int.Parse(((Image)sender).Tag.ToString());
            panal2Poly.Margin = new Thickness(marginleft, 0, 0, 0);
            previewPanal1.Visibility = Visibility.Collapsed;
            previewPanal2.Visibility = Visibility.Visible;
        }
    }
}
