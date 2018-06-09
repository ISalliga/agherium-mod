using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Items.MiscGear
{
	public class PinkyShiv : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pinky's Shiv");
			Tooltip.SetDefault("Bounce, bounce.");
		}
		public override void SetDefaults()
		{
			item.damage = 5;
			item.melee = true;
			item.useStyle = 3;
			item.knockBack = 12;
			item.useTime = 8;
			item.useAnimation = 8;
			item.width = 24;
			item.height = 24;
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
            recipe.AddIngredient(ItemID.PinkGel, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}
