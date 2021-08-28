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

        static void Main(string[] args)
        {
            // example usage
            PlexAuth PlexController = new PlexAuth();
            PlexController.Set("123456789123456789123456789", "Name of your Application"); // ID of App and Name
            
            if (!PlexController.LoadPin("output.txt")) // if file do not exists generate new pin and token
            {
                PlexController.Generate(); // generate pin and code
                PlexController.Token(); // generate token from pin and core
                PlexController.SavePin("output.txt"); // save settings to output.txt
            } else {

                if (!PlexController.ValidToken()) // check if existing token is not valid
                {
                    PlexController.Token(); // generate new token
                    PlexController.SavePin("output.txt"); // save settings to output.txt
                }
            }
            Console.WriteLine(PlexController.CurrentToken()); // print current data
            Console.WriteLine(PlexController.GetServer()); // get URI of PMS

        }
        
    }
}
