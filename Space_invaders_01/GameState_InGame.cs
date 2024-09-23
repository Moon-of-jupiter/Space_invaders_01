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

            Initiate_UI();

        }

        public void Initiate_UI() // typ temp
        {
            UI_element[] game_UI = new UI_element[3];
            game_UI[0] = new UI_element(Game1.font_1,new Vector2(10,10),Color.Wheat, "SPACE   INVADERS");

            game_UI[1] = new UI_element(Game1.font_1, new Vector2(15, 30), new Color(230,100,100), "Health: ");
            game_UI[2] = new UI_element(Game1.font_1, new Vector2(100, 30), Color.Gold, "Score: ");

            RTD_rectangle[] UI_backgrounds = new RTD_rectangle[1];

            UI_backgrounds[0] = new RTD_rectangle(new Color(50,50,55),Game1.pixel ,new Vector2(0,0), (int)Game1.Window_size.X, 60);


            _User_Interface = new User_Interface(game_UI, UI_backgrounds); // 0 = spelets namn // 1 = HP // 2 = score
        }

        public void Create_Standard_GameSpace() //Temp
        {
            
            _GameSpace = new GameSpace(new Player(new Vector2(0, Game1.Window_size.Y - 100), Game1.pixel, Color.Wheat,5, 100, 100,10,10), 70, 0.5f, 3);
            _GameSpace._player.curent_weapon = Game1._TypeManeger.standard_Prodectile_type;
            
            /*
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
            */
        }

        public override void Update()
        {
            if (_GameSpace.Health <= 0)
            {
                new_gamestate(new GameState_EndScreen());
                return;
            }
            base.Update();
            _GameSpace.Update();

            _User_Interface.text_interface[1].Uppdate_UI_numb(_GameSpace.Health);
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
