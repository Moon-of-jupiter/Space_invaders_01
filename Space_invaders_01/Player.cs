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
    public class Player
    {

        

        public int stagger_timer = 0;

        public int weapon_cooldown_timer = 0;
        public bool has_shot = false;
        public Prodectile_type curent_weapon;

        
        //world properties
        public Vector2 pos;
        public float vel;

        //visual properties
        public Texture2D texture;
        public Color color;
        public Vector2 size;
        public Vector2 hitbox_size;

        public float speed;

        public Keys Left_key;
        public Keys Right_key;
        public Keys Shoot_key;

        public Rectangle hitBox;
        public Rectangle spriteBox;

        public Player(Vector2 p, Texture2D t, Color c, float s, int s_x, int s_y, int hb_s_x, int hb_s_y) {
            
            this.pos = p;
            this.vel = 0;
            this.texture = t;
            this.color = c;
            this.size = new Vector2(s_x,s_y);
            this.hitbox_size = new Vector2(hb_s_x,hb_s_y);
            this.speed = s;



            Left_key = Keys.A;
            Right_key = Keys.D;
            Shoot_key = Keys.Space;
        
        }

        private void intput()
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
                    stagger(curent_weapon.cooldown+1);
                }
            }
            else
            {
                weapon_cooldown_timer++;
            }

            
        }

        private void move(float f)
        {
            pos = new Vector2(pos.X+f, pos.Y);
        }

        public void stagger(int frames)
        {
            stagger_timer = -frames;
        }
        

        public void Update() {
            intput();

            if (stagger_timer >= 0)
            {
                
                move(vel);
            }
            else { stagger_timer++; }

            Vector2 Centerd_pos = new Vector2(pos.X + Game1.Window_size.X * 0.5f, pos.Y);

            Vector2 offset_pos = new Vector2(Centerd_pos.X - size.X * 0.5f, Centerd_pos.Y - size.Y * 0.5f);

            hitBox = new Rectangle((int)offset_pos.X, (int)offset_pos.Y, (int)(hitbox_size.X+size.X), (int)(hitbox_size.Y + size.Y));
            spriteBox = new Rectangle((int)offset_pos.X, (int)offset_pos.Y, (int)size.X, (int)size.Y);

        }

        public void draw(SpriteBatch __spriteBatch)
        {
            


            __spriteBatch.Draw(texture, spriteBox, color);
        }

    }
}
