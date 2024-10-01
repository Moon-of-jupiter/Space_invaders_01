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
        public Enemy_type type {  get; private set; }
        
        
        public Vector2 starting_pos;
        

        public Vector2 vel;

        public bool has_shot = false;

        private int shooting_cooldown;

        private Random random = new Random();






        public Enemy(Enemy_type _type, Vector2 _position) : base(colition_tags.enemy, _type.texture, _type.size, _type.size)
        {

            

            



            //this.horisontal_acceleration = _horisontal_acceleration;
            this.sprite = _type.texture;
            this.type = _type;
            this.health = _type.max_HP;
            this.starting_pos = _position;
            this.color = _type.color;
            
            this.spritesize = _type.size;
            this.damege = _type.damege;
            

            if (type.prodectile != null)
            { 
                shooting_cooldown = type.prodectile.cooldown * random.Next(1, 40);
            }
        }

        public void shoot()
        {
            if(type.prodectile != null)
            {
                has_shot = false;
                if(shooting_cooldown > 0)
                {
                    shooting_cooldown--;
                }
                else
                {
                    has_shot = true;
                    shooting_cooldown = type.prodectile.cooldown * random.Next(1, 40);
                }


            }
        }
        
        

        public void Update(float x, float y) {

            

            position = new Vector2(starting_pos.X += x,starting_pos.Y+y);


            
            base.Update();

            shoot();
        }

        public Rectangle exit_hitbox()
        {
            Rectangle th = new Rectangle(hitbox.Left,hitbox.Top-10,hitbox.Width,1);
            return th;
        }

        public override void Draw(SpriteBatch _spriteBatch) 
        {
            if (has_shot) { run_animation = true; }

            base.Draw(_spriteBatch);
            
            
        }

    }
}
