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
    public class EnemyWaveManeger
    {
        private EnemyPhalanx[] waves;

        private int wave_counter = 0;

        public EnemyWaveManeger(PhalanxPreset[] _waves)
        {
            waves = new EnemyPhalanx[_waves.Length + 1];

            for (int i = 0; i < _waves.Length; i++)
            {
                waves[i] = new EnemyPhalanx(_waves[i], 300);
            }

        }

        private int Total_nr_waves()
        {
            return waves.Length - 1; 
        }


        
        public Enemy[] Get_flat_array_of_current_wave()
        {
            if (wave_counter < Total_nr_waves())
            {
                return waves[wave_counter].Get_flat_array_of_enemys();
            }
            return new Enemy[0];
        }


        public void Update()
        {
            if (wave_counter < Total_nr_waves()) 
            { 
                
                waves[wave_counter].Update();

                if (waves[wave_counter].Count() <= 0)
                {
                    wave_counter++;
                }

            }
            
            

            
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            if (waves[wave_counter] != null)
            {
                waves[wave_counter].Draw(_spriteBatch);
            }
        }


        




    }
}
