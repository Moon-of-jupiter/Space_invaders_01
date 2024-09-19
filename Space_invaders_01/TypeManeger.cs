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
    public class TypeManeger
    {
        public Enemy_type standard_Enemy_Type = new Enemy_type(1,1, 10, new Vector2(60, 60), Color.Aqua, Game1.pixel);
        public Enemy_type hardy_Enemy_Type = new Enemy_type(2, 1, 20, new Vector2(70, 70), Color.DarkCyan, Game1.pixel);
        public Enemy_type easy_Enemy_Type = new Enemy_type(0.5f, 0.5f, 5, new Vector2(60, 60), Color.LightBlue, Game1.pixel);
        public Enemy_type boss_Enemy_Type = new Enemy_type(10, 10, 100, new Vector2(200, 200), Color.DarkOrchid, Game1.pixel);
        public Enemy_type smol_Enemy_Type = new Enemy_type(0.1f, 0.1f, 1, new Vector2(20, 20), Color.White, Game1.pixel);


        public Prodectile_type standard_Prodectile_type = new Prodectile_type(new Vector2(15,40),new Vector2(0,-20), 1,15,1,100,0.4f,Game1.pixel,Color.Lime);

    }
}
