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
    public class Explotion : GameObject
    {
        
        
        public Color starting_color { get; private set; }
        public Color end_color { get; private set; }
        

        public int timer { get; private set; }
        private int timer_start;


        public Explotion(Vector2 _center, int _size, Color _starting_color, SpriteSheet _sprite, int _lastyness) : base(colition_tags.other, _sprite, new Vector2(_size,_size), new Vector2(), _starting_color)
        {
            position = new Vector2( _center.X - Game1.Window_size.X*0.5f, _center.Y);
            
            starting_color = _starting_color;
            //end_color = _end_color;
            sprite = _sprite;
            timer = _lastyness;
            timer_start = _lastyness;
            run_animation = true;
        }


        public override void Update()
        {
            

            base.Update();
            timer--;
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            base.Draw(_spriteBatch);

        }


    }
}
