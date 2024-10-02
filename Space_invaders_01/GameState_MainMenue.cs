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
    public class GameState_MainMenue : GameState_Foundation
    {
        
        private float source_rectangle_trevertial;
        private UI_maneger userinterface;
        private Random random = new Random();

        public GameState_MainMenue(KeybindManeger _keys, GameState_Foundation _previous_gamestate) : base(_keys, _previous_gamestate)
        {
            UserInterface_Foundation[] _uipg1 = new UserInterface_Foundation[1]
            {
                new UserInterface_Switch_GameState(SpriteManeger.play_button_01.texture, SpriteManeger.space_teal, "", Game1.Window_size*0.5f, new Vector2(200, 100), new GameState_InGame(_keys, this, 1), this)
            };
            UserInterface_Foundation[] _uipg2 = new UserInterface_Foundation[3]
            {
                new UserInterface_Switch_GameState(SpriteManeger.lvl1_button.texture, SpriteManeger.space_teal, "",new Vector2(Game1.Window_size.X *0.5f , Game1.Window_size.Y *0.5f - 120), new Vector2(200, 100), new GameState_InGame(_keys, this, 1), this),
                new UserInterface_Switch_GameState(SpriteManeger.lvl2_button.texture, SpriteManeger.space_teal, "",new Vector2(Game1.Window_size.X *0.5f , Game1.Window_size.Y *0.5f), new Vector2(200, 100), new GameState_InGame(_keys, this, 2), this),
                new UserInterface_Switch_GameState(SpriteManeger.lvl3_button.texture, SpriteManeger.space_teal, "",new Vector2(Game1.Window_size.X *0.5f , Game1.Window_size.Y *0.5f + 120), new Vector2(200, 100), new GameState_InGame(_keys, this, 3), this)
            };

            UserInterface_Foundation[][] _ui = new UserInterface_Foundation[2][] {_uipg1, _uipg2};

            

           

            userinterface = new UI_maneger(_keybindManeger, _ui);
            userinterface.page = 1;
        }

        public override void Update()
        {
            base.Update();
            userinterface.Run();
            
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            
            base.Draw(_spriteBatch);
            
            

            userinterface.Draw(_spriteBatch);
            



            
        }

    }
}
