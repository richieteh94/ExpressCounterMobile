using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace PSM2017v2.Helper
{
    public class WebService
    {
        public WebService() { }

        public string postService(string postData, string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            var param = postData;
            var data = Encoding.ASCII.GetBytes(param);
            request.Timeout = 5 * 1000;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            request.UseDefaultCredentials = true;

            try
            {
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                response.Close();
                return responseString;
            }
            catch (Exception e)
            {
                //return e.ToString();
                return "Connection error.";
            }

        }
    }
}

