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
    public class Enemy
    {
        public readonly Enemy_type type;
        public int HP;
        public Vector2 starting_pos;
        public Vector2 _pos;

        public Vector2 vel;
        public Texture2D texture;

        public Color color;
        public Vector2 size;

        public Enemy(Enemy_type t, Vector2 p) {

            this.texture = t.type_texture;
            this.type = t;
            this.HP = t.type_max_HP;
            this.starting_pos = p;
            this.color = t.type_color;
            this.size = t.type_size;
        }

        public void Update(float f) {
            _pos = new Vector2(starting_pos.X,starting_pos.Y+f);


        }

        public void Draw(SpriteBatch __spriteBatch) {
            Vector2 Centerd_pos = new Vector2(_pos.X + Game1.Window_size.X * 0.5f, _pos.Y);
            Vector2 offset_pos = new Vector2(Centerd_pos.X - size.X * 0.5f, Centerd_pos.Y - size.Y * 0.5f);

            Rectangle _rectangle = new Rectangle((int)offset_pos.X, (int)offset_pos.Y, (int)size.X, (int)size.Y);
            __spriteBatch.Draw(texture, _rectangle, color);
        }

    }
}
