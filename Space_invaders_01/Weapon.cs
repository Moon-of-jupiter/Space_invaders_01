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
    public class Weapon
    {
        // general variables
        public Prodectile_type bullet_type { get; private set; }

        public float damege_bonus { get; set; } // for the damege bonus power up

        public float[] shoting_pattern { get; private set; }
        public Vector2 origin_point { get; private set; }

        public int cooldown {  get; private set; }
        public bool stagger_on_cooldown { get; private set; }

        //instance specific variables

        public int weapon_pattern_stage = 0;

        public Weapon(Prodectile_type _bullets, Vector2 _origin_point, float[] _shoting_pattern, int _cooldown, bool _stagger)
        {
            damege_bonus = 0;
            bullet_type = _bullets;
            shoting_pattern = _shoting_pattern;
            cooldown = _cooldown;
            stagger_on_cooldown = _stagger;
            origin_point = _origin_point;
        }
        





    }
}
