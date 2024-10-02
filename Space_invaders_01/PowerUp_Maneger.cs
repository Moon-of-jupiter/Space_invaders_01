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
    public class PowerUp_Maneger
    {
        public List<PowerUp_GameObject> powerups;
        public PowerUp_Maneger()
        {
            powerups = new List<PowerUp_GameObject>();

        }

        public void Spawn_PowerUp(PowerUp_Foundation _powerup_type, Vector2 _position)
        {
            powerups.Add(new PowerUp_GameObject(_powerup_type, _position));
        }

        public void Update()
        {
            for (int i = 0; i < powerups.Count; i++)
            {
                powerups[i].Update();
            }

            for (int i = 0; i < powerups.Count(); i++)
            {
                if(powerups[i].health <= 0)
                {
                    powerups.RemoveAt(i);
                    i--;
                }
                
            }

        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            for(int i = 0; i < powerups.Count; i++)
            {
                powerups[i].Draw(_spriteBatch);
            }
        }
    }
}
