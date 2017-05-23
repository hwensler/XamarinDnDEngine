using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using App11.Models;

namespace App11.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingPage : ContentPage
	{
		public SettingPage ()
		{
			InitializeComponent ();
        }

        public void flipCrit(object sender, EventArgs e)
        {
            Setting.critHit = !Setting.critHit;
        }
        public void flipMiss(object sender, EventArgs e)
        {
            Setting.critMiss = !Setting.critHit;
        }
        public void flipIU(object sender, EventArgs e)
        {
            Setting.itemUsage = !Setting.critHit;
        }
        public void magicU(object sender, EventArgs e)
        {
            Setting.magicUsage = !Setting.critHit;
        }
        public void toggleHP(object sender, EventArgs e)
        {
            Setting.hpUsage = !Setting.critHit;
        }
        public void battleE(object sender, EventArgs e)
        {
            Setting.battleEvents = !Setting.critHit;
        }
        public void serverIt(object sender, EventArgs e)
        {
            Setting.useServerItems = !Setting.critHit;
        }
        public void randomIt(object sender, EventArgs e)
        {
            Setting.randomItems = !Setting.critHit;
        }
        public void superIt(object sender, EventArgs e)
        {
            Setting.superItems = !Setting.critHit;
        }

        public void debugIt(object sender, EventArgs e)
        {
            Setting.debugMode = !Setting.critHit;
        }
        public async Task<string> GetItemsAsync()
        {
            int superVal = Convert.ToInt32(Setting.superItems);
            int randomVal = Convert.ToInt32(Setting.randomItems);

            Dictionary<string, string> dictArr = new Dictionary<string, string>
            {
                {"randomItemOption" , Convert.ToString(randomVal) },
                {"superItemOption", Convert.ToString(superVal) }
            };
            var client = new System.Net.Http.HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var address = $"http://apihw20170510024050.azurewebsites.net//api/GetItemList";
            var values = new FormUrlEncodedContent(dictArr);
            var response = await client.PostAsync(address, values);

            var itemJson = response.Content.ReadAsStringAsync().Result;

            //var rootobject = JsonConvert.DeserializeObject<Rootobject>(airportJson);

            return itemJson;

        }
    }
}
