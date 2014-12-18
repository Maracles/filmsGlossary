using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsGlossary.ViewModels
{
    class Search
    {
        // New collection to hold retrieve termName/termDescription pairs
        public ObservableCollection<Term> collection = new ObservableCollection<Term>();

        /// <summary>
        /// Capture the user entered search string..
        /// If string is null request error.
        /// Reason it is here is because I need to call DisplayTerms which I can't do elsewhere.
        /// </summary>
        public async void SubmitAction(string searchValue)
        {
            dynamic response = await new ViewModels.Search().QueryRequest(searchValue);
        }

        // Called when a search is made
        // Call database method and query database
        // Deserialze then converts string into Json Object
        // JArray selects the first term in the object. 

        public async Task<ObservableCollection<Term>> QueryRequest(string userTerm)
        {
            string newSearchQuery = await new Models.Data().SearchDatabase(userTerm);
            dynamic resultsJsonObject = JsonConvert.DeserializeObject(newSearchQuery);
            dynamic resultsJsonArray = ((JArray)resultsJsonObject.term);

            int jsonCount = resultsJsonArray.Count;

            for (int i = 0; i < jsonCount; i++)
            {
                string itemName = resultsJsonArray[i].termName;
                string itemDescription = resultsJsonArray[i].termDescription;

                FilmsGlossary.ViewModels.Term term = new ViewModels.Term(itemName, itemDescription);
                collection.Add(term);
            }

            return collection;

        }
    }
}
