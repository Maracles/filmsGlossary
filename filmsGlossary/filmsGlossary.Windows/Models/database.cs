using FilmsGlossary.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FilmsGlossary.Models
{
    class Data
    {
        public ObservableCollection<Term> collection = new ObservableCollection<Term>();

        /// <summary>
        /// Create URI to send to web service and instantiate new HTTP client
        /// Query webservice and handle success and fail responses. 
        /// </summary>
        /// 
        /// <param name="value">The term entered by the user when searching.</param>
        /// <returns>A JSON string of the query response.</returns>
        /// 
        /// *****Need to sort out escaping invalid charters when searching for terms. *****
        public async Task<ObservableCollection<Term>> GetResponse(string value)
        {
            string  baseURI     = "http://localhost/filmgloss/webService/web-service.php?termName=";
            var     searchString = value;
            StringBuilder userURI = new StringBuilder(baseURI);
            userURI.Append(searchString);

            var httpClient = new HttpClient();

            try
            {
                var response = await httpClient.GetAsync(userURI.ToString()).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var formattedContent = FormatResponse(content);
                return formattedContent;
            }
            catch (HttpRequestException hre)
            {
                ObservableCollection<Term> formattedContent = new ObservableCollection<Term>();
                formattedContent.Add(new Term(hre.ToString(), hre.ToString()));
                return formattedContent;
            }
            catch (Exception ex)
            {
                ObservableCollection<Term> formattedContent = new ObservableCollection<Term>();
                formattedContent.Add(new Term(ex.ToString(), ex.ToString()));
                return formattedContent;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ObservableCollection<Term> FormatResponse(string value)
        {
            dynamic resultsJsonObject = JsonConvert.DeserializeObject(value);
            dynamic resultsJsonArray = ((JArray)resultsJsonObject.term);

            int jsonCount = resultsJsonArray.Count;

            for (int i = 0; i < jsonCount; i++)
            {
                string itemName = resultsJsonArray[i].termName;
                string itemDescription = resultsJsonArray[i].termDescription;
                Term term = new Term(itemName, itemDescription);

                collection.Add(term);
            }

            return collection;
        }
    }

}
