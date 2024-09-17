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
    public class Prodectile
    {
        
        public Vector2 pos;
        public Rectangle hitbox;
        public Vector2 vel;
        private float speed;
        public float heath;

        public readonly Prodectile_type type;

        public Prodectile(Prodectile_type t, Vector2 p){
            this.type = t;

            this.heath = t.damege;

            this.pos = p;
            this.hitbox = new Rectangle((int)(p.X-t.hitbox.X*0.5f), (int)(p.Y - t.hitbox.Y * 0.5f),(int)t.hitbox.X, (int)t.hitbox.Y);
            this.speed = 0;

        }

        public void Update()
        {
            if (speed < type.speed) {
                speed += type.acceleration;
            }
            vel = new Vector2(0, -speed);

            pos = new Vector2(pos.X+vel.X, pos.Y+vel.Y);
            

            Vector2 Centerd_pos = new Vector2(pos.X + Game1.Window_size.X * 0.5f, pos.Y);
            Vector2 offset_pos = new Vector2(Centerd_pos.X - type.hitbox.X * 0.5f, Centerd_pos.Y - type.hitbox.Y * 0.5f);
            hitbox = new Rectangle((int)offset_pos.X, (int)offset_pos.Y, (int)type.hitbox.X, (int)type.hitbox.Y);


        }

        

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(type.texture, hitbox, type.base_color);
        }

        

    }
}
