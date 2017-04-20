
/**
 * This is where the main menu is populated from
 * **/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using App11.Models;

using Xamarin.Forms;

[assembly: Dependency(typeof(App11.Services.MainMenu))]
namespace App11.Services
{
    public class MainMenu
    {
        public List<MenuPage> pages { get; set; }

        public MainMenu()
        {
            pages = new List<MenuPage>();
            var _items = new List<MenuPage>
            {
                new MenuPage { Id = Guid.NewGuid().ToString(), Text = "Score", Description="Check the current score."},
                new MenuPage { Id = Guid.NewGuid().ToString(), Text = "Character", Description="View all current characters."},
                new MenuPage { Id = Guid.NewGuid().ToString(), Text = "Inventory", Description="View the current party's inventory."},
                new MenuPage { Id = Guid.NewGuid().ToString(), Text = "Monsters", Description="See the monsters your party is up against."},
                new MenuPage { Id = Guid.NewGuid().ToString(), Text = "Items", Description="Check out all possible items."},
                new MenuPage { Id = Guid.NewGuid().ToString(), Text = "Battle", Description="This is where the action is."},
            };

            foreach (MenuPage item in _items)
            {
                pages.Add(item);
            }
        }
    }
}
