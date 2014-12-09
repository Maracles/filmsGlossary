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
        public ObservableCollection<ViewModels.FilmTerm> MyTerms = new ObservableCollection<ViewModels.FilmTerm>();

        public MainPage()
        {   

            this.InitializeComponent();
            //appTermInitialisation();
            
        }
        

        // On appLoad change the content of the buttons to those of the terms 
        // retrieved from the data base
        public void appTermInitialisation()
        {
            var initialisationValue = new ViewModels.terms().onAppLoad();
            term1.Content = initialisationValue.ToString();
        }

        // Send search term if term button clicked
        private void termButtonClicked(object sender, RoutedEventArgs e)
        {
            var buttonMethod = new ViewModels.terms();
            var changeTerm = buttonMethod.onTermClicked();

            term1.Content = changeTerm;
        }

        // Send search term if search button pressed. 
        //<param = sender> Not actually sure what this is - find out. 
        //<param = e> Not actually sure what this is - find out. 
        private async void userSearchSubmitted(object sender, RoutedEventArgs e)
        {

            var searchedTerm = searchTerm.Text.ToString();     
            var newSearchInstance = new ViewModels.terms();
                   
            if (searchedTerm != "")
            {
                // Create JSON object of returned searchr result
                dynamic newSearchInstanceValue = await newSearchInstance.onSearchSubmitted(searchedTerm);
                dynamic content = ((JArray)newSearchInstanceValue.terms)[0];
                
                //Set Variables for Data Binding
                dynamic name = content.term.termName.ToString();
                dynamic description = content.term.termDescription.ToString();

                //Create New Film Term Object and Add it to MyTerms Collection
                MyTerms.Add(new ViewModels.FilmTerm(name, description));

                //Set Display Fields
                termName.DataContext = MyTerms[0].Name;
                termDescription.DataContext = MyTerms[0].Description;

            }
            else
            {

                //Output to View
                termName.Text = "Search Field Empty";
                termDescription.Text = "You have not entered anything. Please enter the term you'd like us to find."; 

            }
        }

        //If the user sets focus on the textbox
        //clear the text that it is more user friendly to enter text
        private void searchboxGotFocus(object sender, RoutedEventArgs e)
        {
            searchTerm.Text = "";

        }

        //If the user preses term on the textbox 
        //call the search method and retrieve the term. This is a shortcut to 
        //clicking the submit button. 
        private void onSearchKeyPressDown(object sender, KeyRoutedEventArgs e)
        {
            var keyCode = e.Key.ToString();


            if (keyCode.ToString() == "Enter")
            {
                userSearchSubmitted(sender, e);
            }
        }
            
        

    }

    

    
}
