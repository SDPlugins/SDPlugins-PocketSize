using Rocket.Core;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Enumerations;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PocketResizer
{
    public class PocketResizer : RocketPlugin<Configuration>
    {
		public static PocketResizer Instance;

		protected override void Load ()
		{
			Instance = this;
			UnturnedPlayerEvents.OnPlayerUpdateGesture += GestureChange;
		}

		private void GestureChange (UnturnedPlayer player, UnturnedPlayerEvents.PlayerGesture gesture)
		{
			if (gesture == UnturnedPlayerEvents.PlayerGesture.InventoryOpen)
			{

				pocket_size best = getBestSize (player);
				if (best.permission != "$$$$$DO NOT USE$$$$$")
				{
					player.Inventory.items [2].resize ((byte)best.width, (byte)best.height);
				}
			}
		}

		protected override void Unload ()
		{
			UnturnedPlayerEvents.OnPlayerUpdateGesture -= GestureChange;	
		}

		public pocket_size getBestSize (UnturnedPlayer player)
		{
			pocket_size ret = new pocket_size (-1, -1, "$$$$$DO NOT USE$$$$$");

			foreach (var p in Configuration.Instance.pockets)
			{
				if (R.Permissions.HasPermission (player, new List<string> () { p.permission }))
					if ((p.width * p.height) > (ret.width * ret.height))
						ret = p;
			}

			return ret;
		}
	}
}
