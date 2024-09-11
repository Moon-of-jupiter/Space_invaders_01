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
    internal class Prodectile
    {
        
        public Vector2 pos;
        public Rectangle hitbox;
        public Vector2 vel;
        public readonly Prodectile_type type;
        public bool Marked_for_Explode = false;

        public Prodectile(Prodectile_type t, Vector2 p){
            this.type = t;
            this.pos = p;
            this.hitbox = new Rectangle((int)(p.X-t.P_hitbox.X*0.5f), (int)(p.Y - t.P_hitbox.Y * 0.5f),(int)t.P_hitbox.X, (int)t.P_hitbox.Y);


        }

        

    }
}
