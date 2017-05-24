using System;
using System.Collections.Generic;
using System.Text;

namespace App11.Models
{
	public class ServerEvent
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public int Tier { get; set; }
		public string Target { get; set; }
		public string AttribMod { get; set; }
	
		//public ServerEvent() { }

		public ServerEvent(string _name, string _description, int _tier, string _target, string _attribMod)
		{
			this.Name = _name;
			this.Description = _description;
			this.Tier = _tier;
			this.Target = _target;
			this.AttribMod = _attribMod;
		}
	}
}
