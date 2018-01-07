using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Items
{
	public class ZemmeliteShard : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Zemmelite Shard");
			Tooltip.SetDefault("Extracted from stone, this durable shard would make great armor.");
		}
		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 16;
			item.value = 0;
			item.rare = 2;
			item.maxStack = 999;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneBlock, 4);
			recipe.AddTile(TileID.Extractinator);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
