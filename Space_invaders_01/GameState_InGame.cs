using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Space_invaders_01;

namespace Space_invaders_01
{
    public class GameState_InGame : GameState_Foundation
    {
        public GameSpace _GameSpace;
        public HUD _User_Interface;
        public PhalanxPresetManeger _PhalanxPresetManeger;
        public TypeManeger _TypeManeger;

        public PhalanxPreset[][] levels;

        private int level;

        

        public bool FBF = false; // frame by frame for debugging
        private bool FBF_paused;
        private bool FBF_has_pressed;
        private int FBF_counter = 0;

        public bool gameover = false;


        public GameState_InGame(KeybindManeger _keys, GameState_Foundation _previous_gamestate , int _level) :base(_keys, _previous_gamestate)
        {
            can_pause = true;
            _TypeManeger = new TypeManeger();
            _PhalanxPresetManeger = new PhalanxPresetManeger(70, 70, 10, 5, 50f, 1, 1.05f,  _TypeManeger);

            Initiate_Levels();
            

            level = 0;
            if (_level <= levels.Count())
           {
                level = _level;
                New_Gamestate(previous_state);
           }

           
            Create_Standard_GameSpace();

            Initiate_UI();



        }

        private void Initiate_Levels()
        {
            float x_move = _PhalanxPresetManeger.standard_horizontal_move;
            float y_move = _PhalanxPresetManeger.standard_vertical_adv;

            
            float acceleration = _PhalanxPresetManeger.standard_death_acceleration;
            levels = new PhalanxPreset[4][]
            {
                new PhalanxPreset[1] // debug level
                {
                    _PhalanxPresetManeger.GeneratePreset_OneType(_TypeManeger.easy_Enemy_Type, 1, 1, y_move, x_move,acceleration, _PhalanxPresetManeger.all_powerups, _PhalanxPresetManeger.all_powerups.Length)
                },
                new PhalanxPreset[2] 
                {
                    _PhalanxPresetManeger.GeneratePreset_OneType(_TypeManeger.easy_Enemy_Type, _PhalanxPresetManeger.all_powerups, _PhalanxPresetManeger.all_powerups.Length),
                    _PhalanxPresetManeger.GeneratePreset_OneType(_TypeManeger.standard_Enemy_Type, _PhalanxPresetManeger.all_powerups, 1),
                },
                new PhalanxPreset[2]
                {
                    _PhalanxPresetManeger.GeneratePreset_OneType(_TypeManeger.standard_Enemy_Type, _PhalanxPresetManeger.all_powerups, 2), 
                    _PhalanxPresetManeger.Block_Space_invaders(_PhalanxPresetManeger.all_powerups, 1)
                },
                new PhalanxPreset[2]
                {
                    _PhalanxPresetManeger.Block_Dificult_invaders(_PhalanxPresetManeger.all_powerups, 2),
                    _PhalanxPresetManeger.GeneratePreset_OneType(_TypeManeger.hardy_Enemy_Type, 11, 3, y_move, x_move, acceleration,_PhalanxPresetManeger.all_powerups, 1)
                }
                
            };
        }

        public void Initiate_UI()
        {
            HUD_element[] game_UI = new HUD_element[]
            {
                new HUD_element(Game1.font_1,new Vector2(10,10), SpriteManeger.space_lavender_light, "SPACE   INVADERS"),
                new HUD_element(Game1.font_1, new Vector2(15, 30), SpriteManeger.ailien_mint, "Health: "),
                new HUD_element(Game1.font_1, new Vector2(90, 30), SpriteManeger.ailien_mint, "Wave: "),
                new HUD_element(Game1.font_1, new Vector2(160, 30), SpriteManeger.ailien_mint, "Score: ")
            };
            

            RTD_rectangle[] UI_backgrounds = new RTD_rectangle[]
            {
                new RTD_rectangle(SpriteManeger.space_purple,Game1.pixel ,new Vector2(0,0), (int)Game1.Window_size.X, 60)
            };  

            


            _User_Interface = new HUD(game_UI, UI_backgrounds); // 0 = spelets namn // 1 = HP // 2 = score
        }

        public void Create_Standard_GameSpace()
        {
            Player player = new Player(new Vector2(0, Game1.Window_size.Y - 100), SpriteManeger.ship_texture_01, SpriteManeger.space_white, _TypeManeger.standard_canon, 3, 5, 50, 50, 47, 47, false, _keybindManeger);
            _GameSpace = new GameSpace(player, levels[level]);

            //_GameSpace._PowerUpManeger.Spawn_PowerUp(_TypeManeger.pu_minigun, new Vector2(0, 0));
         
        }

        public override void Update()
        {
            
                
            if (FBF_has_pressed == false && Keyboard.GetState().IsKeyDown(_keybindManeger.frame_by_frame))
            {
                FBF_paused = false;
                FBF_has_pressed = true;
                FBF = true;

                

            }
            else if (Keyboard.GetState().IsKeyDown(_keybindManeger.frame_by_frame) == false)
            {
                FBF_has_pressed = false;
                FBF_counter = 0;
            }
            else 
            {
                FBF_counter++;
            }
            



                

            

            if (FBF == false || FBF_paused == false || FBF_counter >= 30)
            {


                if (_GameSpace._player.health <= 0 && gameover == false)
                {
                    New_Gamestate(new GameState_EndScreen(_keybindManeger,this,false));
                    gameover = true;
                    
                    return;

                }

                if (_GameSpace._EnemyWaveManeger.is_cleared && gameover == false)
                {
                    New_Gamestate(new GameState_EndScreen(_keybindManeger, this, true));
                    gameover = true;
                    
                    return;
                }

                if (_GameSpace._EnemyWaveManeger.waves[_GameSpace._EnemyWaveManeger.wave_counter] != null)
                {
                    _GameSpace._EnemyWaveManeger.waves[_GameSpace._EnemyWaveManeger.wave_counter].game_over = gameover;
                }

                base.Update();
                
                _GameSpace.Update();

                is_mouse_visable = _GameSpace._player.mouse_controls == false;

                FBF_paused = true;
            }
            



            _User_Interface.text_interface[1].Uppdate_UI_numb(_GameSpace._player.health);
            _User_Interface.text_interface[2].Uppdate_UI_numb(_GameSpace._EnemyWaveManeger.wave_counter+1);
            _User_Interface.text_interface[3].Uppdate_UI_numb(_GameSpace.score);
            //add ui uppdate

        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            base.Draw(_spriteBatch);
            _GameSpace.draw(_spriteBatch);

            _User_Interface.Draw(_spriteBatch);
        }

    }
}
