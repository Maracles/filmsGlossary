﻿using Newtonsoft.Json;
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
        public async Task<string> searchDatabase(string value)
        {
            
            //Store user search string into variable and create URI for sending
            string baseURI = "http://localhost/filmgloss/webService/web-service.php?termName=";
            var searchString = value;
            var searchFormat = "&format=json";
            
            string userURI = baseURI + searchString + searchFormat;

            var httpClient = new HttpClient();

            // Query Webservice and retrieve results
            try
            {
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
