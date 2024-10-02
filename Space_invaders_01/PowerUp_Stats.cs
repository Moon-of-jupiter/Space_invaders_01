﻿using System;
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
    public class PowerUp_Stats : PowerUp_Foundation
    {
        public Player_Stat_Upgrade bonus {  get; private set; }

        public PowerUp_Stats(SpriteSheet _sprite, Color _color, Vector2 _sprite_size, Vector2 _hitbox_size, float _speed, int speed_bonus, int damege_bonus) : base(_sprite,_color,_sprite_size,_hitbox_size,_speed)
        {

        }

        public override void Colition_Interaction(Player _player)
        {
            base.Colition_Interaction(_player);

            _player.stat_bonus = bonus;
        }


    }
}
