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
using System.Windows.Input;

namespace FilmsGlossary.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Parameters

        private object term;
        private object termsCollection;  

        public object Term
        {
            get { return term; }
            set
            {
                term = value;
                OnPropertyChanged();
            }
        }

        public object TermsCollection
        {
            get { return termsCollection; }
            set
            {
                termsCollection = value;
                //OnPropertyChanged();
            }
        }

        #endregion  


        // Test Constructor
        public MainViewModel()
        {
            PopulateSideBar("BNC");                      
        }     

        // Return a observabe collection to be displayed
        public void PopulateSideBar(string searchValue)
        {
            ObservableCollection<Term> resultCollection = null;

            resultCollection = QueryRequest(searchValue);
            TermsCollection = resultCollection; 
        }

        public void SearchTerm()
        {

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
