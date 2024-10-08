﻿using System;
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
    public class GameState_EndScreen : GameState_Foundation
    {
        public GameState_Foundation previous_GameState {  get; private set; }
        
        public UI_maneger userinterface { get; private set; }

        


        public GameState_EndScreen(KeybindManeger _keys, GameState_Foundation _previous_GameState, bool _win) : base(_keys, _previous_GameState)
        {
            
            Color _color = Color.Tomato;
            if (_win)
            {
                _color = SpriteManeger.ailien_mint;
            }

            previous_GameState = _previous_GameState;
            
            UserInterface_Foundation[][] _ui = new UserInterface_Foundation[1][]
            {
                new UserInterface_Foundation[1]
                {
                    new UserInterface_Switch_GameState(SpriteManeger.game_over01.texture, _color, "Main Menue", new Vector2(Game1.Window_size.X*0.5f,Game1.Window_size.Y*0.5f), new Vector2(500, 250), new GameState_MainMenue(_keybindManeger,this), this),
                }
            };

            userinterface = new UI_maneger(_keys);
            userinterface.Initialize(_ui);

        }

        

        public override void Update()
        {
            base.Update();

            previous_GameState.Update();

            userinterface.Run();
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            base.Draw(_spriteBatch);

            previous_GameState.Draw(_spriteBatch);
            
            userinterface.Draw(_spriteBatch);
            
            
            
        }

    }
}
