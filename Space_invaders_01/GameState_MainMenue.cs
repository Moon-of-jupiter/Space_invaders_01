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


           

            userinterface = new UI_maneger(_keybindManeger, _ui);

        }

        public override void Update()
        {
            base.Update();
            userinterface.Run();
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            Texture2D tex = SpriteManeger.stars_space01;
            base.Draw(_spriteBatch);
            int _source_rectangle_trevertial = (int)((tex.Height-tex.Width) * source_rectangle_trevertial);


            Rectangle source_rectange = new Rectangle(0,_source_rectangle_trevertial, tex.Width,tex.Width);
            Rectangle destination_rectangle = new Rectangle(0, 0, (int)Game1.Window_size.X, (int)Game1.Window_size.Y);



            _spriteBatch.Draw(tex, destination_rectangle, source_rectange, Color.White );
            userinterface.Draw(_spriteBatch);

            source_rectangle_trevertial-=0.001f;
            if(source_rectangle_trevertial < 0)
            {
                source_rectangle_trevertial = 1;
            }
        }

    }
}
