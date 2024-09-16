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
    public class UI_element
    {
        public string UI_text {  get; private set; }
        public float UI_numb;
        

        public void Uppdate_UI_numb(float number)
        {
            UI_numb = number;
        }

        public SpriteFont Font {  get; private set; }
        public Vector2 Text_pos;
        public Color Text_color;

        

        public UI_element(SpriteFont font, Vector2 text_pos, Color text_color, string text)
        {
            UI_text = text;
            Font = font;
            Text_pos = text_pos;
            Text_color = text_color;

            
        }

        public void draw(SpriteBatch _spriteBatch)
        {
            string full_text = UI_text;

            if(UI_numb != 0)
            {
                full_text = UI_text + UI_numb;
            }
            

            _spriteBatch.DrawString(Font,full_text, Text_pos, Text_color);
            
            
            
        }


    }
}
