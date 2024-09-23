using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_invaders_01
{
    public class PhalanxPreset
    {
        public Enemy_type[] rows {  get; private set; }
        public int nr_of_collums { get; private set; }
        public int centerX { get; private set; }
        public int row_space { get; private set; }
        public int collum_space { get; private set; }
        public int ad_speed { get; private set; }

        public PhalanxPreset(Enemy_type[] _rows, int _nr_of_collums, int _centerX, int _row_space, int _collum_space, int _ad_speed)
        {
            this.rows = _rows;
            this.nr_of_collums = _nr_of_collums;
            this.centerX = _centerX;
            this.row_space = _row_space;
            this.collum_space = _collum_space;
            this.ad_speed = _ad_speed;
        }
    }
}
