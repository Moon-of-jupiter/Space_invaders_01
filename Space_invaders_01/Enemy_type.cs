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
    public class Enemy_type
    {
        public int type_max_HP;
        public Vector2 type_size;
        public Color type_color;
        public Texture2D type_texture;

        public Enemy_type(int h, Vector2 s, Color c, Texture2D t)
        {
            this.type_max_HP = h;
            this.type_size = s; 
            this.type_texture = t;
            this.type_color = c;
        }



    }
}
