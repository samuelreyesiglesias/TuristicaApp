using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
namespace TuristicaApp.ViewModel
{
    public class CheckMyConnection
    {
        public bool CheckInternetConnection()
        {
            string CheckUrl = "http://google.com";
            try
            {
                HttpWebRequest iNetRequest = (HttpWebRequest)WebRequest.Create(CheckUrl);
                iNetRequest.Timeout = 5000;
                WebResponse iNetResponse = iNetRequest.GetResponse();
                // Console.WriteLine ("...connection established..." + iNetRequest.ToString ());
                iNetResponse.Close();
                return true;

            }
            catch (WebException ex)
            {
                //System.Diagnostics.Debug.WriteLine(".....no connection...");
                return false;
            }
        }
    }
}
