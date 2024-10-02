using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Space_invaders_01;
namespace Space_invaders_01
{
    public class SubGameState_BackGround : GameState_Foundation
    {
        private GameObject[] stars;
        private Random random = new Random();
        public SubGameState_BackGround(int[] _stars_in_size_threshold, SpriteSheet[] _sprites) : base(null, null)
        {
            int nr_of_stars = 0;
            for(int i = 0; i < _stars_in_size_threshold.Count(); i++)
            {
                nr_of_stars += _stars_in_size_threshold[i];
            }

            stars = new GameObject[nr_of_stars];

            int star_counter = 0;
            float last_size = 2;
            for (int i = 0; i < _stars_in_size_threshold.Count(); i++)
            {
                for (int j = 0; j < _stars_in_size_threshold[i]; j++)
                {
                    
                    
                    stars[star_counter] = new_star((int)last_size, (int)(last_size * (1 + last_size * 0.1f)), _sprites[random.Next(0, _sprites.Count())]);
                    star_counter++;
                }
                last_size = last_size * (1 + last_size*0.1f);
            }
            
        }

        private GameObject new_star(int _min_size, int _max_size, SpriteSheet _sprite)
        {
            


            
            int size = random.Next(_min_size, _max_size);

            GameObject _star;

            



            Color rColor = new Color(random.Next(200, 255), random.Next(200, 255), random.Next(200, 255));

            
            
            _star = new GameObject(GameObject.colition_tags.other, _sprite, new Vector2(size, size), new Vector2(0, 0), rColor);
            

            int randX = random.Next(-(int)(Game1.Window_size.X * 0.5f), (int)(Game1.Window_size.X * 0.5f));
            int randY = random.Next(0, (int)Game1.Window_size.Y);

            _star.position = new Vector2(randX, randY);

            return _star;
            


        }

        public override void Update()
        {
            base.Update();
            for (int i = 0; i < stars.Count(); i++)
            {
                stars[i].Update();
            }
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            base.Draw(_spriteBatch);

            for(int i = 0; i < stars.Count(); i++)
            {
                stars[i].Draw(_spriteBatch);
            }
        }


    }
}
