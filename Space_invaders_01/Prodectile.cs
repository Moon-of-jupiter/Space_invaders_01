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
    public class Prodectile : GameObject
    {
        
        public Vector2 pos;
        
        public Vector2 vel;
        public float speed {  get; protected set; }
        

        public Prodectile_type type { get; protected set; }

        public Prodectile(Prodectile_type _type, Vector2 _staringPos){
            tag = colition_tags.prodectile;
            can_colide_with = new colition_tags[1] { colition_tags.enemy };

            this.type = _type;

            this.health = _type.damege;

            this.pos = _staringPos;
            this.hitbox = new Rectangle((int)(pos.X-type.hitbox.X*0.5f), (int)(pos.Y - type.hitbox.Y * 0.5f),(int)type.hitbox.X, (int)type.hitbox.Y);
            this.speed = 0;

        }

        public override void Update()
        {
            if (speed < type.speed) {
                speed += type.acceleration;
            }
            vel = new Vector2(0, -speed);

            pos = new Vector2(pos.X+vel.X, pos.Y+vel.Y);
            

            Vector2 Centerd_pos = new Vector2(pos.X + Game1.Window_size.X * 0.5f, pos.Y);

            hitbox = GlobalMethods.Centralized_Rectangle(Centerd_pos, type.hitbox);
        }

        

        public override void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(type.texture, hitbox, type.base_color);
        }

        

    }
}
