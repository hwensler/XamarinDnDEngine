
using Xamarin.Forms;
using System;

namespace App11.Views
{
	public partial class AboutPage : ContentPage
	{
		public AboutPage()
		{
			InitializeComponent();
            //the entire string display is below. it displays the current datetime as well as static strings
            entireDisplay.Text = "CPSC - 5910 - SQ\nGroup - Digits\nStudents: Heather Wensler, Matt Irwin, Leon Miao, & Sunny Yeung\n" + DateTime.Now.ToString() + "\nCode Review - Team + Jonathan Adler";
        }
	}
}
