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
    public class PowerUp_GameObject : GameObject
    {
        public PowerUp_Foundation powerup {  get; private set; }
        public PowerUp_GameObject(PowerUp_Foundation _type, Vector2 _position) : base(GameObject.colition_tags.powerup, _type.sprite, _type.spritesize, _type.hitboxsize, _type.color)
        {
            position = _position;
            can_colide_with = new colition_tags[] { colition_tags.player};
            health = 1;
            powerup = _type;
        }

        public override void Update()
        {
            position = new Vector2(position.X, position.Y + powerup.speed);

            base.Update();

        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            base.Draw(_spriteBatch);
        }



    }
}
