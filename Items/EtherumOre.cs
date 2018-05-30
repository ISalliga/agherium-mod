using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Items
{
	public class EtherumOre : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Etherum Ore");
			Tooltip.SetDefault("Found in a chunk of Extractum, this magical ore can harness the magical power of magic.");
		}
		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 16;
			item.value = 0;
			item.rare = 2;
			item.maxStack = 999;
		}
	}
}
