using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using AgheriumMod.Items;

namespace AgheriumMod.Items.FallenAngelGear
{
    public class AngelHeart : ModItem
    {
        public const int FireProjectiles = 4;
        public const float FireAngleSpread = 70;
        public int FireCountdown = 0;
        public override void SetDefaults()
        {
            item.width = 48;
            item.height = 32;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = -12;
            item.accessory = true;
			item.expert = true;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heart of a Higher Plane");
            Tooltip.SetDefault("Increased life regen\nHarpies and Wyverns are made friendly\nThe feathers will still hurt you, beware");
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.npcTypeNoAggro[87] = true;
            player.npcTypeNoAggro[48] = true;
            player.lifeRegen += 3;
            if (player.statLife <= (player.statLifeMax2 * 0.30f))
            {
                player.lifeRegen += 20;
            }
            FireCountdown--;
            if (FireCountdown == 0)
            {
                FireCountdown = 60;
            }
            if (FireCountdown > 0)
            {
                FireCountdown--;
                if (FireCountdown == 0)
                {
                    for (int playerIndex = 0; playerIndex < 255; playerIndex++)
                    {
                        if (Main.player[playerIndex].active)
                        {
                            Player player2 = Main.player[playerIndex];
                            int speed2 = 25;
                            float spawnX = Main.rand.Next(1000) - 500 + player2.Center.X;
                            float spawnY = -1000 + player2.Center.Y;
                            Vector2 baseSpawn = new Vector2(spawnX, spawnY);
                            Vector2 baseVelocity = player2.Center - baseSpawn;
                            baseVelocity.Normalize();
                            baseVelocity = baseVelocity * speed2;
                            for (int i = 0; i < FireProjectiles; i++)
                            {
                                Vector2 spawn = baseSpawn;
                                spawn.X = spawn.X + i * 30 - (FireProjectiles * 15);
                                Vector2 velocity = baseVelocity;
                                velocity = baseVelocity.RotatedBy(MathHelper.ToRadians(-FireAngleSpread / 2 + (FireAngleSpread * i / (float)FireProjectiles)));
                                velocity.X = velocity.X + 3 * Main.rand.NextFloat() - 1.5f;
                                Projectile.NewProjectile(spawn.X, spawn.Y, velocity.X, velocity.Y, 239, 50, 5f, Main.myPlayer, 0f, 0f);
                            }
                        }
                    }
                }
            }
        }
    }
}