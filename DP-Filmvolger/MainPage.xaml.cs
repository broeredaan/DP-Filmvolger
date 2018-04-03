using DP_Filmvolger.Classes;
using DP_Filmvolger.Classes.State;

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
        public IEnumerable<Movie> movies;
        public IEnumerable<Movie> favMovies;     // Vullen met Favorites
        public IState mediaState;
        public IState favoriteState;
        public RatingsState ratingsState;

        ApiHandler handler = new ApiHandler();
        public MainPage()
        {
            this.InitializeComponent();
            DummyData();
        }

        public async void DummyData()
        {
            favMovies = await handler.SearchMovie("buurman");
            favList.ItemsSource = favMovies;
        }


        public void ChangeState(IState state)         // Not Functional
        {
            if (state != null)
            {
                MediaGrid.Visibility = Visibility.Collapsed;
                FavGrid.Visibility = Visibility.Collapsed;
                RatingGrid.Visibility = Visibility.Collapsed;

                var find = state.DisplayGrid();


                Grid grid = FindName(find) as Grid;
                grid.Visibility = Visibility.Visible;
            }
            Debug.WriteLine("state empty");
        }
        
        // SearchButton
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            MediaGrid.Visibility = Visibility.Visible;
            FavGrid.Visibility = Visibility.Collapsed;
            RatingGrid.Visibility = Visibility.Collapsed;
            if (!String.IsNullOrEmpty(Search.Text))
            {
                movies = await handler.SearchMovie(Search.Text.ToString());
                if (movies == null)
                {
                    Debug.WriteLine("Movie is Null");
                    confirmDialog("Error", "Unable to get movie.");
                    return;
                }
                else
                {
                    foreach (var movie in movies)
                    {
                        Debug.WriteLine(movie.Title);
                    }
                    DataList.ItemsSource = movies;
                }
            }
            else
            {
                Debug.WriteLine("Search failed no entry");
                confirmDialog("Error", "Please fill in a movie to search .");
                return;
            }
        }

        // FavoritesButton
        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //  ChangeState(favoriteState);
            MediaGrid.Visibility = Visibility.Collapsed;
            FavGrid.Visibility = Visibility.Visible;
            RatingGrid.Visibility = Visibility.Collapsed;
        }

        // RatingButton
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            MediaGrid.Visibility = Visibility.Collapsed;
            FavGrid.Visibility = Visibility.Collapsed;
            RatingGrid.Visibility = Visibility.Visible;
        }

        // Click on Item in List
        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
      
        }

        //
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
