using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1;
using Space_invaders_01;


namespace Space_invaders_01
{
    public class Prodectile_type
    {
        public Vector2 hitbox;
        public int damege;
        public float speed;
        public float acceleration;

        public Vector2 startoffset;

        //public float max_health;

        public int cooldown;

        public Texture2D texture;
        public Color base_color;

        public Prodectile_type(Vector2 projectile_hitbox, Vector2 projectile_startoffset, float projectile_health, int projectile_cooldown, int projectile_damege, float projectile_speed, float projectile_acceleration, Texture2D projectile_texture, Color projectile_base_color)
        {
            this.startoffset = projectile_startoffset;
            //this.max_health = projectile_health;
            this.cooldown = projectile_cooldown;
            this.hitbox = projectile_hitbox;
            this.damege = projectile_damege;
            this.speed = projectile_speed;
            this.texture = projectile_texture;
            this.base_color = projectile_base_color;
            this.acceleration = projectile_acceleration;

            
           
        }
    }
}
