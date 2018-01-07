using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Items
{
	public class EtherumBar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Etherum Bar");
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
			recipe.AddIngredient(null, "EtherumOre", 4);
			recipe.AddTile(TileID.Hellforge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
