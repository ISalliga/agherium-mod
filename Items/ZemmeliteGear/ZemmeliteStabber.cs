using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Items.ZemmeliteGear
{
	public class ZemmeliteStabber : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Zemmelite Stabber");
			Tooltip.SetDefault("Shortswords are supposed to be short, so this is just a stabber.");
		}
		public override void SetDefaults()
		{
			item.damage = 20;
			item.melee = true;
			item.useStyle = 3;
			item.knockBack = 3;
			item.useTime = 8;
			item.useAnimation = 8;
			item.width = 48;
			item.height = 48;
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
			recipe.AddIngredient(null, "ZemmeliteBar", 9);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
