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
        // Need to sort out escaping invalid charters when searching for terms. 
        public async Task<string> searchTerm(string value)
        {
            
            //Set format and retrieve term searched
            var searchFormat = "&format=json";
            var termValue = value;
            
            var httpClient = new HttpClient();

            try
            {
                //Set web service URL format
                string baseURI = "http://localhost/filmgloss/webService/web-service.php?termName=";
                string userURI = baseURI + termValue + searchFormat;

                //Send URL to web service and retrieve response code. 
                var response = await httpClient.GetAsync(userURI);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                return content;
            }
            catch (HttpRequestException hre)
            {
               var content = "There has been a Http Request Exception";
               return content;

            }
            catch (Exception ex)
            {
                // For debugging
                var content = "There has been an exception";
                return content;
            }
        }
    }

}
