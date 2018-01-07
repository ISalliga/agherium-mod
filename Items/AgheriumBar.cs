using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Items
{
	public class AgheriumBar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Agherium Bar");
		}
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 24;
			item.value = 0;
			item.rare = 2;
			item.maxStack = 99;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "AgheriumChunk", 5);
			recipe.AddTile(TileID.Hellforge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
