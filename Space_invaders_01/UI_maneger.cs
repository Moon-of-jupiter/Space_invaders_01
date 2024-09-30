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
    public class UI_maneger
    {
        public UserInterface_Foundation[][] UI_ellements;
        public int page = 0;

        KeybindManeger _keybindManeger;
        
        public UI_maneger(KeybindManeger _keys, UserInterface_Foundation[][] _ui_ellements)
        {
            
            UI_ellements = _ui_ellements;

            for(int i = 0; i < UI_ellements.Length; i++)
            {
                for (int j = 0; j < UI_ellements[i].Length; j++)
                {
                    UI_ellements[i][j]._keybindManeger = _keys;
                }

            }

        }

        public void Run()
        {
            for (int i = 0; i < UI_ellements[page].Length; i++)
            {
                UI_ellements[page][i].Run();
            }

        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            

            for (int i = 0; i < UI_ellements[page].Length; i++)
            {
                UI_ellements[page][i].Draw(_spriteBatch);
            }
        }

    }
}
