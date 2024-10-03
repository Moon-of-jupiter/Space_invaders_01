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
    public class Player_Stat_Upgrade
    {
        public float speed;
        public float damege;

        public Player_Stat_Upgrade(float _speed, float _damege)
        {
            speed = _speed;
            damege = _damege;

        }

    }
}
