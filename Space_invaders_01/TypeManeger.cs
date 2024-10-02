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
        private Vector2 standard_enemy_size;
        public Enemy_type standard_Enemy_Type;
        public Enemy_type hardy_Enemy_Type;
        public Enemy_type easy_Enemy_Type;
        public Enemy_type boss_Enemy_Type;
        public Enemy_type smol_Enemy_Type;
        
        

        public Prodectile_type standard_Prodectile_type;
        public Prodectile_type minigun_Prodectile_type;
        public Prodectile_type sniper_Prodectile_type;
        public Prodectile_type lazer_Prodectile_type;

        public Prodectile_type cheat_Prodectile_type;

        public Prodectile_type enemy_Prodectile_type;

        public Weapon standard_canon;
        public Weapon duble_canon;
        public Weapon minigun;
        public Weapon sniper;
        public Weapon lazer;



        public Vector2 standard_powerup_size;
        public float standard_powerup_speed;

        public PowerUp_Stats t1_speed_upgrade;
        //public PowerUp_Stats t2_speed_upgrade;
        public PowerUp_Stats t1_damege_upgrade;
        //public PowerUp_Stats t2_damege_upgrade;

        public PowerUp_Weapon pu_duble_canon;
        public PowerUp_Weapon pu_minigun;
        public PowerUp_Weapon pu_sniper;
        public PowerUp_Weapon pu_lazer;



        public TypeManeger()
        {
             enemy_Prodectile_type = new Prodectile_type(new Vector2(9, 40), 1, 10, 0.1f, SpriteManeger.pixel, SpriteManeger.space_oragne);

             standard_Prodectile_type = new Prodectile_type(new Vector2(10, 30), 1, 100, 0.7f, SpriteManeger.pixel, SpriteManeger.space_oragne);

             minigun_Prodectile_type = new Prodectile_type(new Vector2(7, 35), 0.5f, 10, 10, SpriteManeger.pixel, SpriteManeger.space_oragne);

             sniper_Prodectile_type = new Prodectile_type(new Vector2(15 , 65), 6, 50, 50, SpriteManeger.pixel, SpriteManeger.space_oragne);

             lazer_Prodectile_type = new Prodectile_type(new Vector2(5, 80), 0.3f, 75, 75, SpriteManeger.pixel, SpriteManeger.ailien_mint);


             cheat_Prodectile_type = new Prodectile_type(new Vector2(15, 40), 1000, 150, 0.4f, SpriteManeger.pixel, Color.Lime);

             

             standard_enemy_size = new Vector2(50, 50);
             standard_Enemy_Type = new Enemy_type(null, 0, 1, 1, 10, standard_enemy_size, SpriteManeger.space_lavender, SpriteManeger.alien_spritesheet_01, true);
             hardy_Enemy_Type = new Enemy_type(enemy_Prodectile_type, 15, 2, 1, 20, standard_enemy_size, SpriteManeger.space_lavender_dark, SpriteManeger.alien_shoot_spritesheet_01, false);
             easy_Enemy_Type = new Enemy_type(null, 0, 0.5f, 0.5f, 5, standard_enemy_size, SpriteManeger.space_lavender_light, SpriteManeger.alien_spritesheet_02,true);
             boss_Enemy_Type = new Enemy_type(enemy_Prodectile_type, 1, 10, 10, 100, new Vector2(200, 200), SpriteManeger.space_white, SpriteManeger.pixel,false);
             smol_Enemy_Type = new Enemy_type(null, 0 ,0.1f, 0.1f, 1, new Vector2(20, 20), Color.White, SpriteManeger.pixel,false);


             float[] sc_pattern = new float[] {0}; // standard canon patern
             standard_canon = new Weapon(standard_Prodectile_type, new Vector2(0,-20),  sc_pattern, 15, true);

             float[] dc_pattern = new float[] {20, -20 }; // duble canon patern
             duble_canon = new Weapon(standard_Prodectile_type, new Vector2(0, -20), dc_pattern, 10, true);


             float[] mg_pattern = new float[] {0, -14.4f , -20, -14.4f, 0, 14.4f, 20, 14.4f }; //minigun canon patern
             minigun = new Weapon(minigun_Prodectile_type, new Vector2(0, -20), mg_pattern, 5, false);

             float[] de_pattern = new float[] { 0 }; // deadeye cannon patern
             sniper = new Weapon(sniper_Prodectile_type, new Vector2(0, -20), de_pattern, 60, true);

             float[] lz_pattern = new float[] { 0 }; // lazer cannon patern
             lazer = new Weapon(lazer_Prodectile_type, new Vector2(0,20), lz_pattern, 0, true);

             standard_powerup_speed = 5;
             standard_powerup_size = new Vector2(40,40);

             pu_duble_canon = new PowerUp_Weapon(duble_canon, SpriteManeger.blank_powerup, duble_canon.bullet_type.base_color, standard_powerup_size, standard_powerup_size, standard_powerup_speed);




        }
        

    }
}
