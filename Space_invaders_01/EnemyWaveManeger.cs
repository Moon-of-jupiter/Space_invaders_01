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
                waves[i] = new EnemyPhalanx(_waves[i]);
            }


        }

        public void Update()
        {
            waves[wave_counter].Update();
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            waves[wave_counter].Draw(_spriteBatch);
        }







    }
}
