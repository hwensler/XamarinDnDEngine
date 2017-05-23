using System;
using System.Collections.Generic;
using System.Text;

namespace App11.Models
{
    public class ServerItem
    {
        public enum Parts { HEAD, ATTKARM, DEFARM, TORSO, FEET, MISC }
        public enum Mod { STRENGTH, SPEED, DEFENSE, HP }

        public string Name { get; set; }
        public string Description { get; set; }
        public int Tier { get; set; }
        public string BodyPart { get; set; }
        public string AttribMod { get; set; }
        public int Usage { get; set; }
        public string Creator { get; set; }
        public string Image { get; set; }

        // add image type uri

        public ServerItem() { }

        public ServerItem(string _name = "default item", Parts _bodyPart = Parts.ATTKARM, Mod _attribMod = Mod.DEFENSE, string _creator = "default", int _tier = 0)
        {
            this.Image = "https://tinyclipart.com/resource/loot-clipart/loot-clipart-12.png";


            this.Name = _name;
            this.Description = _attribMod + " + " + _tier;
            this.BodyPart = _bodyPart.ToString();
            this.AttribMod = _attribMod.ToString();
            this.Creator = _creator;
            this.Tier = _tier;
        }
        public ServerItem(string _image, string _name = "default item", Parts _bodyPart = Parts.ATTKARM, Mod _attribMod = Mod.DEFENSE, string _creator = "default", int _tier = 0)
        {
            this.Image = _image;


            this.Name = _name;
            this.Description = _attribMod + " + " + _tier;
            this.BodyPart = _bodyPart.ToString();
            this.AttribMod = _attribMod.ToString();
            this.Creator = _creator;
            this.Tier = _tier;
        }
    }
}
