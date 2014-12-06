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
        }

        // Send search term if term button clicked
        private void termButtonClicked(object sender, RoutedEventArgs e)
        {
            var buttonMethod = new ViewModels.terms();
            var changeTerm = buttonMethod.onTermClicked();

            term1.Content = changeTerm;
        }  
        
        //Test comment change
        // Send search term if search bar used
        private async void onSearchSubmit(object sender, RoutedEventArgs e)
        {   
            
            var newSearchInstance = new ViewModels.terms();
            var searchedTerm = searchTerm.Text.ToString();            

            if (searchedTerm != "")
            {
                // Set termName to the value returned
                dynamic newSearchInstanceValue = await newSearchInstance.onSearchSubmitted(searchedTerm);
                dynamic content = ((JArray)newSearchInstanceValue.terms)[0];
                
                //Output to View
                termName.Text = content.term.termName.ToString();
                termDescription.Text = content.term.termDescription.ToString(); 
            }
            else
            {

                //Output to View
                termName.Text = "Search Field Empty";
                termDescription.Text = "You have not entered anything. Please enter the term you'd like us to find."; 

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
