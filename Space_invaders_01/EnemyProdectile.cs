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
    public class EnemyProdectile : Prodectile
    {
        
        public EnemyProdectile(Prodectile_type _type, Vector2 _staringPos) : base(_type, _staringPos)
        {
            
            
            type = _type;

            this.health = _type.damege;

            this.pos = _staringPos;
            this.hitbox = new Rectangle((int)(pos.X - type.hitbox.X * 0.5f), (int)(pos.Y - type.hitbox.Y * 0.5f), (int)type.hitbox.X, (int)type.hitbox.Y);
            speed = 0;
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            base.Draw(_spriteBatch);
        }


    }
}
