using Newtonsoft.Json;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using System.Net;

namespace AppFilm
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            searchButton.Clicked += SearchButton_Clicked;
        }

        private void SearchButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                string filmTitle = editText.Text.Replace(" ", "+");
                Uri mUrl = new Uri("http://www.omdbapi.com/?apikey=3869666b&t=" + filmTitle);

                using (WebClient wc = new WebClient())
                {
                    var json = wc.DownloadString(mUrl);
                    
                    Film obj = new Film();
                    obj = JsonConvert.DeserializeObject<Film>(json);

                    if (obj.Title == null)
                    {
                        Titolo.Text = "TITLE:  MOVIE NOT FOUND!";
                        Year.Text = "YEAR:  MOVIE NOT FOUND!";
                        Released.Text = "RELEASED:  MOVIE NOT FOUND!";
                        Runtime.Text = "RUNTIME:  MOVIE NOT FOUND!";
                        Genre.Text = "GENRE:  MOVIE NOT FOUND!";
                        Director.Text = "DIRECTOR:  MOVIE NOT FOUND!";
                        Writer.Text = "WRITER:  MOVIE NOT FOUND!";
                        Actors.Text = "ACTORS:  MOVIE NOT FOUND!";
                        Plot.Text = "PLOT:  MOVIE NOT FOUND!";
                        Language.Text = "LANGUAGE:  MOVIE NOT FOUND!";
                        Country.Text = "COUNTRY:  MOVIE NOT FOUND!";
                        Awards.Text = "AWARDS:  MOVIE NOT FOUND!";                        
                    }
                    else
                    {
                        Titolo.Text = "TITLE:  " + obj.Title;
                        Year.Text = "YEAR:  " + obj.Year;
                        Released.Text = "RELEASED:  " + obj.Released;
                        Runtime.Text = "RUNTIME:  " + obj.Runtime;
                        Genre.Text = "GENRE:  " + obj.Genre;
                        Director.Text = "DIRECTOR:  " + obj.Director;
                        Writer.Text = "WRITER:  " + obj.Writer;
                        Actors.Text = "ACTORS:  " + obj.Actors;
                        Plot.Text = "PLOT:  " + obj.Plot;
                        Language.Text = "LANGUAGE:  " + obj.Language;
                        Country.Text = "COUNTRY:  " + obj.Country;
                        Awards.Text = "AWARDS:  " + obj.Awards;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("EXCEPTION: " + ex + " END EXCEPTION");
            }
        }
    }
}