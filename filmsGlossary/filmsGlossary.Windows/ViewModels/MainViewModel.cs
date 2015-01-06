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
        // An event
        private RelayCommand _updateNameCommand;

        //member variables
        private ObservableCollection<Term> TermName;
        private ObservableCollection<Term> TermDescription;
        private String Test;
        

        private void UpdateName()
        {

        }

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

        public string SelectedX
        {
            get { return Test; }
            set
            {
                Test = value;
                NotifyPropertyChanged();
            }
        }

        public RelayCommand UpdateNameCommand
        {
            get
            {
                if (_updateNameCommand == null)
                {
                    _updateNameCommand = new RelayCommand(UpdateName);
                }
                return this._updateNameCommand;
            }
            set
            {
                this._updateNameCommand = value;
            }
        }
        
        #endregion

        // Overloaded Constructor
        public MainViewModel()
        {
            
        }

        // Overloaded Constructor
        public MainViewModel (string term)
        {
            ObservableCollection<Term> test = null;
            DisplayLaunchTerms(term);  
            
            var test2 = "";
        }

        public async Task<ObservableCollection<Term>> DisplayLaunchTerms(string searchValue)
        {
            ObservableCollection<Term> TermsCollection = null;
            ObservableCollection<Term> result = null;
            
            result = await QueryRequest(searchValue);
            TermsCollection = result;
            return TermsCollection;
        }

        public async Task<ObservableCollection<Term>> QueryRequest(string userTerm)
        {
            var searchTerm = await new Models.Data().GetResponse(userTerm);
            return searchTerm;
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
