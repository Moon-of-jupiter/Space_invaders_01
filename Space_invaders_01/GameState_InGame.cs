using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        public User_Interface _User_Interface;
        

        public GameState_InGame()
        {
            Create_Standard_GameSpace();
            

        }

        public void Create_Standard_GameSpace() //Temp
        {
            
            _GameSpace = new GameSpace(new Player(new Vector2(0, Game1.Window_size.Y - 100), Game1.pixel, Color.Wheat,5, 100, 100,10,10), 70, 0.5f, 10);
            _GameSpace._player.curent_weapon = Game1._TypeManeger.standard_Prodectile_type;
            

            _GameSpace.Add_row_enemy_list(10, 70, Game1._TypeManeger.standard_Enemy_Type);
            _GameSpace.Add_row_enemy_list(10, 80, Game1._TypeManeger.hardy_Enemy_Type);
            _GameSpace.Add_row_enemy_list(10, 70, Game1._TypeManeger.standard_Enemy_Type);
            _GameSpace.Add_row_enemy_list(10, 70, Game1._TypeManeger.standard_Enemy_Type);

            _GameSpace.Add_row_enemy_list(11, 70, Game1._TypeManeger.easy_Enemy_Type);
            _GameSpace.Add_row_enemy_list(11, 70, Game1._TypeManeger.easy_Enemy_Type);
            _GameSpace.Add_row_enemy_list(11, 70, Game1._TypeManeger.easy_Enemy_Type);
            _GameSpace.Add_row_enemy_list(11, 70, Game1._TypeManeger.standard_Enemy_Type);
            _GameSpace.Add_row_enemy_list(10, 80, Game1._TypeManeger.hardy_Enemy_Type);

            _GameSpace.Add_row_enemy_list(0, 80, Game1._TypeManeger.standard_Enemy_Type);
            _GameSpace.Add_row_enemy_list(3, 80, Game1._TypeManeger.standard_Enemy_Type);
            _GameSpace.Add_row_enemy_list(0, 80, Game1._TypeManeger.standard_Enemy_Type);
            _GameSpace.Add_row_enemy_list(0, 80, Game1._TypeManeger.standard_Enemy_Type);
            _GameSpace.Add_row_enemy_list(0, 80, Game1._TypeManeger.standard_Enemy_Type);
            _GameSpace.Add_row_enemy_list(0, 80, Game1._TypeManeger.standard_Enemy_Type);

            _GameSpace.Add_row_enemy_list(1, 80, Game1._TypeManeger.boss_Enemy_Type);
        }

        public override void Update()
        {
            base.Update();
            _GameSpace.Update();
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            base.Draw(_spriteBatch);
            _GameSpace.draw(_spriteBatch);
        }

    }
}
