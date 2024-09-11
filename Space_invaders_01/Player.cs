﻿using System;
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
        //world properties
        public Vector2 pos;
        public float vel;

        //visual properties
        public Texture2D texture;
        public Color color;
        public Vector2 size;

        public float speed;

        public int HP;

        public Player(Vector2 p, Texture2D t, Color c, int h, float s, int s_x, int s_y) { 
            this.pos = p;
            this.vel = 0;
            this.texture = t;
            this.color = c;
            this.size = new Vector2(s_x,s_y);
            this.speed = s;
            this.HP = h;
        
        }

        private void intput()
        {
            vel = 0;
            if (Keyboard.GetState().IsKeyDown(Keys.Left) && Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                vel = -speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                vel = speed;
            }
            
        }

        private void move(float f)
        {
            pos = new Vector2(pos.X+f, pos.Y);
        }

        public void run(GameTime gameTime) {
            intput();
            move(vel);

        }

        public void draw(SpriteBatch __spriteBatch)
        {
            
            Vector2 Centerd_pos = new Vector2(pos.X+ Game1.Window_size.X*0.5f,pos.Y);
            
            Vector2 offset_pos = new Vector2(Centerd_pos.X - size.X * 0.5f, Centerd_pos.Y - size.Y * 0.5f );

            Rectangle _rectangle = new Rectangle((int)offset_pos.X,(int)offset_pos.Y,(int)size.X,(int)size.Y);
            __spriteBatch.Draw(texture, _rectangle, color);
        }

    }
}
