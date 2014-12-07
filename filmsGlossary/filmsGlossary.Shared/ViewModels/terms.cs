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

        public async Task<object> onSearchSubmitted(string searchTerm)
        {
            // Retrieve submitted value
            var value = searchTerm;

            var returnedSearchValue = await new Models.database().searchTerm(value);
            dynamic formattedValue = formatJson(returnedSearchValue);
            dynamic content = ((JArray)formattedValue.terms)[0];
            return content;
        }

        // Converted returned Object into a JSON object. 
        public object formatJson(object value)
        {
            dynamic jsonTask = value;
            dynamic output = JsonConvert.DeserializeObject(jsonTask);
            dynamic outputArray = ((JArray)output.terms)[0];
            return output;

        }

        

    }
}
