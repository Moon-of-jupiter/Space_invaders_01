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
    public class UserInterface_next_page : UserInterface_Foundation
    {
        public UI_maneger UI {  get; private set; }
        public int UI_page_path { get; private set; }
        public UserInterface_next_page(Texture2D _texture, Color _color, string _text, Vector2 _position, Vector2 _size, UI_maneger _ui, int _page) : base(_texture, _color, _text, _position, _size)
        {
            UI = _ui;
            UI_page_path = _page;

        }

        public override void Run()
        {
            base.Run();
            if (is_pressed)
            {
                _keybindManeger.Run();
                UI.page = UI_page_path;
            }

        }

    }
}
