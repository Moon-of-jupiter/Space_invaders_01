﻿using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Space_invaders_01;
namespace Space_invaders_01
{
    public class SubGameState_Paused : GameState_Foundation
    {
        

        public GameState_Foundation previous_GameState;

        public UI_maneger UserInterface { get; private set; }

        public SubGameState_Paused(KeybindManeger _keys, GameState_Controler _controler_reference) : base(_keys)
        {
            

            //previous_GameState = _previous_GameState;
            /*
            UserInterface_Foundation[] _ui = new UserInterface_Foundation[1]
            {
                new UserInterface_Switch_GameState(Game1.pixel, Color.White, "return", Game1.Window_size*0.5f, new Vector2(100, 50), _previous_GameState, _controler_reference)
            };
            */

           
            //UserInterface = new UI_maneger(_ui);
        }


        public override void Update()
        {

            base.Update();
            //UserInterface.Run();
            
            

            
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            
            
            base.Draw(_spriteBatch);

            


            //UserInterface.Draw(_spriteBatch);

            
        }




    }
}
