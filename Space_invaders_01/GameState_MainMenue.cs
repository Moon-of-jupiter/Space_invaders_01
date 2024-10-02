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
        private GameObject[] stars = new GameObject[43];
        private float source_rectangle_trevertial;
        private UI_maneger userinterface;
        private Random random = new Random();

        public GameState_MainMenue(KeybindManeger _keys, GameState_Foundation _previous_gamestate) : base(_keys, _previous_gamestate)
        {
            UserInterface_Foundation[] _uipg1 = new UserInterface_Foundation[1]
            {
                new UserInterface_Switch_GameState(Game1.pixel, Color.White, "return", Game1.Window_size*0.5f, new Vector2(100, 50), new GameState_InGame(_keys, this, 3), this)
            };
            UserInterface_Foundation[] _uipg2 = new UserInterface_Foundation[1]
            {
                new UserInterface_Switch_GameState(Game1.pixel, Color.White, "return", Game1.Window_size*0.5f, new Vector2(200, 50), new GameState_InGame(_keys, this, 1), this)
            };

            UserInterface_Foundation[][] _ui = new UserInterface_Foundation[2][] {_uipg1, _uipg2};

            int star_max_size = 3;
            int star_min_size = 1;


            for(int i = 0; i < stars.Count(); i++)
            {
                int size;
                if (i > 3)
                {
                    size = random.Next(star_min_size, star_max_size);
                    size *= size * size;
                }
                else
                {
                    size = random.Next(star_min_size, star_max_size) * 20;
                }

                

                Color rColor = new Color(random.Next(200,255), random.Next(200, 255), random.Next(200, 255));

                if (i < stars.Count() * 0.5f)
                {
                    stars[i] = new GameObject(GameObject.colition_tags.other, SpriteManeger.stars_spritesheet_01, new Vector2(size, size), new Vector2(0, 0), rColor);

                }
                else
                {
                    stars[i] = new GameObject(GameObject.colition_tags.other, SpriteManeger.stars_spritesheet_02, new Vector2(size, size), new Vector2(0, 0), rColor);
                }

                int randX = random.Next(-(int)(Game1.Window_size.X * 0.5f), (int)(Game1.Window_size.X*0.5f));
                int randY = random.Next(0, (int)Game1.Window_size.Y);

                stars[i].position = new Vector2(randX, randY);


            }

           

            userinterface = new UI_maneger(_keybindManeger, _ui);

        }

        public override void Update()
        {
            base.Update();
            userinterface.Run();
            
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            
            base.Draw(_spriteBatch);
            
            foreach(GameObject star in stars)
            {
                //star.Draw(_spriteBatch);
            }

            userinterface.Draw(_spriteBatch);
            



            
        }

    }
}
