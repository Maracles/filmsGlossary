﻿using System;
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
        private string _name;
        public string Name
        {
            get { return _name; }
            set 
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public void SetName(string newName)
        {
            Name = newName;
        }

        // Constructor
        public MainViewModel()
        {
            SetName("James");
        }

        // Overloaded Constructor
        public MainViewModel (string term)
        {

            //DisplayLaunchTerms(term); 

        }

        // Return a observabe collection to be displayed
        //public ObservableCollection<Term> DisplayLaunchTerms(string searchValue)
        //{
        //    //ObservableCollection<Term> TermsCollection = null;
        //    //ObservableCollection<Term> result = null;

        //    //result = QueryRequest(searchValue);
        //    //TermsCollection = result;
        //    //return TermsCollection;
        //}

        //// Query the model for the data
        //public ObservableCollection<Term> QueryRequest(string userTerm)
        //{
        //    //var searchTerm = new Models.Data().GetResponse(userTerm);
        //    //return searchTerm.Result;
        //}       



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }
        
    }

    
    
}
