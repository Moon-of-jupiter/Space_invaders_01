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
    public class UserInterface_Switch_GameState : UserInterface_Foundation
    {
        public GameState_Foundation GameState_path {  get; private set; }

        private GameState_Foundation gamestate_reference;
       

        public UserInterface_Switch_GameState(Texture2D _texture, Color _color, string _text, Vector2 _position, Vector2 _size, GameState_Foundation _path, GameState_Foundation _gamestate_reference) : base( _texture, _color, _text, _position, _size)
        {
            gamestate_reference = _gamestate_reference;
            GameState_path = _path;
        }

        

        public override void Run()
        {
            base.Run();
            if (is_pressed)
            {
                gamestate_reference.new_gamestate(GameState_path);
            }


        }



    }
}
