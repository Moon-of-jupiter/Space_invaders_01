using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.DXGI;
using Space_invaders_01;
namespace Space_invaders_01
{
    public class ExplotionManeger
    {
        public List<Explotion> explotions = new List<Explotion>();

        
        private Random random = new Random();

        
        

        public void Explotion_FromPoint(Vector2 _epicenter, int _size, Color _starting_color, SpriteSheet _sprite, int _lastyness)
        {
            Explotion explotion = new Explotion(_epicenter, _size, _starting_color, _sprite, _lastyness);
            explotions.Add(explotion);

            
        }

        public void Random_Explotion_FromPoint(Vector2 _epicenter, int _aproximeat_size)
        {
            int r1 = random.Next(0,50);
            int r2 = random.Next(0, 50);
            int r3 = random.Next(0, 50);
            int r4 = random.Next(100, 200);
            int r5 = random.Next(0, 5);

            Color _color = SpriteManeger.space_oragne;

            Color _starting_color = new Color(_color.R + r1 + r2,_color.G + r1,_color.B + r3);

            SpriteSheet _sprite = SpriteManeger.explotion_sprite_sheet_01;


            int _size = (int)(_aproximeat_size * (float)(r4*0.01f));
            int _lastyness = _sprite.frames_per_step * _sprite.steps;


            Explotion_FromPoint(_epicenter,_size, _starting_color, _sprite, _lastyness);


        }



        public void Update()
        {
            for (int i = 0; i < explotions.Count; i++) 
            {
                if (explotions[i].timer <= 0)
                {
                    explotions.Remove(explotions[i]);
                    i--;
                }
                else
                {
                    explotions[i].Update();
                }

            }


        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            foreach (Explotion splotion in explotions)
            {
                
                splotion.Draw( _spriteBatch );
            }
        }

    }
}
