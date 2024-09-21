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
    public class Explotion
    {
        public Vector2 epicenter_point {  get; private set; }
        public int size {  get; private set; }
        public Color starting_color { get; private set; }
        public Color end_color { get; private set; }
        public Texture2D texture { get; private set; }

        public int timer { get; private set; }
        private int timer_start;


        public Explotion(Vector2 _center, int _size, Color _starting_color, Texture2D _texture, int _lastyness)
        {
            epicenter_point = _center;
            size = _size;
            starting_color = _starting_color;
            //end_color = _end_color;
            texture = _texture;
            timer = _lastyness;
            timer_start = _lastyness;
        }


        public void Update()
        {
            timer--;
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            Vector2 offset = new Vector2(epicenter_point.X-size*0.5f, epicenter_point.Y - size*0.5f);
            Rectangle rectangle_to_draw = new Rectangle((int)offset.X, (int)offset.Y,size,size);
            
            
            _spriteBatch.Draw(texture,rectangle_to_draw,starting_color);

        }


    }
}
