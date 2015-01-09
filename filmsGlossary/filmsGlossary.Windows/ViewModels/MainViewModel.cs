using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using System.Collections.Specialized;
using FilmsGlossary.Models;
using FilmsGlossary.Common;

namespace FilmsGlossary.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        
        //member variables
        private ObservableCollection<Term> TermName;

        #region MainViewModel Parameters

        // A property
        public ObservableCollection<Term> TermsCollection
        {
            get { return TermName; }
            set
            {
                TermName = value;
                NotifyPropertyChanged();
            }
        }
        
        #endregion

        // Constructor
        public MainViewModel()
        {

        }

        // Overloaded Constructor
        public MainViewModel (string term)
        {
            DisplayLaunchTerms(term); 

        }


        // Return a observabe collection to be displayed
        public ObservableCollection<Term> DisplayLaunchTerms(string searchValue)
        {
            ObservableCollection<Term> TermsCollection = null;
            ObservableCollection<Term> result = null;

            result = QueryRequest(searchValue).Result;
            TermsCollection = result;
            return TermsCollection;
        }

        // Query the model for the data
        public async Task<ObservableCollection<Term>> QueryRequest(string userTerm)
        {
            var searchTerm = new Models.Data().GetResponse(userTerm);
            return searchTerm.Result;
        }



        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            var handler = PropertyChanged;
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
