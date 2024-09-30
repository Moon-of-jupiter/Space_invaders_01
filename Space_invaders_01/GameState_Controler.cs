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
        

        public KeybindManeger _keybindManeger;



        private GameState_Foundation current_gamestate;
        public GameState_Controler(KeybindManeger _keys) 
        {
            _keybindManeger = _keys;
            current_gamestate = new GameState_MainMenue(_keybindManeger);
            
        }

        public void New_Gamestate(GameState_Foundation _next_gamestate)
        {
            if (_next_gamestate != null)
            {
                current_gamestate = _next_gamestate;
            }

        }
        
        public void Update_Current_Gamespace()
        {
            New_Gamestate(current_gamestate.Next_state);

            if (current_gamestate.can_pause && Keyboard.GetState().IsKeyDown(_keybindManeger.Pause))
            {
                current_gamestate = new SubGameState_Paused(_keybindManeger, current_gamestate, this);
            }

            
            current_gamestate.Update();
        }

        public void Draw_Current_Gamespace(SpriteBatch _spriteBatch)
        {
            current_gamestate.Draw(_spriteBatch);
        }

        

    }
}
