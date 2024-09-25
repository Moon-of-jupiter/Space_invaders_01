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
        float stadard_rowspacing;
        float stadard_columnspacing;

        public PhalanxPreset Block_Standard_Monolith;
        public PhalanxPreset Block_Space_invaders;


        public PhalanxPresetManeger(float _RowSpacing, float _ColumSpacing)
        {
            stadard_rowspacing = _RowSpacing;
            stadard_columnspacing = _ColumSpacing;

            Block_Standard_Monolith = GeneratePreset_OneType(Game1._TypeManeger.standard_Enemy_Type, 10, 5);




        }


        
        public PhalanxPreset GeneratePreset_OneType(Enemy_type type, int phalanx_countX, int phalanx_countY)
        {
            Enemy_type[] EnemyRows = new Enemy_type[phalanx_countY];

            for(int i = 0; i <  phalanx_countY; i++)
            {
                EnemyRows[i] = type;
            }


            PhalanxPreset preset = new PhalanxPreset(EnemyRows, phalanx_countX, 0, stadard_rowspacing, stadard_columnspacing, 1);
            return  preset;
        }
        

    }
}
