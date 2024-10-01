using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Space_invaders_01;
namespace Space_invaders_01
{
    public static class SpriteManeger
    {
        public static SpriteSheet pixel;
        public static SpriteSheet stars_space01;

        public static SpriteSheet alien_spritesheet_01;
        public static SpriteSheet alien_spritesheet_02;
        public static SpriteSheet alien_shoot_spritesheet_01;


        static SpriteManeger()
        {

            ContentManager content = Game1._content;

            stars_space01 = new SpriteSheet(content, "Stars_panorama_sheet", false, false, 1, 0);
            alien_spritesheet_01 = new SpriteSheet(content, "alien_spritesheat01", true, false, 3, 50); // 32,10 // frame 1 = 1, frame 2 = 11, frame 3 = 22
            alien_spritesheet_02 = new SpriteSheet(content, "alien_spritesheet02", true, false, 4, 25); // 43,10 // frame 1 = 1, frame 2 = 11, frame 3 = 22, frame 3 = 33
            alien_shoot_spritesheet_01 = new SpriteSheet(content, "alien_sprite_sheet_shoot01", true, true, 4, 5);

            pixel = new SpriteSheet(content, "Pixel", false, false, 1, 0);
        }


    }
}
