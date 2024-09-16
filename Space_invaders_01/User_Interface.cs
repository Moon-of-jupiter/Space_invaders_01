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
    public class User_Interface
    {
        public UI_element[] text_interface;
        //public Rectangle[] UI_BG;

        public User_Interface(UI_element[] list_of_ui)
        {
            text_interface = list_of_ui;
        }



        public void Draw(SpriteBatch _spriteBatch)
        {
            foreach(UI_element text in text_interface)
            {
                text.draw(_spriteBatch);
            }
            
        }

    }
}
