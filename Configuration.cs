using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PocketResizer
{
	public class Configuration : IRocketPluginConfiguration
	{
		[XmlArray ("Pockets")]
		[XmlArrayItem ("Pocket")]
		public List<pocket_size> pockets;

		public void LoadDefaults ()
		{
			pockets = new List<pocket_size> ()
			{
				new pocket_size (3, 2, "pocket.small"),
				new pocket_size (10, 4, "pocket.huge"),
				new pocket_size (10, 10, "pocket.insane")
			};
		}
	}

	public class pocket_size
	{
		[XmlElement ("Width")]
		public int width;
		[XmlElement ("Height")]
		public int height;
		[XmlElement ("Permission")]
		public string permission;

		public pocket_size () { width = 5; height = 2; permission = "default"; }
		public pocket_size (int width, int height, string permission)
		{
			this.width = width;
			this.height = height;
			this.permission = permission;
		}
	}
}
