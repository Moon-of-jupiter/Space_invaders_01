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
        public Texture2D texture;
        public Vector2 position;
        public Vector2 size;
        public Rectangle hitbox;
        public Color color;
        public float health;
        public float damege;

        

        public List<Type> can_colide_with;



        

        public GameObject()
        {

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
