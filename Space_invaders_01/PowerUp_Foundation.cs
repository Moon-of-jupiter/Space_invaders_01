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
    public class PowerUp_Foundation
    {
        public SpriteSheet sprite {  get; private set; }
        public Color color { get; private set; }

        public float speed { get; private set; }

        public Vector2 spritesize { get; private set; }
        public Vector2 hitboxsize { get; private set; }


        public PowerUp_Foundation(SpriteSheet _sprite, Color _color, Vector2 _sprite_size, Vector2 _hitbox_size, float _speed)
        {
            speed = _speed;
            sprite = _sprite;
            spritesize = _sprite_size;
            hitboxsize = _hitbox_size;
            color = _color;

        }

        public virtual void Colition_Interaction(Player _player)
        {

        }






    }
}
