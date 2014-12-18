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
    /// <summary>
    /// Object for film terms. 
    /// </summary>
    public class Term
    {
        public string TermName { get; private set; }
        public string TermDescription { get; private set;}
        
        public Term ()
        {

        }

        public Term(string termName, string termDescription)
        {
            this.TermName = termName;
            this.TermDescription = termDescription;
        }
    }
}
