using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1;
using Space_invaders_01;
namespace Space_invaders_01
{
    public class ColitionManeger
    {
        private ExplotionManeger reference_ExplotionManeger;
        public Rectangle enemy_end_zone { get; private set; }

        

        public ColitionManeger(ExplotionManeger _ExplotionManeger, Rectangle _enemy_End_Zone)
        {
            reference_ExplotionManeger = _ExplotionManeger;
            enemy_end_zone = _enemy_End_Zone;
        }

        public void player_colition(Enemy _enemy, Player _player)
        {
            if (_player.hitbox.Intersects(_enemy.hitbox))
            {
                _enemy.health = 0;
                _player.health--;
                _player.Stagger(60);

                Vector2 ex_point = new Vector2(_enemy.hitbox.X + _enemy.hitbox.Width * 0.5f, _enemy.hitbox.Bottom);
                reference_ExplotionManeger.Random_Explotion_FromPoint(ex_point, (int)(_enemy.size.X * 0.9f));


            }
        }



        

        public void object_projectile_collition(GameObject _target, Prodectile _prodectile)
        {
            if( _prodectile == null || _target == null) {  return; }

            if (_prodectile.can_colide_with.Contains(_target.GetType()) )
            {
                if (_target.hitbox.Intersects(_prodectile.hitbox))
                {

                    _target.health -= _prodectile.health;
                    _prodectile.health -= _target.damege;

                    Vector2 ex_point = new Vector2(_prodectile.hitbox.X + _prodectile.hitbox.Width * 0.5f, _prodectile.hitbox.Y);
                    reference_ExplotionManeger.Random_Explotion_FromPoint(ex_point, 40);

                }
            }

        }

        private void Check_Enemy_goal(Enemy _enemy, Player _player)
        {        
            if (enemy_end_zone.Intersects(_enemy.exit_hitbox()))
            {
                _enemy.health = 0;
                _player.health--;
            }
                
            
        }


        public void Run(Player _player, Enemy[] _enemies, List<Prodectile> _prodectiles)
        {
            
             if (_enemies.Length != 0)
            {   
                for (int i = 0; i < _enemies.Length; i++)
                {
                    
                    while (_enemies[i].health > 0)
                    {
                        player_colition(_enemies[i], _player);

                        Check_Enemy_goal(_enemies[i], _player);


                        for (int k = 0; k < _prodectiles.Count; k++)
                        {
                            if (_prodectiles[k].health > 0)
                            {
                                object_projectile_collition(_player, _prodectiles[k]);
                                object_projectile_collition(_enemies[i], _prodectiles[k]);
                            }
                        }

                        break;
                    }
                }
            }

        }

    }
}
