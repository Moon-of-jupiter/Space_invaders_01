using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Space_invaders_01;
using static Space_invaders_01.GameState_Controler;

namespace Space_invaders_01
{
    

    public class GameState_Controler
    {
        public enum GameStates 
        {
            Paused =    0, 
            MainMenue = 1, 
            InGame =    2, 
            EndScreen = 3
        }

        public GameStates _gamestates;


        public KeybindManeger _keybindManeger;

        public SubGameState_Paused Paused;
        public GameState_MainMenue MainMenue;
        public GameState_InGame InGame;
        public GameState_EndScreen EndScreen;
        



         
        public GameState_Controler(KeybindManeger _keys) 
        {

            _keybindManeger = _keys;
            _gamestates = GameStates.InGame;
            

            Reset_Gamestate(GameStates.Paused);
            Reset_Gamestate(GameStates.MainMenue);
            Reset_Gamestate(GameStates.InGame);
            Reset_Gamestate(GameStates.EndScreen);

        }



        
       

        private void Reset_Gamestate(GameStates __gamestates)
        {
            
            if(__gamestates == GameStates.Paused)
            {
                Paused = new SubGameState_Paused(_keybindManeger, this);
            }
            else if(__gamestates == GameStates.MainMenue)
            {
                MainMenue = new GameState_MainMenue(_keybindManeger);
            }
            else if (__gamestates == GameStates.InGame)
            {
                InGame = new GameState_InGame(_keybindManeger);
            }
            else if (__gamestates == GameStates.EndScreen)
            {
                EndScreen = new GameState_EndScreen(_keybindManeger);
            }

            
        }

        public void New_Gamestate(GameState_Foundation _next_gamestate)
        {
            if (_next_gamestate != null)
            {
                
            }

        }
        
        public void Update_Current_Gamespace()
        {

            //New_Gamestate(current_gamestate.Next_state);
            /*
            if (current_gamestate.can_pause && Keyboard.GetState().IsKeyDown(_keybindManeger.Pause))
            {
                current_gamestate = new SubGameState_Paused(_keybindManeger, current_gamestate, this);
            }
            */

            if (_gamestates == GameStates.Paused)
            {
                Paused.Update();
            }
            else if (_gamestates == GameStates.MainMenue)
            {
                MainMenue.Update();
            }
            else if (_gamestates == GameStates.InGame)
            {
                InGame.Update();


            }
            else if (_gamestates == GameStates.EndScreen)
            {
               EndScreen.Update();
            }
        }

        public void Draw_Current_Gamespace(SpriteBatch _spriteBatch)
        {
            if (_gamestates == GameStates.Paused)
            {
                InGame.Draw(_spriteBatch);
                Paused.Draw(_spriteBatch);
            }
            else if (_gamestates == GameStates.MainMenue)
            {
                MainMenue.Draw(_spriteBatch);
            }
            else if (_gamestates == GameStates.InGame)
            {
                InGame.Draw(_spriteBatch);
            }
            else if (_gamestates == GameStates.EndScreen)
            {
                EndScreen.Draw(_spriteBatch);
            }
        }

        

    }
}
