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

        
        

        public int score { get; private set; }
        

        

        
        //public EnemyManeger _EnemyManeger;

        public EnemyWaveManeger _EnemyWaveManeger;
        public ProdectileManeger _ProdectileManeger;
        public ExplotionManeger _ExplotionManeger;
        public ColitionManeger _ColitionManeger;
        

        public GameSpace(Player p)
        {
            //this._EnemyManeger = new EnemyManeger(r,s);
            PhalanxPreset[] wave_chart = new PhalanxPreset[2]{Game1._PhalanxPresetManeger.Block_Standard_Monolith, Game1._PhalanxPresetManeger.Block_Standard_Monolith };


            this._EnemyWaveManeger = new EnemyWaveManeger(wave_chart);
            this._ProdectileManeger = new ProdectileManeger();
            this._ExplotionManeger = new ExplotionManeger();

            Rectangle Enemy_End_Zone = new Rectangle(0, (int)Game1.Window_size.Y, (int)Game1.Window_size.X, (int)(Game1.Window_size.Y * 0.5f));
            this._ColitionManeger = new ColitionManeger(_ExplotionManeger, Enemy_End_Zone);
            
            this._player = p;
            
            

            

        }

        

        
        public void Update()
        {
            _player.Update();
            
            if(_player.has_shot == true)
            {
                _ProdectileManeger.Create_Player_Prodjectile(_player.pos, _player.curent_weapon);
            }

            _ProdectileManeger.Update();

            _EnemyWaveManeger.Update();


            _ExplotionManeger.Update();
            //_EnemyManeger.uppdate_enemies();

            //score = _EnemyManeger.points_earned_from_killing;
            //_EnemyManeger.enemy_advancement += _EnemyManeger.ad_speed;



            _ColitionManeger.Run(_player,_EnemyWaveManeger.Get_flat_array_of_current_wave(),_ProdectileManeger.prodectiles);
        }

        public void draw(SpriteBatch _SpriteBatch)
        {
            _ProdectileManeger.Draw(_SpriteBatch);

            //_EnemyManeger.draw_enemies(_SpriteBatch);
            
            _EnemyWaveManeger.Draw(_SpriteBatch);

            _player.draw(_SpriteBatch);
            
            _ExplotionManeger.Draw( _SpriteBatch );


        }



    }
}
