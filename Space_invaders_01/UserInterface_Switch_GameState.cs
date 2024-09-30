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

        private GameState_Controler GameState_Controler_Reference;
       

        public UserInterface_Switch_GameState(Texture2D _texture, Color _color, string _text, Vector2 _position, Vector2 _size, GameState_Foundation _path, GameState_Controler _gameState_Controler_Reference) : base( _texture, _color, _text, _position, _size)
        {
            GameState_Controler_Reference = _gameState_Controler_Reference;
            GameState_path = _path;
        }

        

        public override void Run()
        {
            base.Run();
            if (is_pressed)
            {
                GameState_Controler_Reference.New_Gamestate(GameState_path);
            }


        }



    }
}
