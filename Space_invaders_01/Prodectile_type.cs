using System;
using System.Collections.Generic;

using System.Linq;
using System.Net;
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
        //public float motion_timer_counter;
        //public float motion_scaling;

        public Vector2 startoffset;

        //public float max_health;

        public int cooldown;
        public SpriteSheet sprite;
        
        public Color base_color;

        public Prodectile_type(Vector2 _hitbox, Vector2 _startoffset, int _cooldown, int _damege, float _speed, float _acceleration, SpriteSheet _sprite, Color _base_color)
        {
            this.startoffset = _startoffset;
            //this.max_health = projectile_health;
            this.cooldown = _cooldown;
            this.hitbox = _hitbox;
            this.damege = _damege;
            this.speed = _speed;
            this.sprite = _sprite;
            this.base_color = _base_color;
            this.acceleration = _acceleration;

            
            
           
        }
    }
}
