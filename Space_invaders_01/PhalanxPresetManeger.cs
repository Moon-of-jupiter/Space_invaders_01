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
    public class PhalanxPresetManeger
    {
        private float stadard_rowspacing;
        private float stadard_columnspacing;

        



        public PhalanxPreset Block_Standard_Monolith;
        public PhalanxPreset Block_Space_invaders;


        public PhalanxPresetManeger(float _RowSpacing, float _ColumSpacing)
        {
            stadard_rowspacing = _RowSpacing;
            stadard_columnspacing = _ColumSpacing;

            

            Block_Standard_Monolith = GeneratePreset_OneType(Game1._TypeManeger.standard_Enemy_Type, 10, 5);

            Enemy_type[] space_invaders = new Enemy_type[5]
            {
                Game1._TypeManeger.easy_Enemy_Type, Game1._TypeManeger.easy_Enemy_Type,
                Game1._TypeManeger.standard_Enemy_Type, Game1._TypeManeger.standard_Enemy_Type, Game1._TypeManeger.hardy_Enemy_Type
            };
            Block_Space_invaders = new PhalanxPreset(space_invaders, 10, 0, stadard_rowspacing, stadard_columnspacing, 50f, 1.05f, 30);


        }


        
        public PhalanxPreset GeneratePreset_OneType(Enemy_type type, int phalanx_countX, int phalanx_countY)
        {
            Enemy_type[] EnemyRows = new Enemy_type[phalanx_countY];

            for(int i = 0; i <  phalanx_countY; i++)
            {
                EnemyRows[i] = type;
            }


            PhalanxPreset preset = new PhalanxPreset(EnemyRows, phalanx_countX, 0, stadard_rowspacing, stadard_columnspacing, 50f, 1.05f, 30);
            return  preset;
        }
        

    }
}
