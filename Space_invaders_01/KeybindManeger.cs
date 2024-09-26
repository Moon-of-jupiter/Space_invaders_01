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
    public class KeybindManeger
    {
        public Keys player_move_left;
        public Keys player_move_right;
        public Keys player_shoot;

        public Keys frame_by_frame;
        public KeybindManeger()
        {
            player_move_left = Keys.A;
            player_move_right = Keys.D;
            player_shoot = Keys.Space;

            frame_by_frame = Keys.O;
        }


    }
}
