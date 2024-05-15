using AJS.DVDCentral.BL.Models;
using BDF.Utility;

namespace AJS.DVDCentral.MAUI
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);


            // Creating an api client and then call and figuring out the count of Movies (7) woho.
            ApiClient apiClient = new ApiClient("https://dvdcentralapi-300079087.azurewebsites.net/api/");

            var movies = apiClient.GetList<BL.Models.Movie>("Movie");

            CounterBtn.Text = movies.Count + " Movies";
        }
    }

}
