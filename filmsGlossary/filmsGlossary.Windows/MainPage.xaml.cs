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
            //var SearchClass = new searchQueries();
            //var searchResult = SearchClass.returnJson("BNC");
            //SearchClass.loadTerms(searchResult);
            
        }

        
        // Send search term if search bar used
        private void searchDB(object sender, RoutedEventArgs e)
        {
            var term = searchTerm.Text.ToString();
            retrieveTerm(term);           
            
        }
        
        // Send search term if term button clicked
        private void termButtonClicked(object sender, RoutedEventArgs e)
        {

            //term1.Content = "test";
            var TermButtonTest = new searchQueries();
            TermButtonTest.loadTermsTest("BNC");
            //var term = term1.Content.ToString();
            //retrieveTerm(term);
        }                 
            
            
        // Query database and retrieve search results
        private async void retrieveTerm(object term)
        {
            //Set format and retrieve term searched
            var searchFormat = "&format=json";
            var termValue = term;

            //Clean textblocks
            termName.Text = "";
            termDescription.Text = "";

            var httpClient = new HttpClient(); 
        
            try
            {                     
                //Set web service URL format
                string baseURI = "http://localhost/filmgloss/webService/web-service.php?termName=";
                string userURI = baseURI + termValue + searchFormat;

                //Send URL to web service and retrieve response code. 
                var response = await httpClient.GetAsync(userURI);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                dynamic output = JsonConvert.DeserializeObject(content);
                dynamic firstTerm = ((JArray)output.terms)[0];
                
                foreach (var item in firstTerm)
                {
                    termName.Text = firstTerm.term.termName.ToString();
                    termDescription.Text = firstTerm.term.termDescription.ToString();

                }


            }
            catch (HttpRequestException hre)
            {
                searchStatus.Text = hre.ToString();

            }
            catch (Exception ex)
            {
                // For debugging
                searchStatus.Text = ex.ToString();
            }
        }

    }

    public class searchQueries
    {
        //// Get the string to search databsae for
        //public Task setTerms(string terms)
        //{
        //    //var searchTerm = terms;
        //    var jsonResponse = returnJson(terms);
        //    //loadTerms(jsonResponse);
        //    return jsonResponse;
        //}

        public async Task<string> returnJson(string term)
        {
            //Set Variables
            var searchFormat = "&format=json";
            var termValue = term;

            var httpClient = new HttpClient();

            try
            {
                //Set web service URL format
                string baseURI = "http://localhost/filmgloss/webService/web-service.php?termName=";
                string userURI = baseURI + termValue + searchFormat;

                //Send URL to web service and retrieve response code. 
                var response = await httpClient.GetAsync(userURI);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                loadTermsTest(content);
                return content.ToString();
                
            }
            catch (HttpRequestException hre)
            {
                var content = hre;
                return content.ToString();
            }
            catch (Exception ex)
            {
                var content = ex;
                return content.ToString();
            }

        }

        public void loadTermsTest(string term)
        {
            var TermTest = new MainPage();
            var receivedTerm = "BNC";
            var termTestContent = TermTest.term1.Content;
            TermTest.term1.Content = receivedTerm.ToString();
        }

        // Load full list of terms
        public void loadTerms(object json)
        {
            //dynamic buttonText = ((JArray)output.terms)[0];
            //termLayout.term1.Content = buttonText.term.termName.ToString();
            //dynamic testJson = json;
            //var termLayout = new MainPage();

            //dynamic output = JsonConvert.DeserializeObject(testJson);
            //dynamic manipulateOutput = ((JArray)output.terms);
            //int objCount = manipulateOutput.Count;

            //dynamic buttonText = ((JArray)output.terms)[0];
            //termLayout.term1.Content = buttonText.term.termName.ToString();

            //for (int i = 0; i < objCount; i++)
            //{
            //    dynamic buttonText = ((JArray)output.terms)[i];
            //    termLayout.term1.Content = buttonText.term.termName.ToString();
            //}

        }
        
    }
    
}
