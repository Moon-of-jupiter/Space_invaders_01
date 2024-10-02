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

        public KeybindManeger _keybindManeger;
        

        
        //world properties
        
        public float vel;

        //visual properties
        
        public Vector2 hitbox_size;

        public float speed;

        public Keys Left_key;
        public Keys Right_key;
        public Keys Shoot_key;

        
        public Rectangle spriteBox;

        public Player(Vector2 _position, SpriteSheet _texture, Color _color, int _starting_health, float _speed, int _sizeX, int _sizeY, int _hitbox_sizeX, int _hitbox_sizeY, KeybindManeger _keys) : base(colition_tags.player, _texture, new Vector2(_sizeX,_sizeY), new Vector2(_hitbox_sizeX,_hitbox_sizeY), _color) {
            damege = 1000;
            
            can_colide_with = new colition_tags[1] { colition_tags.enemy };

            this.health = _starting_health;
            position = _position;
            this.vel = 0;
            this.sprite = _texture;
            
            this.spritesize = new Vector2(_sizeX,_sizeY);
            this.hitbox_size = new Vector2(_hitbox_sizeX, _hitbox_sizeY);
            this.size = new Vector2(_sizeX, _sizeY);
            this.speed = _speed;

            _keybindManeger = _keys;


            Left_key = _keybindManeger.player_move_left;
            Right_key = _keybindManeger.player_move_right;
            Shoot_key = _keybindManeger.player_shoot;
        
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
                    run_animation = true;
                }
            }
            else
            {
                weapon_cooldown_timer++;
            }

            
        }

        private void Move(float f)
        {
            position = new Vector2(position.X+f, position.Y);
        }

        public void Stagger(int frames)
        {
            stagger_timer = -frames;
        }
        

        public override void Update() {
            if (health > 0)
            {
                Intput();

                

                if (stagger_timer >= 0)
                {

                    Move(vel);
                }
                else { stagger_timer++; }

                base.Update();

                
            }
            else
            {
                health = 0;
            }
            
            
        }

        public override void Draw(SpriteBatch __spriteBatch)
        {
            if (health > 0)
            {
                base.Draw(__spriteBatch);
            }
        }

    }
}
