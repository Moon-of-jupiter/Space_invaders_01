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

        public float damege_bonus { get; set; } // for damege bonus power up

        public Vector2 vel;
        public float speed {  get; protected set; }
        

        public Prodectile_type type { get; protected set; }

        public Prodectile(Prodectile_type _type, Vector2 _staringPos, float _damege_bonus) : base(colition_tags.prodectile, _type.sprite, _type.hitbox, _type.hitbox, _type.base_color)
        {
            damege_bonus = _damege_bonus;
            can_colide_with = new colition_tags[] { colition_tags.enemy };

            
            this.type = _type;

            this.health = _type.damege + _damege_bonus;

            this.position = _staringPos;
            this.hitbox = new Rectangle((int)(position.X-type.hitbox.X*0.5f), (int)(position.Y - type.hitbox.Y * 0.5f),(int)type.hitbox.X, (int)type.hitbox.Y);
            this.speed = 0;

        }

        public override void Update()
        {
            if (speed < type.speed) {
                speed += type.acceleration;
            }
            vel = new Vector2(0, -speed);

            position = new Vector2(position.X+vel.X, position.Y+vel.Y);
            

            Vector2 Centerd_pos = new Vector2(position.X + Game1.Window_size.X * 0.5f, position.Y);

            hitbox = GlobalMethods.Centralized_Rectangle(Centerd_pos, type.hitbox);
        }

        

        public override void Draw(SpriteBatch _spriteBatch)
        {
            base.Draw(_spriteBatch);
        }

        

    }
}
