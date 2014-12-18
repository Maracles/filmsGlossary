using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Collections;

namespace FilmsGlossary.ViewModels
{

    class ErrorConstants
    {
        public const int EmptyInput = 1;
        public const int NullInput = 2;
    }

    /// <summary>
    /// To avoid errors check that the user's input is valid. 
    /// </summary>
    class Validation
    {
        public int? ErrorCode { get; private set; }
        public string ErrorName { get; private set; }
        public string ErrorMessage { get; private set; }

        public Boolean HasError { get { return ErrorCode.HasValue; } }    
        
        public Validation ValidateInput(string input)
        {
            if (input == null)
            {
                this.ErrorCode = ErrorConstants.NullInput;
                this.ErrorName = "Input null";
                this.ErrorMessage = "Given input is null";
            }
            else if (input.Length == 0)
            {
                this.ErrorCode = ErrorConstants.EmptyInput;
                this.ErrorName = "Input Empty";
                this.ErrorMessage = "You have not input anything.";
            }
            return this;
        }
    }

}
