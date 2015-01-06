using FilmsGlossary.ViewModels;
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
using FilmsGlossary.Models;
using FilmsGlossary.ViewModels;

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
            //this.InitializeComponent();
            InitializeComponent();
            this.DataContext = new MainViewModel("BNC");
        }

        /// <summary>
        /// If user submits a search send entered term to Search classes
        /// Take returned JSon object and bind it to various XAML controls 
        /// </summary>
        private async void SubmitSearch(object sender, RoutedEventArgs e)
        {
            Validation _validation = new Validation();
            MainViewModel _search = new MainViewModel(); 


            var _searchValue = searchTerm.Text;

            if (_validation.ValidateInput(_searchValue).HasError)
            {
                //DataContext = new MainViewModel(searchValue);
            }
            else
            {
                //this.DataContext = new MainViewModel("BNC");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void RemoveTerms ()
        {
            searchTerm.Text = "";
        }

        /// <summary>
        /// If the user preses term on the textbox call the search method and retrieve the term. 
        /// This is a shortcut to clicking the submit button. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnSearchKeyPressDown(object sender, KeyRoutedEventArgs e)
        {
            ListView _termsList = termsListContainer;            

            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (e.KeyStatus.RepeatCount == 1)
                {
                    SubmitSearch(sender, e);

                }
            }
        }

        /// <summary>
        /// Remove placeholder text once selected. Employ failsafe to ensure
        /// that the box is not wiped each time box gets focus, only once 
        /// per page load. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SearchboxGotFocus(object sender, RoutedEventArgs e)
        {
            var _placeholderText = "enter search term...";
            string _value = searchTerm.Text;

            if (_value == _placeholderText)
            {
                searchTerm.Text = "";
            }

        }

        private void termClicked(object sender, RoutedEventArgs e)
        {
            // hardcoded and needs to retrive content property from button clicked
            MainViewModel ViewModel = new MainViewModel("BNC");
            string _test = "BNC";
        }
        
    }
}
