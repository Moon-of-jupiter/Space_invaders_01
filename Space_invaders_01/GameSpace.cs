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
    public class GameSpace
    {
        public Player _player;

        public int Health;
        public int MaxHealth {  get; private set; }

        public int score { get; private set; }
        

        private Rectangle Enemy_End_Zone;

        
        public EnemyManeger _EnemyManeger;
        public ProdectileManeger _ProdectileManeger;
        

        public GameSpace(Player p, int r, float s, int Starting_Health)
        {
            this._EnemyManeger = new EnemyManeger(r,s);
            this._ProdectileManeger = new ProdectileManeger();
            
            this._player = p;
            this.Health = Starting_Health;
            this.MaxHealth = Starting_Health;

            Enemy_End_Zone = new Rectangle(0, (int)Game1.Window_size.Y, (int)Game1.Window_size.X, (int)(Game1.Window_size.Y * 0.5f));

        }

        public void Add_row_enemy_list(int enemy_amount, int enemy_x_spaceing,Enemy_type type)
        {
            _EnemyManeger.Add_row_enemy_list(enemy_amount,enemy_x_spaceing,type);


        }

        private int Check_Enemy_goal(List<Enemy> row)
        {
            int enemies_at_end = 0;
            if (_EnemyManeger.enemy_list.Count != 0) {
                
                List<Enemy> enemies = row;
                for (int i = 0; i < enemies.Count; i++)
                {
                    if (Enemy_End_Zone.Intersects(enemies[i].exit_hitbox()))
                    {
                        _EnemyManeger.Destroy_Enemy(enemies[i]);
                        enemies_at_end++;
                    }
                }
                
            }

            return enemies_at_end;

        }

        public void player_colition(Enemy _enemy)
        {
            if (_player.hitBox.Intersects(_enemy.hitbox))
            {
                _enemy.health = 0;
                Health--;
                _player.stagger(60);

                
            }

            
            
        }

        public void enemy_projectile_collition(Enemy _enemy, Prodectile _prodectile)
        {
            if (_enemy.hitbox.Intersects(_prodectile.hitbox))
            {
                _enemy.health -= _prodectile.heath;
                _prodectile.heath -= _enemy.type.type_damege;

                

            }

        }
        
        public void ColitionManeger()
        {
            if (_EnemyManeger.enemy_list.Count != 0)
            {
                int damege_to_player = 0;
                damege_to_player += Check_Enemy_goal(_EnemyManeger.enemy_list[0]); 
                List<List<Enemy>> enemies = _EnemyManeger.enemy_list;
                
                for (int i = 0; i < enemies.Count; i++)
                {
                    for (int j = 0; j < enemies[i].Count; j++)
                    {
                        while (enemies[i][j].health > 0)
                        {
                            player_colition(enemies[i][j]);
                            
                            for (int k = 0; k < _ProdectileManeger.prodectiles.Count; k++)
                            {
                                if (_ProdectileManeger.prodectiles[k].heath > 0)
                                {
                                    enemy_projectile_collition(enemies[i][j], _ProdectileManeger.prodectiles[k]);
                                }
                            }

                            break;
                        }
                        

                    }
                }

                
                this.Health -= damege_to_player;
            }

        }

        
        

        
        public void Update()
        {
            _player.Update();
            
            if(_player.has_shot == true)
            {
                _ProdectileManeger.Create_Player_Prodjectile(_player.pos, _player.curent_weapon);
            }

            _ProdectileManeger.Update();

            _EnemyManeger.uppdate_enemies();
            score = _EnemyManeger.enemys_destroyed;
            _EnemyManeger.enemy_advancement += _EnemyManeger.ad_speed;



            ColitionManeger();
        }

        public void draw(SpriteBatch _SpriteBatch)
        {
            _ProdectileManeger.Draw(_SpriteBatch);

            _EnemyManeger.draw_enemies(_SpriteBatch);
            
            
            _player.draw(_SpriteBatch);


        }



    }
}
