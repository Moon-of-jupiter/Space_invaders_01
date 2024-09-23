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
    public class TypeManeger
    {
        private Vector2 standard_enemy_size;
        public Enemy_type standard_Enemy_Type;
        public Enemy_type hardy_Enemy_Type;
        public Enemy_type easy_Enemy_Type;
        public Enemy_type boss_Enemy_Type;
        public Enemy_type smol_Enemy_Type;


        public Prodectile_type standard_Prodectile_type = new Prodectile_type(new Vector2(15, 40), new Vector2(0, -20), 1, 15, 1, 100, 0.4f, Game1.pixel, Color.Lime);

        public TypeManeger()
        {
             standard_enemy_size = new Vector2(50, 50);
             standard_Enemy_Type = new Enemy_type(1, 1, 10, standard_enemy_size, Color.Aqua, Game1.pixel);
             hardy_Enemy_Type = new Enemy_type(2, 1, 20, standard_enemy_size, Color.DarkCyan, Game1.pixel);
             easy_Enemy_Type = new Enemy_type(0.5f, 0.5f, 5, standard_enemy_size, Color.LightBlue, Game1.pixel);
             boss_Enemy_Type = new Enemy_type(10, 10, 100, new Vector2(200, 200), Color.DarkOrchid, Game1.pixel);
             smol_Enemy_Type = new Enemy_type(0.1f, 0.1f, 1, new Vector2(20, 20), Color.White, Game1.pixel);
        }
        

    }
}
