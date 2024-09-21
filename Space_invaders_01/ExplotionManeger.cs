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

        private int standard_lastyness = 5;
        private Random random = new Random();

        public void Explotion_FromPoint(Vector2 _epicenter, int _size, Color _starting_color, Texture2D _texture, int _lastyness)
        {
            Explotion explotion = new Explotion(_epicenter, _size, _starting_color, _texture, _lastyness);
            explotions.Add(explotion);
        }

        public void Random_Explotion_FromPoint(Vector2 _epicenter, int _aproximeat_size)
        {
            int r1 = random.Next(0,50);
            int r2 = random.Next(0, 50);
            int r3 = random.Next(0, 50);
            int r4 = random.Next(100, 200);
            int r5 = random.Next(0, 5);


            Color _starting_color = new Color(200 + r1 + r2,150 + r1,100 + r3);
            Texture2D _texture = Game1.pixel; // temp


            int _size = (int)(_aproximeat_size * (float)(r4*0.01f));
            int _lastyness = standard_lastyness + r5;


            Explotion_FromPoint(_epicenter,_size,_starting_color, _texture, _lastyness);


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
