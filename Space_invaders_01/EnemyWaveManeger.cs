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

        public int wave_counter = 0;

        public EnemyWaveManeger(PhalanxPreset[] _waves)
        {
            waves = new EnemyPhalanx[_waves.Length];

            for (int i = 0; i < waves.Length; i++)
            {
                waves[i] = new EnemyPhalanx(_waves[i], 300);
            }


        }

        
        public Enemy[] Get_flat_array_of_current_wave()
        {
            return waves[wave_counter].Get_flat_array_of_enemys();
        }


        public void Update()
        {
            if (waves[wave_counter].Count() <= 0)
            {
                wave_counter++;
            }

            if (wave_counter < waves.Length)
            {
                waves[wave_counter].Update();
            }
            
            

            
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            waves[wave_counter].Draw(_spriteBatch);
        }


        




    }
}
