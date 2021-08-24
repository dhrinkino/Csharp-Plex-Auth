using System;
using System.Net;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;
namespace PlexTokenAuth
{
    class Program
    {

        public static string Client_Identifier = null; // this is uniq ID of your application, you can write pretty much any number 
        public static string X_Plex_Product = null; // Name of your application, also you will see this name in your plex account
        private static string code = null;
        private static string pin = null;
        static void Main(string[] args)
        {
            // setter
            Set("123456789123456789123456789", "Name of your Application");

            // get pin/id and code
            pin_plex();
            Thread.Sleep(2000);

            // open web browser with out parameters
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "https://app.plex.tv/auth#?clientID=" + Client_Identifier + "&code=" + code + "&context%5Bdevice%5D%5Bproduct%5D=" + X_Plex_Product + "",
                UseShellExecute = true
            });
            
            // wait time
            Thread.Sleep(5000);
            
            // print token
            Console.WriteLine(Get_Token());

            
            // example of saving credentials
            string[] credentials = { 
            Client_Identifier, code, pin
            };
            File.WriteAllLines("credentials.txt", credentials);
            
            
            // just for a demostration i'm cleaning variables
            code = null;
            Client_Identifier = null;
            pin = null;
            credentials = null;
            credentials = File.ReadAllLines("credentials.txt");


            // refill credentials from file
            Client_Identifier = credentials[0];
            code = credentials[1];
            pin = credentials[2];
            Console.WriteLine("New Token: ");
            Console.WriteLine(Get_Token());

        }
        public static void Set(string id, string name) {
            Client_Identifier = id;
            X_Plex_Product = name;
        }
        private static string Get_Token()
        {
            string token;
            string response = null;
            using (WebClient webclient = new WebClient())
            {
                var data = new System.Collections.Specialized.NameValueCollection();
                webclient.Headers["accept"] = "application/json";
                response = webclient.DownloadString("https://plex.tv/api/v2/pins/"+pin+"/?code="+code+ "&X-Plex-Client-Identifier="+Client_Identifier);
            }
            dynamic obj_plex_pin = JsonConvert.DeserializeObject(response);
            token = obj_plex_pin["authToken"];
            return token;
        }
        private static void pin_plex()
        {
            string response = null;
            using (WebClient webclient = new WebClient())
            {
                var data = new System.Collections.Specialized.NameValueCollection();
                data.Add("strong", "true");
                data.Add("X-Plex-Product", X_Plex_Product);
                data.Add("X-Plex-Client-Identifier", Client_Identifier);
                webclient.Headers["accept"] = "application/json";
                byte[] resp_bytes = webclient.UploadValues("https://plex.tv/api/v2/pins/","POST", data);
                response = Encoding.UTF8.GetString(resp_bytes);
            }
            dynamic obj_plex_pin = JsonConvert.DeserializeObject(response);
            code = obj_plex_pin["code"];
            pin = obj_plex_pin["id"];
        }
    }
}
