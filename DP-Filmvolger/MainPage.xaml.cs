using DP_Filmvolger.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DP_Filmvolger
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ApiHandler handler = new ApiHandler();
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Movie movie = await handler.GetMovie("tt0111161");
            if (movie == null)
            {
                confirmDialog("Error", "Unable to get movie.");
                return;
            }
            else
            {
                confirmDialog(movie.Title, movie.Plot);
                var postUrl = new Uri(movie.PosterUrl);
                Poster.Source = new BitmapImage(postUrl);
            }
            
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            IEnumerable<Movie> movies = await handler.SearchMovie(Search.Text);
            if (movies == null)
            {
                confirmDialog("Error", "Unable to get movie.");
                return;
            }
            else
            {
                foreach(var movie in movies)
                {
                    Debug.WriteLine(movie.Title);
                }
                
            }
        }

        public async void confirmDialog(string title, string content)
        {
            ContentDialog testDialog = new ContentDialog
            {
                Title = title,
                Content = content,
                PrimaryButtonText = "Okay"
            };
            ContentDialogResult result = await testDialog.ShowAsync();
        }
    }
}
