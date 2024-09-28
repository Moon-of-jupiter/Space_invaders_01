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
    public class Player : GameObject
    {

        

        public int stagger_timer = 0;

        public int weapon_cooldown_timer = 0;
        public bool has_shot = false;
        public Prodectile_type curent_weapon;
        
        

        
        //world properties
        public Vector2 pos;
        public float vel;

        //visual properties
        
        public Vector2 hitbox_size;

        public float speed;

        public Keys Left_key;
        public Keys Right_key;
        public Keys Shoot_key;

        
        public Rectangle spriteBox;

        public Player(Vector2 _position, Texture2D _texture, Color _color, int _starting_health, float _speed, int _sizeX, int _sizeY, int _hitbox_sizeX, int _hitbox_sizeY, Keys _keyleft, Keys _keyright, Keys _keyshoot) {
            
            this.health = _starting_health;
            this.pos = _position;
            this.vel = 0;
            this.texture = _texture;
            this.color = _color;
            this.size = new Vector2(_sizeX,_sizeY);
            this.hitbox_size = new Vector2(_hitbox_sizeX,_hitbox_sizeY);
            this.speed = _speed;



            Left_key = _keyleft;
            Right_key = _keyright;
            Shoot_key = _keyshoot;
        
        }

        private void Intput()
        {
            vel = 0;
            has_shot = false;

            if (Keyboard.GetState().IsKeyDown(Left_key) && Keyboard.GetState().IsKeyDown(Right_key))
            {
                
            }
            else if (Keyboard.GetState().IsKeyDown(Left_key))
            {
                vel = -speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Right_key))
            {
                vel = speed;
            }

            if (weapon_cooldown_timer >= 0)
            {
                if (Keyboard.GetState().IsKeyDown(Shoot_key))
                {
                    has_shot = true;
                    weapon_cooldown_timer = -curent_weapon.cooldown;
                    Stagger(curent_weapon.cooldown+1);
                }
            }
            else
            {
                weapon_cooldown_timer++;
            }

            
        }

        private void Move(float f)
        {
            pos = new Vector2(pos.X+f, pos.Y);
        }

        public void Stagger(int frames)
        {
            stagger_timer = -frames;
        }
        

        public override void Update() {
            Intput();

            if (stagger_timer >= 0)
            {
                
                Move(vel);
            }
            else { stagger_timer++; }

            Vector2 Centerd_pos = new Vector2(pos.X + Game1.Window_size.X * 0.5f, pos.Y);


            hitbox = GlobalMethods.Centralized_Rectangle(Centerd_pos, hitbox_size + size);
            spriteBox = GlobalMethods.Centralized_Rectangle(Centerd_pos, size);
            

            

        }

        public override void Draw(SpriteBatch __spriteBatch)
        {
            
            __spriteBatch.Draw(texture, spriteBox, color);
        }

    }
}
