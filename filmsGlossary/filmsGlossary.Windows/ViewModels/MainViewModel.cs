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
        
        private object _term;
        private object _termsCollection;  

        public object Term
        {
            get { return _term; }
            set
            {
                _term = value;
                OnPropertyChanged();
            }
        }

        public object TermsCollection
        {
            get { return _termsCollection; }
            set
            {
                _termsCollection = value;
                //OnPropertyChanged();
            }
        }


        // Test Constructor
        public MainViewModel()
        {
            DisplayLaunchTerms("BNC"); 
            SetTerm("Monitor", "Screen");
        }

        //Test Method
        public void SetTerm(string termName, string termDescription)
        {
            Term = new Term("Monitor", "Screen");
        }   
       

        // Return a observabe collection to be displayed
        public void DisplayLaunchTerms(string searchValue)
        {
            ObservableCollection<Term> result = null;

            result = QueryRequest(searchValue);
            TermsCollection = result; 
            //return TermsCollection;
        }

        //// Query the model for the data
        public ObservableCollection<Term> QueryRequest(string userTerm)
        {
            var searchTerm = new Models.Data().GetResponse(userTerm);
            return searchTerm.Result;
        }       


        #region INotifyPropertyChanged handler

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }

        #endregion

    }

    
    
}
