using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Collections;


namespace filmsGlossary.ViewModels
{
    
    
    /// <summary>
    /// Object for film terms. 
    /// </summary>
    public class Term
    {
        public string TermName { get; set; }
        public string TermDescription { get; set;}
        public string TermPhase { get; set; }

        public Term()
        {
            // TODO: Complete member initialization
        }

        public Term(string termName, string termDescription/*string termPhase*/)
        {
            this.TermName = termName;
            this.TermDescription = termDescription;
            //this.TermPhase = TermPhase; 
        }
        
    }
    
    class termHandling
    {
        public ObservableCollection<ViewModels.Term> launchTerms = new ObservableCollection<ViewModels.Term>();
        
        
        /// <summary>
        /// Methods to be run on app load
        /// </summary>
        /// <returns>A string</returns>
        public string onAppLoad()
        {
            var initialTerm = "Loaded String";
            return initialTerm;
        }

        ///// <summary>
        ///// Responsds to when user clicks a button.
        ///// </summary>
        ///// <returns></returns>
        //public string onTermClicked()
        //{
        //    var testTerm = "Follow Focus";
        //    return testTerm.ToString();
        //}

        // Called when a search is made
        // Call database method and query database
        // Deserialze then converts string into Json Object
        // JArray selects the first term in the object. 

        public async Task<object> sendSearchToDatabase(string userTerm)
        {
           dynamic newSearchQuery = await new Models.database().searchDatabase(userTerm);

           dynamic resultsJsonObject = JsonConvert.DeserializeObject(newSearchQuery);
           dynamic resultsJsonArray = ((JArray)resultsJsonObject.terms);


           foreach (var item in resultsJsonArray)
           {
               string itemName = item.term.termName.ToString();
               string itemDescription = item.term.termDescription.ToString();

               // New Term Object
               filmsGlossary.ViewModels.Term term = new ViewModels.Term(itemName, itemDescription);

               // Add to collection
               launchTerms.Add(term);
           }

           return launchTerms;
            
            //var formattedValue = formatJson(newSearchQuery);
            //return formattedValue;
        }

    

        

    }
}
