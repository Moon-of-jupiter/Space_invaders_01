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
    public class EnemyManeger
    {
        public List<List<Enemy>> enemy_list;

        public float enemy_advancement;
        public int row_spaceing;
        public float ad_speed;
        public int points_earned_from_killing;

        public EnemyManeger(int r, float s)
        {
            
            this.ad_speed = s;

            this.enemy_list = new List<List<Enemy>>();
            this.row_spaceing = r;

            points_earned_from_killing = 0;

        }

        public void Add_row_enemy_list(int enemy_amount, int enemy_x_spaceing, Enemy_type type)
        {
            int row_count = enemy_list.Count + 1;
            List<Enemy> _enemies = new List<Enemy>();
            for (int i = 0; i < enemy_amount; i++)
            {
                _enemies.Add(new Enemy(type, new Vector2((i + 0.5f) * enemy_x_spaceing - enemy_x_spaceing * enemy_amount * 0.5f, -row_count * row_spaceing)));
            }

            enemy_list.Add(_enemies);


        }

        public void Destroy_Enemy(Enemy marked)
        {
            for (int i = 0; i < enemy_list.Count; i++)
            {
                for(int j = 0; j < enemy_list[i].Count; j++)
                {
                    if(enemy_list[i][j] == marked)
                    {
                        int points = enemy_list[i][j].type.points_uppon_destruction;
                        enemy_list[i].Remove(marked);
                        if (enemy_list[i].Count == 0)
                        {
                            enemy_list.RemoveAt(i);

                            
                        }
                        points_earned_from_killing += points;
                        return;
                    }
                }
            }
        }

        public void uppdate_enemies()
        {
            for (int i = 0; i < enemy_list.Count; i++)
            {
                


                for (int j = 0; j < enemy_list[i].Count; j++)
                {
                    if (enemy_list[i][j].health <= 0)
                    {
                         Destroy_Enemy(enemy_list[i][j]);
                    }
                    if(enemy_list.Count <= i)
                    {
                        break;
                    }
                }
                
            }

            for (int i = 0; i < enemy_list.Count; i++)
            {
                for (int j = 0; j < enemy_list[i].Count; j++)
                {
                    enemy_list[i][j].Update(enemy_advancement);
                }
            }

        }

        public void draw_enemies(SpriteBatch _SpriteBatch)
        {
            for (int i = 0; i < enemy_list.Count; i++)
            {
                foreach (Enemy enemy in enemy_list[i])
                {
                    enemy.Draw(_SpriteBatch);
                }
            }


        }


    }
}
