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
    public class UserInterface_Foundation
    {
        public Texture2D Texture { get; private set; }
        public Color Color { get; private set; }

        public string Text { get; private set; }

        public Rectangle Rectangle { get; private set; }

        public bool is_pressed = false;

        public UserInterface_Foundation(Texture2D _texture, Color _color, string _text, Vector2 _position, Vector2 _size)
        {
            Texture = _texture;
            Color = _color;
            Text = _text;

            Rectangle = GlobalMethods.Centralized_Rectangle(_position, _size);

        }

        public virtual void Run()
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed && Rectangle.Contains(Mouse.GetState().Position))
            {
                is_pressed = true;
            }

        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(Texture, Rectangle, Color);
        }
    }
}
