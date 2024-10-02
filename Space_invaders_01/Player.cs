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
        public Weapon curent_weapon;

        public KeybindManeger _keybindManeger;
        

        
        //world properties
        
        public float vel;

        //visual properties



        private float speed;
        private float base_speed;

        public Player_Stat_Upgrade stat_bonus {  get; set; }
        public int bonus_upgrade_timer {  get; set; } = -1;

        public Keys Left_key { get; set; }
        public Keys Right_key { get; set; }
        public Keys Shoot_key { get; set; }


        public Rectangle spriteBox;

        public Player(Vector2 _position, SpriteSheet _texture, Color _color, Weapon _weapon, int _starting_health, float _speed, int _sizeX, int _sizeY, int _hitbox_sizeX, int _hitbox_sizeY, KeybindManeger _keys) : base(colition_tags.player, _texture, new Vector2(_sizeX,_sizeY), new Vector2(_hitbox_sizeX,_hitbox_sizeY), _color) {
            stat_bonus = new Player_Stat_Upgrade(0,0);
            
            damege = 1000;
            
            can_colide_with = new colition_tags[] { colition_tags.enemy };

            curent_weapon = _weapon;

            health = _starting_health;
            position = _position;
            vel = 0;
            sprite = _texture;
            
            spritesize = new Vector2(_sizeX,_sizeY);
            
            
            size = new Vector2(_hitbox_sizeX, _hitbox_sizeY);
            base_speed = _speed;

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
                    if (curent_weapon.stagger_on_cooldown)
                    {
                        Stagger(curent_weapon.cooldown + 1);
                    }
                    
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
            if(bonus_upgrade_timer == 0)
            {
                stat_bonus = new Player_Stat_Upgrade(0, 0);
                bonus_upgrade_timer = -1;
            }
            else
            {
                bonus_upgrade_timer--;
            }


            speed = base_speed + stat_bonus.speed;
            curent_weapon.damege_bonus = stat_bonus.damege;


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
