using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Items
{
	public class ZemmeliteShard : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Zemmelite Shard");
			Tooltip.SetDefault("Found in a chunk of Extractum, this durable shard would make great armor.");
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
