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

namespace FilmsGlossary.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel ()
        {
            dsiplayLaunchTerms("BNC");
        }


        private ObservableCollection<Term> TermName;
        private ObservableCollection<Term> TermDescription;

        public ObservableCollection<Term> TermsCollection
        {
            get { return TermName; }
            set { 
                    TermName = value;
                    TermDescription = value;
                    NotifyPropertyChanged(); 
                }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
              var handler = PropertyChanged;
              if (handler != null)
                  handler(this, new PropertyChangedEventArgs(propertyName));
        }


        public async void dsiplayLaunchTerms(string searchValue)
        {
            Search loadSearch = new Search();
            var result = await loadSearch.QueryRequest(searchValue);
            TermsCollection = result;
        }

        public void displayClickedTerm(string value)
        {

        }
    }
}
