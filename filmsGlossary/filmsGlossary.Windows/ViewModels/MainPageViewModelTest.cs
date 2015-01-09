using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmsGlossary.Models;
using FilmsGlossary.Common;

namespace FilmsGlossary.ViewModels
{
    public class MainPageViewModelTest
    {
        public Customer MyCustomer { get; set; }
        public MainPageViewModelTest()
        {
            MyCustomer = new Customer()
            { 
                FirstName = "Bob", 
                LastName = "Smith" 
            };
        }

        private RelayCommand _updateNameCommand;

        private void UpdateName ()
        {
            MyCustomer.FirstName = "Sue";
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

    }

    


}
