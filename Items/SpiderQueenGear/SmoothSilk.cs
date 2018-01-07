using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Items.SpiderQueenGear
{
	public class SmoothSilk : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Smooth Silk");
			Tooltip.SetDefault("The smoothest silk in Terraria. Still manages to make great gear!");
		}
		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 26;
			item.value = 50000;
			item.rare = 2;
			item.maxStack = 99;
		}
	}
}
