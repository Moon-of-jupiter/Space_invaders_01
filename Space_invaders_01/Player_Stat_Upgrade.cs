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
        public int speed;
        public int damege;

        public Player_Stat_Upgrade(int _speed, int _damege)
        {
            speed = _speed;
            damege = _damege;

        }

    }
}
