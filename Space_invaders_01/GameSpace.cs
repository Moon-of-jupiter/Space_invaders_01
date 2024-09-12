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
        
        public Texture2D Far_Background;

        
        public EnemyManeger _EnemyManeger;
        

        public GameSpace(Player p, Texture2D tex, int r, float s)
        {
            _EnemyManeger = new EnemyManeger(r,s);
            this.Far_Background = tex;
            this._player = p;
            

        }

        public void Add_row_enemy_list(int enemy_amount, int enemy_x_spaceing,Enemy_type type)
        {
            _EnemyManeger.Add_row_enemy_list(enemy_amount,enemy_x_spaceing,type);


        }

        
        public void update(GameTime gameTime)
        {
            _player.run(gameTime);
            _EnemyManeger.uppdate_enemies();
            _EnemyManeger.enemy_advancement += _EnemyManeger.ad_speed;
        }

        public void draw(SpriteBatch _SpriteBatch)
        {

            for (int i = 0; i < _EnemyManeger.enemy_list.Count; i++) { 
                foreach(Enemy enemy in _EnemyManeger.enemy_list[i])
                {
                    enemy.Draw(_SpriteBatch);
                }
            }
            
            
            _player.draw(_SpriteBatch);


        }



    }
}
