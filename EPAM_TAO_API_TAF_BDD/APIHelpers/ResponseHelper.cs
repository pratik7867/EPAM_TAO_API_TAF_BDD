using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace EPAM_TAO_API_TAF_BDD.APIHelpers
{
    public class ResponseHelper
    {
        public static RestResponse ExecuteRequest(RestClient restClient, RestRequest restRequest)
        {
            try
            {
                return restClient.Execute(restRequest);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public static DC GetContent<DC>(RestResponse restResponse)
        {
            try
            {
               return JsonConvert.DeserializeObject<DC>(restResponse.Content);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default(DC);                
            }
        }

        public static int GetStatusCode(RestResponse restResponse)
        {
            try
            {
                HttpStatusCode httpStatusCode = restResponse.StatusCode;
                return (int)httpStatusCode;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public static string GetStatusDescription(RestResponse restResponse)
        {
            try
            {
                return restResponse.StatusDescription;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public static bool GetRequestSuccessFlag(RestResponse restResponse)
        {
            try
            {
                return restResponse.IsSuccessful;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static IList<Parameter> GetResponseHeaders(RestResponse restResponse)
        {
            try
            {
                return (IList<Parameter>)restResponse.Headers;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public static IList<Cookie> GetResponseCookies(RestResponse restResponse)
        {
            try
            {
                return (IList<Cookie>)restResponse.Cookies;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
