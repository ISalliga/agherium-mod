using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using AgheriumMod.NPCs.Bosses;
using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod
{
	class AgheriumMod : Mod
	{
		public AgheriumMod()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
		}
		public override void PostSetupContent()
		{
			Mod bossList = ModLoader.GetMod("BossChecklist");
			if (bossList != null)
			{
				bossList.Call("AddBossWithInfo", "Soul of the Guide", 3.4f, (Func<bool>)(() => AgheriumWorld.downedSoul), string.Format("Use a [i:{0}]", ItemType("SoulActivator")));
				bossList.Call("AddBossWithInfo", "Fallen Angel", 7.5f, (Func<bool>)(() => AgheriumWorld.downedAngel), string.Format("Use a [i:{0}]", ItemType("UnholyBeacon")));
				bossList.Call("AddBossWithInfo", "Rorbert", 5.1f, (Func<bool>)(() => AgheriumWorld.downedRorbert), string.Format("Use a [i:{0}]", ItemType("StrangeMachine")));
				bossList.Call("AddBossWithInfo", "Aarhac'n, the Spider Queen", 10.2f, (Func<bool>)(() => AgheriumWorld.downedSpodermen), string.Format("Use a [i:{0}]", ItemType("SpiderEgg")));
			}
		}
	}
}
