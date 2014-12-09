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

namespace filmsGlossary
{   
     

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class MainPage : Page
    {
        
        //Observable collection for film terms. 
        //public ObservableCollection<ViewModels.Term> launchTerms = new ObservableCollection<ViewModels.Term>();

        public MainPage()
        {   

            this.InitializeComponent();
            //appTermInitialisation();

        }
        
        /// <summary>
        /// On appLoad change the content of the buttons to those of the terms retrieved from the data base  
        /// </summary>
        public void appTermInitialisation()
        {
            
            var initialisationValue = new ViewModels.termHandling().onAppLoad();
            
        }

        // Send search term if term button clicked
        private void termButtonClicked(object sender, RoutedEventArgs e)
        {
            
        }

        
        /// <summary>
        /// If user submits a search send entered term to Search classes
        /// Take returned JSon object and bind it to various XAML controls 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void userSearchSubmitted(object sender, RoutedEventArgs e)
        {
            var searchedTerm = searchTerm.Text.ToString();
            ListView termsList = termsListContainer;

            if (searchedTerm != "")
            {
                
                dynamic newSearchInstanceValue = await new ViewModels.termHandling().sendSearchToDatabase(searchedTerm);
                int count = newSearchInstanceValue.Count;

                for (int i = 0; i < count; i++)
                {
                    termsList.Items.Add(newSearchInstanceValue[i].TermName);
                    //termsList.ItemsSource = launchTerms[i].TermName;
                }

                //termName.DataContext = MyTerms[0].Name;
                //termDescription.DataContext = MyTerms[0].Description;
                
            }
            else
            {
                termName.Text = "Search Field Empty";
                termDescription.Text = "You have not entered anything. Please enter the term you'd like us to find."; 
            }
        }

        
        
        /// <summary>
        /// If the user sets focus on the textbox clear the text that it is more user friendly to enter text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchboxGotFocus(object sender, RoutedEventArgs e)
        {
            searchTerm.Text = "";

        }

        /// <summary>
        /// If the user preses term on the textbox call the search method and retrieve the term. 
        /// This is a shortcut to clicking the submit button. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onSearchKeyPressDown(object sender, KeyRoutedEventArgs e)
        {
            
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                userSearchSubmitted(sender, e);
            }
        }
        
    }
}
