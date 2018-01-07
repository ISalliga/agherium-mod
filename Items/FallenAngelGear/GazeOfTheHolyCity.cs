using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Items.FallenAngelGear
{
    public class GazeOfTheHolyCity : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 48;
            item.ranged = true;
            item.width = 16;
            item.height = 12;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 2;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = 3;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shoot = 3; //idk why but all the guns in the vanilla source have this
            item.shootSpeed = 12f;
            item.useAmmo = AmmoID.Arrow;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gaze of the Holy City");
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("EnergyStar"), damage, knockBack, player.whoAmI, 0f, 0f); //This is spawning a projectile of type FrostburnArrow using the original stats
            return false; //Makes sure to not fire the original projectile
        }
    }
}
