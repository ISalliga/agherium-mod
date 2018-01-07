using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Items.FallenAngelGear
{
	public class ArchangelsStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Arch-Angel's Staff");
			Tooltip.SetDefault("Laser-spam like no other."
			+ "/nFires out several laser orbs that explode into more lasers!");
		}
		public override void SetDefaults()
		{
			item.damage = 47;
			item.noMelee = true;
			item.magic = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 9;
			item.useAnimation = 27;
			item.shoot = mod.ProjectileType("MiniArchorbFriendly");
			item.shootSpeed = 8;
			item.useStyle = 1;
			item.mana = 9;
			item.knockBack = 2;
			item.rare = 5;
			item.UseSound = SoundID.Item43;
			item.autoReuse = true;
			item.useTurn = false;
        }		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DarklightEssence", 17);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}

