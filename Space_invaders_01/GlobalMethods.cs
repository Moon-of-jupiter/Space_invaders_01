using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Space_invaders_01;

namespace Space_invaders_01
{
    static public class GlobalMethods
    {
        public static Rectangle Centralized_Rectangle(Vector2 position, Vector2 size)// offsets origin point to the center
        {
            return new Rectangle((int)(position.X-size.X*0.5f), (int)(position.Y - size.Y * 0.5f),(int)size.X, (int)size.Y);
        }

        public static Rectangle Centralized_Rectangle(int x, int y, int width, int hight)// offsets origin point to the center
        {
            return new Rectangle((int)(x - width*0.5f), (int)(y - hight * 0.5f), width, hight);
        }


    }
}
