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
        public float row_space { get; private set; }
        public float collum_space { get; private set; }
        public float ad_speed { get; private set; }
        public int boarder_distance { get; private set; }
        public float horisontal_acceleration { get; private set; }

        public PhalanxPreset(Enemy_type[] _rows, int _nr_of_collums, int _centerX, float _row_space, float _collum_space, float _ad_speed, float _horisontal_acceleration, int _boarder_distance)
        {
            this.boarder_distance = _boarder_distance;
            this.rows = _rows;
            this.nr_of_collums = _nr_of_collums;
            this.centerX = _centerX;
            this.row_space = _row_space;
            this.collum_space = _collum_space;
            this.ad_speed = _ad_speed;
            this.horisontal_acceleration = _horisontal_acceleration;
        }
    }
}
