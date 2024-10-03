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
    public class PowerUp_Heal : PowerUp_Foundation
    {
        public int health;

        public PowerUp_Heal(int _health, SpriteSheet _sprite, Color _color, Vector2 _sprite_size, Vector2 _hitbox_size, float _speed) : base(_sprite, _color, _sprite_size, _hitbox_size, _speed)
        {
            health = _health;
            
        }

        public override void Colition_Interaction(Player _player)
        {
            base.Colition_Interaction(_player);

            _player.Add_health(health);
        }

    }
}
