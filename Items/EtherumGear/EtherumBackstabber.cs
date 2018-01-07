using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace AgheriumMod.Items.EtherumGear
{
	public class EtherumBackstabber : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Etherum Backstabber");
			Tooltip.SetDefault("'Put on your murder face.'");
		}
		public override void SetDefaults()
		{
			item.damage = 20;
			item.noMelee = true;
			item.magic = true;
			item.width = 36;
			item.height = 36;
			item.useTime = 17;
			item.useAnimation = 17;
			item.shoot = mod.ProjectileType("EtherPulsar");
			item.shootSpeed = 10;
			item.useStyle = 1;
			item.mana = 7;
			item.knockBack = 2;
			item.rare = 4;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.useTurn = false;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 mouseToPlayer = (player.position - Main.MouseWorld).SafeNormalize(Vector2.UnitX);
			mouseToPlayer *= new Vector2(speedX, speedY).Length();
			Projectile.NewProjectile(Main.MouseWorld, mouseToPlayer, type, damage, knockBack, player.whoAmI);
			return false;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "EtherumBar", 13);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}

