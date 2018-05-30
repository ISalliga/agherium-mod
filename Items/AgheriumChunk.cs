using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Items
{
	public class AgheriumChunk : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Agherium Chunk");
			Tooltip.SetDefault("Found in a chunk of Extractum, this dexterity-enhancing chunk would make great ammo.");
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
