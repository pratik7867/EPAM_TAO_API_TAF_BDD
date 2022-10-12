using System;
using RestSharp;

namespace EPAM_TAO_API_TAF_BDD.APIHelpers
{
    public class RestClientSetup
    {
        static RestClient restClient;

        public static RestClient SetupClient(string strBaseURL)
        {
            try
            {
                if (restClient == null)
                {
                    restClient = new RestClient(strBaseURL);
                }

                return restClient;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }            
        }
    }
}
