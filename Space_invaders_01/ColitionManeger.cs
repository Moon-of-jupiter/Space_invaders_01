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

        public void Player_Colition(Enemy _enemy, Player _player)
        {
            if (Object_Object_Colition(_enemy,_player))
            {
                _enemy.Set_health(0);
                _player.Add_health(-1);
                _player.Stagger(60);

                Vector2 ex_point = new Vector2(_enemy.hitbox.X + _enemy.hitbox.Width * 0.5f, _enemy.hitbox.Bottom);
                reference_ExplotionManeger.Random_Explotion_FromPoint(ex_point, (int)(_enemy.size.X * 0.9f));


            }
        }


        public bool Object_Object_Colition(GameObject A, GameObject B)
        {
            if (A == null || B == null) { return false; }

            if (A.get_can_colide_with().Contains(B.get_tag()) || B.get_can_colide_with().Contains(A.get_tag()))
            {
                if (A.hitbox.Intersects(B.hitbox) && A.health > 0 && B.health > 0)
                {

                    return true;

                }
            }

            return false;
        }
        

        public void Object_Projectile_Collition(GameObject _target, Prodectile _prodectile)
        {
            
            if (Object_Object_Colition(_target,_prodectile))
            {

                _target.Add_health(-_prodectile.health);
                _prodectile.Add_health(-_target.damege);

                Vector2 ex_point = new Vector2(_prodectile.hitbox.X + _prodectile.hitbox.Width * 0.5f, _prodectile.hitbox.Y);
                reference_ExplotionManeger.Random_Explotion_FromPoint(ex_point, 40);

            }
            

        }

        public void PowerUp_Player_Colition(Player _player, PowerUp_GameObject _powerup)
        {
            if (Object_Object_Colition(_player, _powerup))
            {
                _powerup.powerup.Colition_Interaction(_player);
                _powerup.Set_health(0);
            }

        }

        private void Check_Enemy_goal(Enemy _enemy, Player _player)
        {        
            if (enemy_end_zone.Intersects(_enemy.exit_hitbox()))
            {

                _enemy.Set_health(0);
                _player.Add_health(-1);

                reference_ExplotionManeger.Random_Explotion_FromPoint(new Vector2(_enemy.position.X+Game1.Window_size.X*0.5f, Game1.Window_size.Y),400);
            }
                
            
        }


        public void Run(Player _player, Enemy[] _enemies, Prodectile[] _prodectiles, PowerUp_GameObject[] _powerups)
        {

             for (int i = 0; i < _powerups.Length; i++)
             {
                 PowerUp_Player_Colition(_player, _powerups[i]);
             }

            
             if (_enemies.Length != 0)
             {   
                for (int i = 0; i < _enemies.Length; i++)
                {
                    
                    while (_enemies[i].health > 0)
                    {
                        Player_Colition(_enemies[i], _player);

                        Check_Enemy_goal(_enemies[i], _player);


                        for (int k = 0; k < _prodectiles.Count(); k++)
                        {
                            if (_prodectiles[k].health > 0)
                            {
                                Object_Projectile_Collition(_player, _prodectiles[k]);
                                Object_Projectile_Collition(_enemies[i], _prodectiles[k]);
                            }
                        }

                        break;
                    }
                }
             }

        }

    }
}
