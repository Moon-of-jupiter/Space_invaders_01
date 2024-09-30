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

        private UI_maneger userinterface;

        public GameState_MainMenue(KeybindManeger _keys) : base(_keys)
        {
            UserInterface_Foundation[] _uipg1 = new UserInterface_Foundation[1]
            {
                new UserInterface_Switch_GameState(Game1.pixel, Color.White, "return", Game1.Window_size*0.5f, new Vector2(100, 50), new GameState_InGame(_keys), this)
            };
            UserInterface_Foundation[] _uipg2 = new UserInterface_Foundation[1]
            {
                new UserInterface_Switch_GameState(Game1.pixel, Color.White, "return", Game1.Window_size*0.5f, new Vector2(200, 50), new GameState_InGame(_keys), this)
            };

            UserInterface_Foundation[][] _ui = new UserInterface_Foundation[2][] {_uipg1, _uipg2};


           

            userinterface = new UI_maneger(_ui);

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
