using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace FilmsGlossary
{   
     
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class MainPage : Page
    {
        
        public MainPage()
        {   
            this.InitializeComponent();
            //appTermInitialisation();
        }
        
        /// <summary>
        /// On appLoad change the content of the buttons to those of the terms retrieved from the data base  
        /// </summary>
        public void AppInitialisation()
        {   
            var initialisationValue = new ViewModels.AppLoad().onAppLoad();
        }        
        
        /// <summary>
        /// If user submits a search send entered term to Search classes
        /// Take returned JSon object and bind it to various XAML controls 
        /// </summary>
        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubmitSearch(object sender, RoutedEventArgs e)
        {
            ViewModels.validation validation = new ViewModels.validation();
            
            var searchValue = searchTerm.Text.ToString();
            dynamic validateInput = validation.inputNullCheck(searchValue);
            
            // Check error code
            int? errorCode = validateInput.ErrorCode;

            if (errorCode == 0)
            {
                SubmitAction(searchValue);
            }
            else
            {
                DisplayTerms(validateInput);
            }

        }

        /// <summary>
        /// Capture the user entered search string..
        /// If string is null request error.
        /// NOTE: Need to fix the else statement - does not work properly. 
        /// </summary>
        /// <returns></returns>
        public async Task<object> SubmitAction(string searchValue)
        {
            
            dynamic response = await new ViewModels.Search().QueryRequest(searchValue);
            RemoveTerms();
            DisplayTerms(response);
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        private void DisplayTerms(object value)
        {
            ListView termsList = termsListContainer;
            dynamic searchResponse = value;

            int count = searchResponse.Count;

            termsList.Items.Add(searchResponse[0].TermName);

            //for (int i = 0; i < count; i++)
            //{
                
            //    termsList.Items.Add(searchResponse[i].TermName);
            //    //termsList.ItemsSource = launchTerms[i].TermName;
            //}


            
            //termName.DataContext = MyTerms[0].Name;
            //termDescription.DataContext = MyTerms[0].Description;

        }


        /// <summary>
        /// 
        /// </summary>
        private void RemoveTerms ()
        {
            
        }

        /// <summary>
        /// If the user preses term on the textbox call the search method and retrieve the term. 
        /// This is a shortcut to clicking the submit button. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSearchKeyPressDown(object sender, KeyRoutedEventArgs e)
        {
            var searchValue = searchTerm.Text.ToString();

            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                SubmitAction(searchValue);
            }
        }        


        
        /// <summary>
        /// If the user sets focus on the textbox clear the text that it is more user friendly to enter text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchboxGotFocus(object sender, RoutedEventArgs e)
        {
            searchTerm.Text = "";

        }

        
        
    }
}
