using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filmsGlossary.ViewModels
{
    class terms
    {
        public string onAppLoad()
        {
            var initialTerm = "Loaded String";
            return initialTerm;
        }


        public string onTermClicked()
        {
            var testTerm = "Follow Focus";
            return testTerm.ToString();
        }

        // Called when a search is made
        // Call database method and query database
        // Deserialze then converts string into Json Object
        // JArray selects the first term in the object. 
        public async Task<object> onSearchSubmitted(string userTerm)
        {
           dynamic newSearchQuery = await new Models.database().searchDatabase(userTerm);

           dynamic resultsJsonObject = JsonConvert.DeserializeObject(newSearchQuery);
           dynamic resultsJsonArray = ((JArray)resultsJsonObject.terms)[0];
           return resultsJsonArray;
            
            //var formattedValue = formatJson(newSearchQuery);
            //return formattedValue;
        }

        public object formatJson(object value)
        {
            dynamic jsonTask = value;
            
            dynamic output = JsonConvert.DeserializeObject(jsonTask);
            dynamic outputArray = ((JArray)output.terms)[0];
            return output;

        }

        

    }
}
