using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using Space_invaders_01;

namespace Space_invaders_01
{
    public class PowerUp_Weapon : PowerUp_Foundation
    {
        public Weapon weapon;

        public PowerUp_Weapon(Weapon _weapon, SpriteSheet _sprite, Color _color, Vector2 _sprite_size, Vector2 _hitbox_size, float _speed) : base(_sprite, _color, _sprite_size, _hitbox_size, _speed)
        {
            weapon = _weapon;

        }

        public override void Colition_Interaction(Player _player)
        {
            base.Colition_Interaction(_player);

            _player.curent_weapon = weapon;
        }



    }
}
