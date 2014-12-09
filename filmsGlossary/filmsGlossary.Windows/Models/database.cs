using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace filmsGlossary.Models
{
    class database
    {
        /// <summary>
        /// Create URI to send to web service and instantiate new HTTP client
        /// Query webservice and handle success and fail responses. 
        /// </summary>
        /// <param name="value">The term entered by the user when searching.</param>
        /// <returns>A JSON string of the query response.</returns>
        /// 
        /// *****Need to sort out escaping invalid charters when searching for terms. *****
 
        public async Task<string> searchDatabase(string value)
        {
            string  baseURI     = "http://localhost/filmgloss/webService/web-service.php?termName=";
            var     searchString = value;
            var     searchFormat = "&format=json";
            
            string  userURI = baseURI + searchString + searchFormat;

            var httpClient = new HttpClient();

            try
            {
                var response = await httpClient.GetAsync(userURI);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                return content;
            }
            catch (HttpRequestException hre)
            {
                var  content = "Response: " + hre.ToString(); 
                return content;
            }
            catch (Exception ex)
            {
                var content = "Response: " +  ex.ToString();
                return content;
            }
        }
    }

}
