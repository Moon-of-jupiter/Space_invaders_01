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

        public PowerUp_Foundation[] powerups { get; private set; }
        public int nr_of_powerups { get; private set; }
        public float starting_horisontal_speed { get; private set; }
        public int nr_of_collums { get; private set; }
        
        public float row_space { get; private set; }
        public float collum_space { get; private set; }
        public float ad_speed { get; private set; }
        public int boarder_distance { get; private set; }
        public float horisontal_acceleration { get; private set; }

        public PhalanxPreset(Enemy_type[] _rows, int _nr_of_collums, PowerUp_Foundation[] _powerups, int _nr_of_powerups, float _row_space, float _collum_space, float _y_speed, float _x_speed, float _horisontal_acceleration, int _boarder_distance)
        {
            boarder_distance = _boarder_distance;
            rows = _rows;
            nr_of_collums = _nr_of_collums;

            powerups = _powerups;
            nr_of_powerups = _nr_of_powerups;

            row_space = _row_space;
            collum_space = _collum_space;
            ad_speed = _y_speed;
            starting_horisontal_speed = _x_speed;
            horisontal_acceleration = _horisontal_acceleration;
        }
    }
}
