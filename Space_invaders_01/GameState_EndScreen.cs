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
    public class GameState_EndScreen : GameState_Foundation
    {
        public bool win_or_lose;

        public override void Update()
        {
            base.Update();
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            base.Draw(_spriteBatch);
            
            _spriteBatch.Draw(Game1.pixel,new Rectangle(new Point(0,0),Game1.Window_size.ToPoint()),new Color(100,10,0));
            
            
        }

    }
}
