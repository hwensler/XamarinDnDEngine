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
        ItemsDBDataAccess dataAccess;

        public SettingPage ()
		{
			InitializeComponent ();
        }

        public void flipCrit(object sender, EventArgs e)
        {
            Setting.critHit = !Setting.critHit;
            if (Setting.critHit == true)
            {
                critmissText.IsVisible = false;
                critMiss.IsVisible = false;
            }
            else
            {
                critmissText.IsVisible = true;
                critMiss.IsVisible = true;
            }
        }
        public void flipMiss(object sender, EventArgs e)
        {
            Setting.critMiss = !Setting.critMiss;
            if (Setting.critMiss == true)
            {
                crithitText.IsVisible = false;
                critHit.IsVisible = false;
            }
            else
            {
                crithitText.IsVisible = true ;
                critHit.IsVisible = true;
            }
        }
        public void flipIU(object sender, EventArgs e)
        {
            Setting.itemUsage = !Setting.itemUsage;
        }
        public void magicU(object sender, EventArgs e)
        {
            Setting.magicUsage = !Setting.magicUsage;
        }
        public void toggleHP(object sender, EventArgs e)
        {
            Setting.hpUsage = !Setting.hpUsage;
        }
        public async void battleE(object sender, EventArgs e)
        {
            Setting.battleEvents = !Setting.battleEvents;
            if (!Setting.battleEvents)
            {
                SuperEventsText.IsVisible = false;
                randomEventsText.IsVisible = false;
                superEvents.IsVisible = false;
                randomEvents.IsVisible = false;
            }
            else
            {
                SuperEventsText.IsVisible = true;
                randomEventsText.IsVisible = true;
                superEvents.IsVisible = true;
                randomEvents.IsVisible = true;
            }

            if (Setting.battleEvents)
            {
                string retMod;
                retMod = await GetEventsAsync();
                JSONEvent model = JsonConvert.DeserializeObject<JSONEvent>(retMod);
                List<ServerEvent> getRetEvent = model.data;
                //dataAccess = new ItemsDBDataAccess();

                //dataAccess.DropTableandInsert(getRetEvent);
                Setting.eventList.Clear();

                foreach (ServerEvent sEvent in getRetEvent)
                {
                    Setting.eventList.Add(sEvent);
                }
            }
            else
            {
                Setting.eventList.Clear();
            }
        }
        public async void randomE(object sender, EventArgs e)
        {
            Setting.randomEvents = !Setting.randomEvents;
            string retMod;
            retMod = await GetEventsAsync();
            JSONEvent model = JsonConvert.DeserializeObject<JSONEvent>(retMod);
            List<ServerEvent> getRetEvent = model.data;
            //dataAccess = new ItemsDBDataAccess();

            //dataAccess.DropTableandInsert(getRetItem);
            Setting.eventList.Clear();

            foreach (ServerEvent sEvent in getRetEvent)
            {
                Setting.eventList.Add(sEvent);
            }
        }
        public async void superE(object sender, EventArgs e)
        {
            Setting.superEvents = !Setting.superEvents;
            string retMod;
            retMod = await GetEventsAsync();
            JSONEvent model = JsonConvert.DeserializeObject<JSONEvent>(retMod);
            List<ServerEvent> getRetEvent = model.data;
            //dataAccess = new ItemsDBDataAccess();

            //dataAccess.DropTableandInsert(getRetItem);
            Setting.eventList.Clear();

            foreach (ServerEvent sEvent in getRetEvent)
            {
                Setting.eventList.Add(sEvent);
            }
        }
        public async void serverIt(object sender, EventArgs e)
        {
            Setting.useServerItems = !Setting.useServerItems;
            if (superItems.IsVisible==true)
            {
                SuperItemsText.IsVisible = false;
                randomItemsText.IsVisible = false;
                superItems.IsVisible = false;
                randomItems.IsVisible = false;
            }
            else
            {
                SuperItemsText.IsVisible = true;
                randomItemsText.IsVisible = true;
                superItems.IsVisible = true;
                randomItems.IsVisible = true;
            }
            if (Setting.useServerItems)
            {
                string retMod;
                retMod = await GetItemsAsync();
                JSONItem model = JsonConvert.DeserializeObject<JSONItem>(retMod);
                List<ServerItem> getRetItem = model.data;
                dataAccess = new ItemsDBDataAccess();

                dataAccess.DropTableandInsert(getRetItem);
            }
            else
            {
                dataAccess.DropTableandLocal();
            }
            

        }
        public async void randomIt(object sender, EventArgs e)
        {
            Setting.randomItems = !Setting.randomItems;
            string retMod;
            retMod = await GetItemsAsync();
            JSONItem model = JsonConvert.DeserializeObject<JSONItem>(retMod);
            List<ServerItem> getRetItem = model.data;
            dataAccess = new ItemsDBDataAccess();

            dataAccess.DropTableandInsert(getRetItem);
        }
        public async void superIt(object sender, EventArgs e)
        {
            Setting.superItems = !Setting.superItems;
            string retMod;
            retMod = await GetItemsAsync();
            JSONItem model = JsonConvert.DeserializeObject<JSONItem>(retMod);
            List<ServerItem> getRetItem = model.data;
            dataAccess = new ItemsDBDataAccess();

            dataAccess.DropTableandInsert(getRetItem);
        }

        public void debugIt(object sender, EventArgs e)
        {
            Setting.debugMode = !Setting.debugMode;
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
            var address = $"http://gamehackathon.azurewebsites.net/api/GetItemsList";
            var values = new FormUrlEncodedContent(dictArr);
            var response = await client.PostAsync(address, values);

            var itemJson = response.Content.ReadAsStringAsync().Result;

            //var rootobject = JsonConvert.DeserializeObject<Rootobject>(airportJson);

            return itemJson;

        }
        public async Task<string> GetEventsAsync()
        {
            int randomVal = Convert.ToInt32(Setting.randomItems);
            int superVal = Convert.ToInt32(Setting.superItems);

            Dictionary<string, string> dictArr = new Dictionary<string, string>
            {
                {"randomItemOption" , Convert.ToString(randomVal) },
                {"superItemOption", Convert.ToString(superVal) }
            };

            var client = new System.Net.Http.HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var address = $"http://gamehackathon.azurewebsites.net/api/GetBattleEffects";
            var values = new FormUrlEncodedContent(dictArr);
            var response = await client.PostAsync(address, values);

            var eventJson = response.Content.ReadAsStringAsync().Result;

            //var rootobject = JsonConvert.DeserializeObject<Rootobject>(airportJson);

            return eventJson;

        }
    }
}
