using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Space_invaders_01;

namespace Space_invaders_01
{
    public class SpriteSheet
    {
        // en klass som håller en textur + information till animation
        
        public Texture2D texture;
        public bool is_animated;
        public bool is_triggerd;
        public int frames_per_step;
        public int steps;
        public int offset;

        public SpriteSheet(ContentManager _content, string _texture_name, bool _is_animated, bool _is_triggerd, int _steps, int _frames_per_step, int _offset)
        {
            offset = _offset;
            texture = _content.Load<Texture2D>(_texture_name);
            is_animated = _is_animated;
            frames_per_step = _frames_per_step;
            steps = _steps;
            is_triggerd = _is_triggerd;

        }


    }
}
