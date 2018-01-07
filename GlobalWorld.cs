using System;
using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using AgheriumMod.NPCs;
using System.Linq;
using Terraria.ModLoader.IO;

namespace AgheriumMod
{
    public class GlobalWorld : ModWorld
    {
        public static bool downedAngel = false;

        public override void Initialize()
        {
            downedAngel = false;
        }
        public override TagCompound Save()
        {
            var downed = new List<string>();
            if (downedAngel) downed.Add("downedAngel");

            return new TagCompound {
                {"downed", downed}
            };
        }

        public override void Load(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");
            downedAngel = downed.Contains("downedAngel"); 
        }

        public override void LoadLegacy(BinaryReader reader)
        {
            int loadVersion = reader.ReadInt32();
            if (loadVersion == 0)
            {
                BitsByte flags = reader.ReadByte();
                downedAngel = flags[0];
            }
            else
            {
                ErrorLogger.Log("Agherium: Unknown loadVersion: " + loadVersion);
            }
        }

        public override void NetSend(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = downedAngel;
            writer.Write(flags);
        }
        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            downedAngel = flags[0];
        }
    }
}