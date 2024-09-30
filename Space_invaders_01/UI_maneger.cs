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
        public UserInterface_Foundation[] UI_ellements;

        public UI_maneger(UserInterface_Foundation[] _ui_ellements)
        {
            UI_ellements = _ui_ellements;

        }

        public void Run()
        {
            for (int i = 0; i < UI_ellements.Length; i++)
            {
                UI_ellements[i].Run();
            }

        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            for (int i = 0; i < UI_ellements.Length; i++)
            {
                UI_ellements[i].Draw(_spriteBatch);
            }
        }

    }
}
