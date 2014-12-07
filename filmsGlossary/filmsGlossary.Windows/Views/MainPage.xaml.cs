using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace filmsGlossary
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();
            appTermInitialisation();
        }

        // On appLoad change the content of the buttons to those of the terms 
        // retrieved from the data base
        public void appTermInitialisation()
        {
            var initialisationValue = new ViewModels.terms().onAppLoad();
            term1.Content = initialisationValue.ToString();
        }

        //Testing again
        //Send search term if term button clicked
        //<param = sender> Not actually sure what this is - find out. 
        //<param = e> Not actually sure what this is - find out. 
        private void termButtonClicked(object sender, RoutedEventArgs e)
        {
            var buttonMethod = new ViewModels.terms();
            var changeTerm = buttonMethod.onTermClicked();

            term1.Content = changeTerm;
        }  
        
        // Send search term if search bar used
        //<param = sender> Not actually sure what this is - find out. 
        //<param = e> Not actually sure what this is - find out. 
        private async void onSearchSubmit(object sender, RoutedEventArgs e)
        {   
            
            var newSearchInstance = new ViewModels.terms();
            var searchedTerm = searchTerm.Text.ToString();            

            // Check if the user has entered and text and return an error if not. 
            if (searchedTerm != "")
            {
                // Set termName to the value returned
                dynamic newSearchInstanceValue = await newSearchInstance.onSearchSubmitted(searchedTerm);
                termName.Text = newSearchInstanceValue.term.termName.ToString();
                termDescription.Text = newSearchInstanceValue.term.termDescription.ToString(); 
            }
            else
            {

                termName.Text = "Search Field Empty";
                termDescription.Text = "You have not entered anything. Please enter the term you'd like us to find."; 

            }

        }

        //If the user sets focus on the textbox
        //clear the text that it is more user friendly to enter text
        private void textGotFocus(object sender, RoutedEventArgs e)
        {
            searchTerm.Text = "";
            
        }

        //If the user preses term on the textbox 
        //call the search method and retrieve the term. This is a shortcut to 
        //clicking the submit button. 
        private void checkEnter(object sender, KeyRoutedEventArgs e)
        {
            var keyCode = e.Key.ToString();
            

            if (keyCode.ToString() == "Enter")
            {
                onSearchSubmit(sender, e);
            }
        }

       
            
        //// Query database and retrieve search results
        //private async void retrieveTerm(object term)
        //{
        //    //Set format and retrieve term searched
        //    var searchFormat = "&format=json";
        //    var termValue = term;

        //    //Clean textblocks
        //    termName.Text = "";
        //    termDescription.Text = "";

        //    var httpClient = new HttpClient(); 
        
        //    try
        //    {                     
        //        //Set web service URL format
        //        string baseURI = "http://localhost/filmgloss/webService/web-service.php?termName=";
        //        string userURI = baseURI + termValue + searchFormat;

        //        //Send URL to web service and retrieve response code. 
        //        var response = await httpClient.GetAsync(userURI);
        //        response.EnsureSuccessStatusCode();

        //        var content = await response.Content.ReadAsStringAsync();

        //        dynamic output = JsonConvert.DeserializeObject(content);
        //        dynamic firstTerm = ((JArray)output.terms)[0];
                
        //        foreach (var item in firstTerm)
        //        {
        //            termName.Text = firstTerm.term.termName.ToString();
        //            termDescription.Text = firstTerm.term.termDescription.ToString();

        //        }


        //    }
        //    catch (HttpRequestException hre)
        //    {
        //        searchStatus.Text = hre.ToString();

        //    }
        //    catch (Exception ex)
        //    {
        //        // For debugging
        //        searchStatus.Text = ex.ToString();
        //    }
        //}

    }
    
}
