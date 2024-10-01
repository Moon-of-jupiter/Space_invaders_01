﻿using System;
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



        public GameState_InGame(KeybindManeger _keys, GameState_Foundation _previous_gamestate , int _level) :base(_keys, _previous_gamestate)
        {
            can_pause = true;
            _TypeManeger = new TypeManeger();
            _PhalanxPresetManeger = new PhalanxPresetManeger(70, 70, 10, 5, 50f, 1, 1.04f,  _TypeManeger);

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
                    _PhalanxPresetManeger.GeneratePreset_OneType(_TypeManeger.easy_Enemy_Type, 1, 1, y_move, x_move,acceleration)
                },
                new PhalanxPreset[2] 
                {
                    _PhalanxPresetManeger.GeneratePreset_OneType(_TypeManeger.easy_Enemy_Type),
                    _PhalanxPresetManeger.GeneratePreset_OneType(_TypeManeger.standard_Enemy_Type),
                },
                new PhalanxPreset[2]
                {
                    _PhalanxPresetManeger.GeneratePreset_OneType(_TypeManeger.standard_Enemy_Type), _PhalanxPresetManeger.Block_Space_invaders()
                },
                new PhalanxPreset[2]
                {
                    _PhalanxPresetManeger.Block_Dificult_invaders(),
                    _PhalanxPresetManeger.GeneratePreset_OneType(_TypeManeger.hardy_Enemy_Type, 11, 3, y_move, x_move, acceleration)
                }
                
            };
        }

        public void Initiate_UI() // typ temp
        {
            HUD_element[] game_UI = new HUD_element[3];
            game_UI[0] = new HUD_element(Game1.font_1,new Vector2(10,10),Color.Wheat, "SPACE   INVADERS");

            game_UI[1] = new HUD_element(Game1.font_1, new Vector2(15, 30), new Color(230,100,100), "Health: ");
            game_UI[2] = new HUD_element(Game1.font_1, new Vector2(100, 30), Color.Gold, "Score: ");

            RTD_rectangle[] UI_backgrounds = new RTD_rectangle[1];

            UI_backgrounds[0] = new RTD_rectangle(new Color(50,50,55),Game1.pixel ,new Vector2(0,0), (int)Game1.Window_size.X, 60);


            _User_Interface = new HUD(game_UI, UI_backgrounds); // 0 = spelets namn // 1 = HP // 2 = score
        }

        public void Create_Standard_GameSpace() //Temp
        {
            Player player = new Player(new Vector2(0, Game1.Window_size.Y - 100), SpriteManeger.pixel, Color.Wheat, 3, 5, 50, 50, 10, 10, _keybindManeger);
            _GameSpace = new GameSpace(player, levels[level]);
            _GameSpace._player.curent_weapon = _TypeManeger.standard_Prodectile_type;
            
         
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


                if (_GameSpace._player.health <= 0)
                {
                    New_Gamestate(new GameState_EndScreen(_keybindManeger,this,false));
                    return;
                }

                if (_GameSpace._EnemyWaveManeger.is_cleared)
                {
                    New_Gamestate(new GameState_EndScreen(_keybindManeger, this, true));
                    return;
                }

                base.Update();
                _GameSpace.Update();

                FBF_paused = true;
            }
            



            _User_Interface.text_interface[1].Uppdate_UI_numb(_GameSpace._player.health);
            _User_Interface.text_interface[2].Uppdate_UI_numb(_GameSpace.score);
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
