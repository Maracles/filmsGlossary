using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Collections;

namespace FilmsGlossary.ViewModels
{
    class validation
    {
        
        // Temporarily 0 = success, 1 = error
        public int? ErrorCode { get; set; }
        public string ErrorName { get; set; }
        public string ErrorMessage { get; set; }
        
        //Constructor    
        public validation ()
        {

        }
            

        public object inputNullCheck(string input)
        {
            if (input != "")
            {
                this.ErrorCode = 0;
                this.ErrorName = "Success";
                this.ErrorMessage = "Valid input received";
                return this;
            }
            else
            {
                this.ErrorCode = 1;
                this.ErrorName = "Input Empty";
                this.ErrorMessage = "You have not input anything.";
                return this; 
            }
        }
    }

}
