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
    public class GameSpace
    {
        public Player _player;
        public List<List<Enemy>> enemy_list;
        
        public float enemy_advancement;
        public Texture2D Far_Background;

        public int row_spaceing;

        

        public GameSpace(Player p, Texture2D tex, int r)
        {
            this.Far_Background = tex;
            this._player = p;
            
            this.enemy_list = new List<List<Enemy>>();
            this.row_spaceing = r;

        }

        public void Add_row_enemy_list(int enemy_amount, int enemy_x_spaceing,Enemy_type type)
        {
            int row_count = enemy_list.Count + 1;
            List<Enemy> _enemies = new List<Enemy>();
            for (int i = 0; i < enemy_amount; i++) {
                _enemies.Add(new Enemy(type,new Vector2((i+0.5f)*enemy_x_spaceing-enemy_x_spaceing*enemy_amount*0.5f,-row_count*row_spaceing)));
            }

            enemy_list.Add(_enemies);


        }

        public void uppdate_enemies()
        {
            for (int i = 0; i < enemy_list.Count; i++)
            {
                for (int j = 0; j < enemy_list[i].Count; j++)
                {
                    enemy_list[i][j].Update(enemy_advancement);
                }
            }

        }

        public void update(GameTime gameTime)
        {
            _player.run(gameTime);
            uppdate_enemies();
            enemy_advancement++;
        }

        public void draw(SpriteBatch _SpriteBatch)
        {

            for (int i = 0; i < enemy_list.Count; i++) { 
                foreach(Enemy enemy in enemy_list[i])
                {
                    enemy.Draw(_SpriteBatch);
                }
            }
            
            
            _player.draw(_SpriteBatch);


        }



    }
}
