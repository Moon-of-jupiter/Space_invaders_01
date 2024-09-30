using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Space_invaders_01;
namespace Space_invaders_01
{
    public static class SpriteManeger
    {
        public static Texture2D pixel;
        public static Texture2D stars_space01;

        static SpriteManeger()
        {
            stars_space01 = Game1._content.Load<Texture2D>("Stars_panorama_sheet");
            pixel = Game1._content.Load<Texture2D>("Pixel");
        }


    }
}
