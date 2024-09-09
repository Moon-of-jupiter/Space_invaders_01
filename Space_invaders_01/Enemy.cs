using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Space_invaders_01
{
    public class Enemy
    {
        public int HP;
        public Vector2 pos;
        public Vector2 vel;

        public Color Color;
        public Vector2 Size;

        public Enemy(int h, Vector2 p, Color c,int s_x, int s_y) { 
            this.HP = h;
            this.pos = p;
            this.Color = c;
            this.Size = new Vector2 (s_x, s_y);
        }

    }
}
