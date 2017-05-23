using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App11.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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

    }
}
