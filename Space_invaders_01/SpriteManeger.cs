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

        public static SpriteSheet stars_spritesheet_01;
        public static SpriteSheet stars_spritesheet_02;


        public static Color space_white;
        public static Color space_oragne;
        public static Color space_black;
        public static Color space_purple;
        public static Color space_teal;


        static SpriteManeger()
        {

            ContentManager content = Game1._content;

            stars_space01 = new SpriteSheet(content, "Stars_panorama_sheet", false, false, 1, 0,0);
            alien_spritesheet_01 = new SpriteSheet(content, "alien_spritesheat01", true, false, 3, 50,0); // 32,10 // frame 1 = 1, frame 2 = 11, frame 3 = 22
            alien_spritesheet_02 = new SpriteSheet(content, "alien_spritesheet02", true, false, 4, 25,0); // 43,10 // frame 1 = 1, frame 2 = 11, frame 3 = 22, frame 3 = 33
            alien_shoot_spritesheet_01 = new SpriteSheet(content, "alien_sprite_sheet_shoot01", true, true, 4, 5,0);

            stars_spritesheet_01 = new SpriteSheet(content, "stars_sprite_sheet01", true, false, 5, 25, 10);
            stars_spritesheet_02 = new SpriteSheet(content, "stars_sprite_sheet02", true, false, 5, 15, 25);

            pixel = new SpriteSheet(content, "Pixel", false, false, 1, 0,0);



            space_white = new Color(238, 226, 222);
            space_black = new Color(3, 6, 55);
            space_oragne = new Color(244, 80, 80);
            space_purple = new Color(64, 18, 139);
            space_teal = new Color(52, 128, 151);
        }


    }
}
