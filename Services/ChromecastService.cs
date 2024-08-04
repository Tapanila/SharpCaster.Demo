using Sharpcaster;
using Sharpcaster.Models;
using Sharpcaster.Models.ChromecastStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCaster.Demo.Services
{
    public class ChromecastService
    {
        public ChromecastReceiver Receiver { get; set; }
        public ChromecastClient Client { get; set; }
        public ChromecastService()
        {
            Client = new ChromecastClient();
        }

        public async Task<ChromecastStatus> Connect()
        {
            return await Client.ConnectChromecast(Receiver);
        }

        public async Task<ChromecastStatus> LaunchApplication(string applicationId = "B3419EF5")
        {
            return await Client.LaunchApplicationAsync(applicationId);
        }
    }
}
