using System;
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

        

        public SubGameState_Paused(KeybindManeger _keys, GameState_Foundation _previous_GameState, GameState_Controler _controler_reference) : base(_keys, _previous_GameState)
        {
            

            previous_GameState = _previous_GameState;

            UserInterface_Foundation[][] _ui = new UserInterface_Foundation[1][]
            {
                new UserInterface_Foundation[2]
                { 
                    new UserInterface_Switch_GameState(Game1.pixel, Color.White, "return", new Vector2(Game1.Window_size.X*0.5f,Game1.Window_size.Y*0.5f-60), new Vector2(100, 50), _previous_GameState, this),
                    new UserInterface_Switch_GameState(Game1.pixel, Color.White, "menue", new Vector2(Game1.Window_size.X*0.5f,Game1.Window_size.Y*0.5f), new Vector2(100, 50), new GameState_MainMenue(_keybindManeger, this), this),
                }
            };

            UserInterface = new UI_maneger( _keybindManeger);
            UserInterface.Initialize(_ui);
        }


        public override void Update()
        {

            base.Update();
            UserInterface.Run();
            if (_keybindManeger.Pause_key_pressed())
            {
                
                New_Gamestate(previous_GameState);
                
                
            }
            
            

            
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            
            
            base.Draw(_spriteBatch);

            previous_GameState.Draw(_spriteBatch);


            UserInterface.Draw(_spriteBatch);

            
        }




    }
}
