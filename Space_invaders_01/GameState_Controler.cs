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
    

    public class GameState_Controler
    {
        public enum GameState {MainMenue = 0, InGame = 1, EndScreen = 2};
        public GameState _gameState;

        

        private GameState_Foundation current_gamestate;
        public GameState_Controler() {
            current_gamestate = new GameState_InGame();
            
        }

        public void Update_Current_Gamespace()
        {
            if(current_gamestate.Next_state != null)
            {
                current_gamestate = current_gamestate.Next_state;
            }
            current_gamestate.Update();
        }

        public void Draw_Current_Gamespace(SpriteBatch _spriteBatch)
        {
            current_gamestate.Draw(_spriteBatch);
        }

        

    }
}
