using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Items.MiscGear.TrydaniteGear
{
	public class TheBeam : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Beam");
			Tooltip.SetDefault("Fires a burst of Trydan Flame that explodes into MORE Trydan Flame");
		}
		public override void SetDefaults()
		{
			item.damage = 45;
			item.noMelee = true;
			item.magic = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 28;
			item.useAnimation = 28;
			item.shoot = mod.ProjectileType("BeamProj");
			item.shootSpeed = 14;
			item.useStyle = 1;
			item.mana = 12;
			item.knockBack = 2;
			item.rare = 5;
			item.UseSound = SoundID.Item43;
			item.autoReuse = true;
			item.useTurn = false;
        }	
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MeteoriteBar, 9);
			recipe.AddIngredient(null, "TrydaniteBar", 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}

