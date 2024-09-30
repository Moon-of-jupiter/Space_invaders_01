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
        public GameState_Foundation Next_state;
        public KeybindManeger _keybindManeger;

        public bool can_pause = false;

        public GameState_Foundation(KeybindManeger _keys) 
        { 
            _keybindManeger = _keys;
        }

        public virtual void new_gamestate(GameState_Foundation gs)
        {
            Next_state = gs;
        }

        public virtual void Update() 
        { 
            
        
        }

        

        public virtual void Draw(SpriteBatch _spriteBatch) { 
        
        }

    }
}
