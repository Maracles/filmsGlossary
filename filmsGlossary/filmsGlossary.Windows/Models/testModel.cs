using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FilmsGlossary.Models
{
    public class Customer : INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;
        
        public string FirstName
        {
            get
            {
                return this._firstName;
            }
            set
            {
                if (value != _firstName)
                {
                    this._firstName = value;
                    onPropertyChanged();
                }
            }
        }

        public string LastName
        {
            get
            {
                return this._lastName;
            }
            set
            {
                if (value != _lastName)
                {
                    this._lastName = value;
                    onPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        internal void onPropertyChanged([CallerMemberName] string member = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(member));
            }
        }

    }
}
