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
    public class KeybindManeger
    {
        public Keys player_move_left;
        public Keys player_move_right;
        public Keys player_shoot;

        public Keys Pause;

        public Keys frame_by_frame;

        public bool mouse_left_button {  get; private set; }
        public bool mouse_right_button {  get; private set; }

        private bool mouse_left_has_pressed_once = false;
        private bool mouse_right_has_pressed_once = false;

        private bool _pause;
        private bool paused_once = false;
        

        public KeybindManeger()
        {
            player_move_left = Keys.A;
            player_move_right = Keys.D;
            player_shoot = Keys.Space;

            Pause = Keys.Tab;

            frame_by_frame = Keys.O;

            Run();
        }

        public bool Pause_key_pressed()
        {
            bool pressed = _pause;
            if (paused_once)
            {
                _pause = false;
            }
            

            return pressed;
        }



        public void Run()
        {
            _pause = false;
            if (Keyboard.GetState().IsKeyDown(Pause))
            {
                
                if (paused_once == false)
                {
                    paused_once = true;
                    _pause = true;
                }
            }
            else
            {
                paused_once = false;
            }


            mouse_left_button = false;
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                
                if(mouse_left_has_pressed_once == false)
                {
                    mouse_left_has_pressed_once = true;
                    mouse_left_button = true;
                }
            }
            else
            {
                mouse_left_has_pressed_once = false;
            }

            mouse_right_button = false;
            if (Mouse.GetState().RightButton == ButtonState.Pressed)
            {
                
                if (mouse_right_has_pressed_once == false)
                {
                    mouse_right_has_pressed_once = true;
                    mouse_right_button = true;
                }
            }
            else
            {
                mouse_right_has_pressed_once = false;
            }


        }

    }
}
