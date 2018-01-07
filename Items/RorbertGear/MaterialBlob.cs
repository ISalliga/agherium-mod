using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Items.RorbertGear
{
	public class MaterialBlob : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Material Blob");
			Tooltip.SetDefault("A blob of a Gelatinian's body.");
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
