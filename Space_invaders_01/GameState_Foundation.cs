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
    public class GameState_Foundation
    {
        public bool is_mouse_visable = true;
        public GameState_Foundation next_state {  get; private set; }
        public GameState_Foundation previous_state { get; private set; }
        public KeybindManeger _keybindManeger { get; set; }

        public bool can_pause = false;

        public GameState_Foundation(KeybindManeger _keys, GameState_Foundation _previous_state) 
        { 
            previous_state = _previous_state;
            _keybindManeger = _keys;
        }

        public virtual void New_Gamestate(GameState_Foundation gs)
        {
            
            next_state = gs;
        }

        public virtual void Update() 
        { 
            
        
        }

        

        public virtual void Draw(SpriteBatch _spriteBatch) { 
        
        }

    }
}
