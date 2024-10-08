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
    public class EnemyProdectile : Prodectile
    {
        
        public EnemyProdectile(Prodectile_type _type, Vector2 _staringPos) : base(_type, _staringPos,0)
        {
            
            tag = colition_tags.prodectile;
            can_colide_with = new colition_tags[1] { colition_tags.player};
            
            type = _type;

            this.health = _type.damege;

            this.position = _staringPos;
            this.hitbox = new Rectangle((int)(position.X - type.hitbox.X * 0.5f), (int)(position.Y - type.hitbox.Y * 0.5f), (int)type.hitbox.X, (int)type.hitbox.Y);
            speed = 0;

            Vector2 Centerd_pos = new Vector2(position.X + Game1.Window_size.X * 0.5f, position.Y);

            hitbox = GlobalMethods.Centralized_Rectangle(Centerd_pos, type.hitbox);

        }

        public override void Update()
        {
            if (speed < type.speed)
            {
                speed += type.acceleration;
            }
            vel = new Vector2(0, -speed);

            position = new Vector2(position.X - vel.X, position.Y - vel.Y);


            Vector2 Centerd_pos = new Vector2(position.X + Game1.Window_size.X * 0.5f, position.Y);

            hitbox = GlobalMethods.Centralized_Rectangle(Centerd_pos, type.hitbox);
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            base.Draw(_spriteBatch);
        }


    }
}
