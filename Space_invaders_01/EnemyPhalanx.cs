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

        private Rectangle left_border;
        private Rectangle right_border;
        
        public Enemy[,] phalanx {  get; private set; }

        public int center_pointX {  get; private set; }
        public float collum_spaceing {  get; private set; }
        
        public float row_spaceing { get; private set; }

        public float advancement;
        public float advancement_speed { get; private set; }
        public float death_acceleration { get; private set; }

        private float x_acceleration;

        private float x_velocety;

        private bool has_advanced = false;

        private int border;

        public int direction = 1;
        

        /*
        public EnemyPhalanx(Enemy_type[] rows, int nr_of_collums, int centerX, float row_space, float collum_space, int ad_speed, float starting_horisontal_speed, float final_horisontal_speed)
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
        */

        public EnemyPhalanx(PhalanxPreset preset, int starting_pos)
        {
            collum_spaceing = preset.collum_space;
            row_spaceing = preset.row_space;
            advancement = 0;
            advancement_speed = preset.ad_speed;

            death_acceleration = preset.horisontal_acceleration;

            phalanx = new Enemy[preset.nr_of_collums, preset.rows.Length];

            for (int i = 0; i < preset.rows.Length; i++)
            {
                for (int j = 0; j < preset.nr_of_collums; j++)
                {
                    Vector2 enemy_pos = new Vector2((j + 0.5f) * collum_spaceing - collum_spaceing * preset.nr_of_collums * 0.5f, starting_pos + (i-preset.rows.Length) * row_spaceing);
                    phalanx[j, i] = new Enemy(preset.rows[i], enemy_pos);
                }
            }

            border = preset.boarder_distance;

            left_border = new Rectangle(0, 0, border, (int)Game1.Window_size.Y);
            right_border = new Rectangle((int)Game1.Window_size.X-border, 0, border, (int)Game1.Window_size.Y);

            x_velocety = 1;
            x_acceleration = 0.1f;

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

        public Enemy[] Get_flat_array_of_enemys()
        {
            Enemy[] all_enemies = new Enemy[Count()];
            int counter = 0;
            for (int i = 0; i < phalanx.GetLength(0); i++)
            {
                for (int j = 0; j < phalanx.GetLength(1); j++)
                {
                    if (phalanx[i,j] != null)
                    {
                        all_enemies[counter] = phalanx[i,j];
                        counter++;
                    }

                }
            }

            return all_enemies;
        }

        

        public bool check_border_colition(Rectangle r_boarder)
        {
            for (int i = 0; i < phalanx.GetLength(0); i++)
            {
                for (int j= 0; j < phalanx.GetLength(1); j++)
                {
                    if (phalanx[i, j] != null)
                    {
                        if (phalanx[i, j].hitbox.Intersects(r_boarder))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private void border_colition_logic()
        {
            x_velocety *= -1;
            if (has_advanced == false)
            {
                advancement += advancement_speed;
            }
            has_advanced = true;
        }


        public void Update()
        {
            if (check_border_colition(left_border))
            {
                if (direction < 0)
                {
                    direction = 1;
                    border_colition_logic();
                }
            }
            else if (check_border_colition(right_border))
            {
                if (direction > 0)
                {
                    direction = -1;
                    border_colition_logic();
                }

            }
            else { has_advanced = false; }


            for (int i = 0; i < phalanx.GetLength(0); i++)
            {
                for (int j = 0; j < phalanx.GetLength(1); j++)
                {
                    
                    
                    if (phalanx[i, j] != null)
                    {
                        if (phalanx[i, j].health <= 0)
                        {
                            phalanx[i, j] = null;
                            x_velocety *= death_acceleration;
                        }
                        else
                        {
                            phalanx[i, j].Update(x_velocety, advancement);
                        }
                        
                    }

                }
            }
            
        }


        public void Draw(SpriteBatch _spriteBatch)
        {
            

            for (int i = 0; i < phalanx.GetLength(0); i++)
            {
                for (int j = 0; j < phalanx.GetLength(1); j++)
                {
                    if (phalanx[i, j] != null)
                    {
                        phalanx[i, j].Draw(_spriteBatch);
                    }
                }
            }

        }

        
    }
}
