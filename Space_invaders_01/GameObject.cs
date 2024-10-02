using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Space_invaders_01;

namespace Space_invaders_01
{
    public class GameObject
    {
        
        public SpriteSheet sprite;
        public Vector2 position;
        public Vector2 size;
        public Vector2 spritesize;
        public Rectangle hitbox;
        public Rectangle spritebox;
        public Color color;
        public float health;
        public float damege;
        Random random = new Random();

        

        public float animation_multiplier = 1;

        public bool run_animation;
        private int animation_step;
        private float animation_timer = 0;
        private int animation_sleep_timer;

        public enum colition_tags { other = 0,  player = 1, enemy = 2, prodectile = 3}
        protected colition_tags tag;
        protected colition_tags[] can_colide_with;



        public GameObject(colition_tags _tag, SpriteSheet _sprite, Vector2 _sprite_size, Vector2 _hitbox_size, Color _color)
        {
            color = _color;
            sprite = _sprite;
            spritesize = _sprite_size;
            size = _hitbox_size;

            animation_sleep_timer = _sprite.offset *(int)(random.Next(0,20)*0.1f);

            tag = _tag;


        }

        public int get_tag()
        {
            int t = (int)tag;
            return t;
        }

        public int[] get_can_colide_with()
        {
            if(can_colide_with == null) { return new int[0]; }


            
            int[] colition = new int[can_colide_with.Length];
            for(int i = 0; i < colition.Length; i++)
            {
                colition[i] = (int)can_colide_with[i];
            }

            return colition;
        }


        public virtual void Update()
        {
            if (animation_sleep_timer <= 0 && (sprite.is_triggerd == false || run_animation))
            {
                
                if (animation_timer >= sprite.frames_per_step)
                {
                    animation_step++;
                    animation_timer = 0;
                }

                if (animation_step >= sprite.steps)
                {
                    animation_step = 0;
                    run_animation = false;
                }

                



            }
            Vector2 Centerd_pos = new Vector2(position.X + Game1.Window_size.X * 0.5f, position.Y);


            hitbox = GlobalMethods.Centralized_Rectangle(Centerd_pos, size);
            

        }

        public virtual void Draw(SpriteBatch _spriteBatch) 
        {
            Vector2 Centerd_pos = new Vector2(position.X + Game1.Window_size.X * 0.5f, position.Y);
            Rectangle SpriteBox = GlobalMethods.Centralized_Rectangle(Centerd_pos, spritesize);
            Texture2D texture = sprite.texture;
            
            if (sprite.is_animated )
            {
                
                if (animation_sleep_timer <= 0 && ( sprite.is_triggerd == false || run_animation ))
                {
                    int converted_animation_step = animation_step * (texture.Height + 1);
                    Rectangle sourceRectangle = new Rectangle(converted_animation_step, 0, texture.Height, texture.Height);
                    _spriteBatch.Draw(texture, SpriteBox, sourceRectangle, color);


                    animation_timer += animation_multiplier;

                }
                else
                {
                    animation_sleep_timer--;
                    Rectangle sourceRectangle = new Rectangle(0, 0, texture.Height, texture.Height);
                    _spriteBatch.Draw(texture, SpriteBox, sourceRectangle, color);

                }
            }
            else
            {
                _spriteBatch.Draw(texture, SpriteBox, color);
            }
        }




    }
}
