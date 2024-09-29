﻿using System;
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
        public Texture2D texture;
        public Vector2 position;
        public Vector2 size;
        public Rectangle hitbox;
        public Color color;
        public float health;
        public float damege;

        public enum colition_tags { player = 1, enemy = 2, prodectile = 3}
        protected colition_tags tag;
        protected colition_tags[] can_colide_with;



        public GameObject()
        {
            
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

        }

        public virtual void Draw(SpriteBatch _spriteBatch)
        {
            Rectangle SpriteBox = GlobalMethods.Centralized_Rectangle(position, size);
            _spriteBatch.Draw(texture, SpriteBox, color);
        }




    }
}
