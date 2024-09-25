using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using SharpDX.XAudio2;
using Space_invaders_01;


namespace Space_invaders_01
{
    public class EnemyPhalanx
    {
        
        
        private Enemy[,] phalanx;

        public int center_pointX {  get; private set; }
        public float collum_spaceing {  get; private set; }
        
        public float row_spaceing { get; private set; }

        public int advancement;
        public int advancement_speed { get; private set; }

        public int direction = 1;
        private float starting_x_velocety;
        private float end_x_velocety;

        public EnemyPhalanx(Enemy_type[] rows, int nr_of_collums, int centerX, float row_space, float collum_space, int ad_speed)
        {
            collum_spaceing = collum_space;
            row_spaceing = row_space;
            advancement = 0;
            advancement_speed = ad_speed;


            phalanx = new Enemy[nr_of_collums,rows.Length];

            for (int i = 0; i < rows.Length; i++)
            {
                for (int j = 0; j < nr_of_collums; j++)
                {
                    Vector2 enemy_pos = new Vector2((i + 0.5f) * collum_spaceing - collum_spaceing * nr_of_collums * 0.5f, -rows.Length * row_spaceing);
                    phalanx[j, i] = new Enemy(rows[i],enemy_pos);
                }
            }

        }

        public EnemyPhalanx(PhalanxPreset preset)
        {
            collum_spaceing = preset.collum_space;
            row_spaceing = preset.row_space;
            advancement = 0;
            advancement_speed = preset.ad_speed;


            phalanx = new Enemy[preset.nr_of_collums, preset.rows.Length];

            for (int i = 0; i < preset.rows.Length; i++)
            {
                for (int j = 0; j < preset.nr_of_collums; j++)
                {
                    Vector2 enemy_pos = new Vector2((j + 0.5f) * collum_spaceing - collum_spaceing * preset.nr_of_collums * 0.5f, (i-preset.rows.Length) * row_spaceing);
                    phalanx[j, i] = new Enemy(preset.rows[i], enemy_pos);
                }
            }

        }


        public int Count()
        {
            int counter = 0;

            for (int i = 0; i < phalanx.GetLength(0); i++)
            {
                for (int j = 0; j < phalanx.GetLength(1); j++)
                {
                    if (phalanx[i,j] != null)
                    {
                        counter++;
                    }
                }
            }


            return counter;
        }

        

        public Rectangle Get_full_phalanx_bounds()
        {
            


            return new Rectangle();
        }

        public void Update()
        {
            for (int i = 0; i < phalanx.GetLength(0); i++)
            {
                for (int j = 0; j < phalanx.GetLength(1); j++)
                {
                    phalanx[i, j].Update(advancement);
                }
            }
            advancement += advancement_speed;
        }


        public void Draw(SpriteBatch _spriteBatch)
        {
            for (int i = 0; i < phalanx.GetLength(0); i++)
            {
                for (int j = 0; j < phalanx.GetLength(1); j++)
                {
                    phalanx[i,j].Draw(_spriteBatch);
                }
            }

        }

        
    }
}
