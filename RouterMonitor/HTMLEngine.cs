using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace RouterMonitor
{
    public enum AuthenticationMethods
    {
        None,
        Basic,
        Cookie
    }

    public class HTMLEngine
    {
        public String response;

        public CookieCollection cookies;

        public bool CommandHTML(String Method, String URL, String Data, AuthenticationMethods AuthenticationMethod, string UserName, string Password)
        {
            if (Method == "post") return Post(URL, Data, AuthenticationMethod, UserName, Password);
            if (Method == "get") return Get(URL, Data, AuthenticationMethod, UserName, Password);
            return false;
        }

        public bool Post(string URL, String Data, AuthenticationMethods AuthenticationMethod, string UserName, string Password)
        {
            try
            {
                // Initialisation, set the URL
                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(URL);

                // Set 'POST' method
                WebReq.Method = "POST";

                // Set basic authentication if required
                if (AuthenticationMethod == AuthenticationMethods.Basic) WebReq.Credentials = new NetworkCredential(UserName, Password);
                
                if (AuthenticationMethod == AuthenticationMethods.Cookie)
                {
                    WebReq.CookieContainer = new CookieContainer();
                    if (cookies != null)
                    {
                        WebReq.CookieContainer.Add(cookies);
                    }
                }

                WebReq.Accept = "application/json, text/javascript, */*; q=0.01";
                WebReq.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/105.0.0.0 Safari/537.36 Edg/105.0.1343.42";
                WebReq.Headers.Add("X-Requested-With", "XMLHttpRequest");
                WebReq.Referer = "http://192.168.0.1/";
                WebReq.Headers.Add("Accept-Encoding", "gzip, deflate");
                WebReq.Headers.Add("Accept-Language", "gen-GB,en;q=0.9,en-US;q=0.8,ko;q=0.7");
                WebReq.KeepAlive = false;

                // Set form contentType, for the postvars.
                WebReq.ContentType = "application/x-www-form-urlencoded";

                // The length of the buffer (postvars) is used as contentlength.
                byte[] buffer = Encoding.ASCII.GetBytes(Data);
                WebReq.ContentLength = buffer.Length;

                // Oopen a stream for writing the postvars
                Stream PostData = WebReq.GetRequestStream();

                // Write, and afterwards, we close. Closing is always important!
                PostData.Write(buffer, 0, buffer.Length);
                PostData.Close();

                // Create the response for the request
                HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

                if (cookies == null)
                {
                    cookies = WebResp.Cookies;
                }

                // Read the response from the response stream
                Stream Answer = WebResp.GetResponseStream();
                StreamReader _Answer = new StreamReader(Answer);
                response = _Answer.ReadToEnd();

                return true;
            }
            catch (WebException e)
            {
                response = e.Message;
                return false;
            }
        }


        public bool Get(String URL, String Data, AuthenticationMethods AuthenticationMethod, string UserName, string Password)
        {
            try
            {
                // Initialisation, set the URL and data
                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(URL, Data));

                // Set 'GET' method
                WebReq.Method = "GET";

                // Set basic authentication if required
                if (AuthenticationMethod == AuthenticationMethods.Basic) WebReq.Credentials = new NetworkCredential(UserName, Password);

                if (AuthenticationMethod == AuthenticationMethods.Cookie)
                {
                    WebReq.CookieContainer = new CookieContainer();
                    if (cookies != null)
                    {
                        WebReq.CookieContainer.Add(cookies);
                    }
                }

                WebReq.Accept = "application/json, text/javascript, */*; q=0.01\r\n";
                WebReq.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/105.0.0.0 Safari/537.36 Edg/105.0.1343.42\r\n";
                WebReq.Headers.Add("X-Requested-With", "XMLHttpRequest\r\n");
                WebReq.Referer = "http://192.168.0.1/\r\n";
                WebReq.Headers.Add("Accept-Encoding", "gzip, deflate\r\n");
                WebReq.Headers.Add("Accept-Language", "gen-GB,en;q=0.9,en-US;q=0.8,ko;q=0.7\r\n");

                // Create the response for the request
                HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

                // Read the response from the response stream
                Stream Answer = WebResp.GetResponseStream();
                StreamReader _Answer = new StreamReader(Answer);
                response = _Answer.ReadToEnd();

                return true;
            }
            catch (WebException e)
            {
                response = e.Message;
                return false;
            }
        }


        public string GetRegExValue(string regExp)
        {

            Regex r = new Regex(regExp, RegexOptions.IgnoreCase);
            Match m = r.Match(response); // Remark: hardcopy uses a cache !
            if (m != null && m.Success)
                return m.Result("${value}");
            else
                return null;

        }
    }
}
