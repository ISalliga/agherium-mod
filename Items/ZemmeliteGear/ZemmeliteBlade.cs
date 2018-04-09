using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Items.ZemmeliteGear
{
	public class ZemmeliteBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Zemmelite Blade");
			Tooltip.SetDefault("A blade forged of Zemmelite.");
		}
		public override void SetDefaults()
		{
			item.damage = 30;
			item.melee = true;
			item.useStyle = 1;
			item.knockBack = 3;
			item.useTime = 13;
			item.useAnimation = 13;
			item.width = 90;
			item.height = 90;
			item.value = 8000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.maxStack = 1;
			item.autoReuse = true;
			item.useTurn = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ZemmeliteBar", 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
