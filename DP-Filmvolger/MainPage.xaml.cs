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
       
        public IEnumerable<MovieDecorator> movies;
        public IEnumerable<MovieDecorator> favMovies;     // Vullen met Favorites
        public IEnumerable<SerieDecorator> favSeries;     // Vullen met Favorites
        public IEnumerable<MovieDecorator> ratedMovies;     // Vullen met Favorites
        public IEnumerable<SerieDecorator> ratedSeries;     // Vullen met Favorites
        public SeasonSubject seasonSubject = new SeasonSubject();
        public IState mediaState;
        public IState favoriteState;
        public RatingsState ratingsState;

        ApiHandler handler = new ApiHandler();
        public MainPage()
        {
            this.InitializeComponent();
            DummyDataFill();
        }



        public void DummyDataFill()
        {
            favMovies = DummyData.Favourites.Where(c => c.GetType() == typeof(MovieDecorator)).Select(c => (MovieDecorator)c);
            favSeries = DummyData.Favourites.Where(c => c.GetType() == typeof(SerieDecorator)).Select(c => (SerieDecorator)c);
            ratedMovies = DummyData.Ratings.Where(c => c.GetType() == typeof(MovieDecorator)).Select(c => (MovieDecorator)c);
            ratedSeries = DummyData.Ratings.Where(c => c.GetType() == typeof(SerieDecorator)).Select(c => (SerieDecorator)c);
            favList.ItemsSource = favMovies;
        }


        public void ChangeState(IState state)     // Not Functional
        {
            if (state != null)
            {
                state.Handle(this);
            }
            Debug.WriteLine("state empty");
        }

        public void HideAll()    
        {
            MediaGrid.Visibility = Visibility.Collapsed;
            FavGrid.Visibility = Visibility.Collapsed;
            RatingGrid.Visibility = Visibility.Collapsed;
            Debug.WriteLine("all grids hidden");
        }

        public void ShowMedia() { MediaGrid.Visibility = Visibility.Visible; }
        public void ShowFavorites() { FavGrid.Visibility = Visibility.Visible; }
        public void ShowRating() { RatingGrid.Visibility = Visibility.Visible; }

        // SearchButton
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            new MediaState().Handle(this);
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
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new FavouritesState().Handle(this);
        }

        // RatingButton
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            new RatingsState().Handle(this);
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

        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch != null)
            {
                if (toggleSwitch.IsOn == true)
                {
                   
                }
                else
                {
           
                }
            }
        }

        public void UpdateMessage(string message)
        {
            ObserverText.Text = message;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Observer observer = new Observer();
            Notification.InsertPage(this);
            seasonSubject.Register(observer);
            seasonSubject.NotifyObservers("TestBericht");
          
        }
    }
}
