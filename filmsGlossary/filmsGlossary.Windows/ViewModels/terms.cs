using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.Foundation.Collections;


namespace FilmsGlossary.ViewModels
{
    /// <summary>
    /// Object for film terms. 
    /// </summary>
    public class Term //: INotifyPropertyChanged
    {
        private string termName;
        private string termDescription;

        #region Term Parameters

        public string TermName {
            get { return this.termName; }
            set {
                    if (value != termName)
                    {
                        this.termName = value;
                        //OnPropertyChanged();
                    }   
                }
        }

        public string TermDescription {
            get { return this.termDescription; }
            set
            {
                if (value != termDescription)
                {
                    this.termDescription = value;
                    //OnPropertyChanged();
                }
            }
        }

        #endregion

        public Term ()
        {

        }

        public Term(string termName, string termDescription)
        {
            TermName = termName;
            TermDescription = termDescription;
        }

        //#region Property Changed
        //public event PropertyChangedEventHandler PropertyChanged;

        //internal void OnPropertyChanged([CallerMemberName] string member = "")
        //{
        //    PropertyChangedEventHandler handler = PropertyChanged;
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(member));
        //    }
        //}
        //#endregion
    }
}
