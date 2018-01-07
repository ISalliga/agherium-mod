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
    public class AgheriumWorld : ModWorld
    {
        public static bool downedOrb = false;
        public override void Initialize()
        {
            downedOrb = false;
        }
        public override TagCompound Save()
        {
            var downed = new List<string>();
            if (downedOrb) downed.Add("downedOrb");

            return new TagCompound {
                {"downed", downed}
            };
        }

        public override void Load(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");
            downedOrb = downed.Contains("downedOrb");
        }

        public override void LoadLegacy(BinaryReader reader)
        {
            int loadVersion = reader.ReadInt32();
            if (loadVersion == 0)
            {
                BitsByte flags = reader.ReadByte();
                downedOrb = flags[0];
            }
            else
            {
                ErrorLogger.Log("Agherium: Unknown loadVersion: " + loadVersion);
            }
        }

        public override void NetSend(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = downedOrb;
            writer.Write(flags);
        }
        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            downedOrb = flags[0];
        }
    }
}