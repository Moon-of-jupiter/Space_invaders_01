using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Space_invaders_01;


namespace Space_invaders_01
{
    public class EnemyPhalanx
    {
        
        
        private Enemy[,] phalanx;

        public int center_pointX {  get; private set; }
        public int collum_spaceing {  get; private set; }
        
        public int row_spaceing { get; private set; }

        public EnemyPhalanx(Enemy_type[] rows, int nr_of_collums, int centerX, int row_space, int collum_space)
        {
            collum_spaceing = collum_space;
            row_spaceing = row_space;



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
    }
}
