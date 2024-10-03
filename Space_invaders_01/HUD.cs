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
    public class HUD
    {
        public HUD_element[] text_interface;
        public RTD_rectangle[] rectangles_interface;
        
        //public Rectangle[] UI_BG;

        public HUD(HUD_element[] array_of_ui, RTD_rectangle[] arry_of_ui_backgrounds)
        {
            text_interface = array_of_ui;
            rectangles_interface = arry_of_ui_backgrounds;
        }



        public void Draw(SpriteBatch _spriteBatch)
        {
            foreach (RTD_rectangle rectangle in rectangles_interface)
            {
                rectangle.draw(_spriteBatch);
            }
            foreach (HUD_element text in text_interface)
            {
                text.draw(_spriteBatch);
            }
            
        }

    }
}
