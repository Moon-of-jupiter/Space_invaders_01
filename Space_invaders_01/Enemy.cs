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
    public class Enemy : GameObject
    {
        public readonly Enemy_type type;
        
        
        public Vector2 starting_pos;
        public Vector2 _pos;

        public Vector2 vel;
        

        

        

        

        public Enemy(Enemy_type t, Vector2 p) {

            //this.horisontal_acceleration = _horisontal_acceleration;
            this.texture = t.type_texture;
            this.type = t;
            this.health = t.type_max_HP;
            this.starting_pos = p;
            this.color = t.type_color;
            this.size = t.type_size;
            this.damege = t.type_damege;
        }

        

        public void Update(float x, float y) {
            _pos = new Vector2(starting_pos.X += x,starting_pos.Y+y);


            Vector2 Centerd_pos = new Vector2(_pos.X + Game1.Window_size.X * 0.5f, _pos.Y);
            Vector2 offset_pos = new Vector2(Centerd_pos.X - size.X * 0.5f, Centerd_pos.Y - size.Y * 0.5f);

            hitbox = new Rectangle((int)offset_pos.X, (int)offset_pos.Y, (int)size.X, (int)size.Y);

        }

        public Rectangle exit_hitbox()
        {
            Rectangle th = new Rectangle(hitbox.Left,hitbox.Top-10,hitbox.Width,1);
            return th;
        }

        public override void Draw(SpriteBatch _spriteBatch) {
            
            _spriteBatch.Draw(texture, hitbox, color);
        }

    }
}
