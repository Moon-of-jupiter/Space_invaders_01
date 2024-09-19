using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.XAudio2;
using Space_invaders_01;
namespace Space_invaders_01
{
    public class RTD_rectangle // ready to draw rectangle
    {
        public Color color;
        public Texture2D texture;
        public Rectangle rectangle{ get; private set; }

        public RTD_rectangle(Color _color, Texture2D _texture, Vector2 _pos, int _width, int _hight)
        {
            color = _color;
            texture = _texture;

            rectangle = new Rectangle((int)_pos.X, (int)_pos.Y, _width, _hight);
            
        }

        public void draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(texture, rectangle, color);
        }
        
        


    }
}
