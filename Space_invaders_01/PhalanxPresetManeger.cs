﻿using System;
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
        private TypeManeger typeManeger;

        private float stadard_rowspacing;
        private float stadard_columnspacing;

        public int border_distance = 30;
        public float standard_vertical_adv;
        public float standard_horizontal_move;

        public float standard_death_acceleration;

        public int colum_count;
        public int row_count;

        public PowerUp_Foundation[] all_powerups;
        public PowerUp_Foundation[] all_weapon_powerups;
        public PowerUp_Foundation[] all_stat_powerups;








        public PhalanxPresetManeger(float _row_spacing, float _colum_spacing, int _colum_count, int _row_count,float _vertical_advancement, float _horizontal_movement, float _death_acceleration,  TypeManeger _typeManeger)
        {
            all_weapon_powerups = new PowerUp_Foundation[] 
            {
                _typeManeger.pu_duble_canon,_typeManeger.pu_lazer,
                _typeManeger.pu_minigun, _typeManeger.pu_sniper,
                _typeManeger.pu_sonic

            };

            all_stat_powerups = new PowerUp_Foundation[]
            {
                _typeManeger.t1_damege_upgrade, _typeManeger.t1_speed_upgrade, _typeManeger.t1_heal
            };

            all_powerups = new PowerUp_Foundation[]
            {
               _typeManeger.pu_duble_canon,_typeManeger.pu_lazer,
               _typeManeger.pu_minigun, _typeManeger.pu_sniper,
               _typeManeger.pu_sonic,

               _typeManeger.t1_damege_upgrade, _typeManeger.t1_speed_upgrade, _typeManeger.t1_heal

            };



            stadard_rowspacing = _row_spacing;
            stadard_columnspacing = _colum_spacing;

            standard_horizontal_move = _horizontal_movement;
            standard_vertical_adv = _vertical_advancement;

            standard_death_acceleration = _death_acceleration;


            row_count = _row_count;
            colum_count = _colum_count;

            typeManeger = _typeManeger;
            

            //Block_Standard_Monolith = GeneratePreset_OneType(typeManeger.standard_Enemy_Type, colum_count, row_count);

            
            //Block_Space_invaders = new PhalanxPreset(space_invaders, 10, 0, stadard_rowspacing, stadard_columnspacing, 50f, 1.05f, 30);


        }

        public PhalanxPreset Block_Space_invaders(float _vertical_advancement, float _horizontal_movement, float _acceleration, PowerUp_Foundation[] _powerups, int _nr_of_powerups)
        {
            Enemy_type[] space_invaders = new Enemy_type[5]
            {
                typeManeger.easy_Enemy_Type, typeManeger.easy_Enemy_Type,
                typeManeger.standard_Enemy_Type, typeManeger.standard_Enemy_Type, typeManeger.hardy_Enemy_Type
            };
            return new PhalanxPreset(space_invaders, 10, _powerups, _nr_of_powerups, stadard_rowspacing, stadard_columnspacing, _vertical_advancement, _horizontal_movement, _acceleration, border_distance);
        }

        public PhalanxPreset Block_Space_invaders(PowerUp_Foundation[] _powerups, int _nr_of_powerups)
        {
            return Block_Dificult_invaders(standard_vertical_adv, standard_horizontal_move, standard_death_acceleration, _powerups, _nr_of_powerups);
        }

        public PhalanxPreset Block_Dificult_invaders(float _vertical_advancement, float _horizontal_movement, float _acceleration, PowerUp_Foundation[] _powerups, int _nr_of_powerups)
        {
            Enemy_type[] space_invaders = new Enemy_type[6]
            {
                typeManeger.easy_Enemy_Type,typeManeger.easy_Enemy_Type,
                typeManeger.standard_Enemy_Type, typeManeger.standard_Enemy_Type, 
                typeManeger.hardy_Enemy_Type, typeManeger.hardy_Enemy_Type
            };
            return new PhalanxPreset(space_invaders, 10, _powerups, _nr_of_powerups, stadard_rowspacing, stadard_columnspacing, _vertical_advancement, _horizontal_movement, _acceleration, border_distance);
        }

        public PhalanxPreset Block_Dificult_invaders(PowerUp_Foundation[] _powerups, int _nr_of_powerups)
        {
            return Block_Dificult_invaders(standard_vertical_adv, standard_horizontal_move, standard_death_acceleration, _powerups, _nr_of_powerups);
        }






        public PhalanxPreset GeneratePreset_OneType(Enemy_type _type, int _phalanx_countX, int _phalanx_countY, float _vertical_advancement,float _horizontal_movement, float _death_acceleration, PowerUp_Foundation[] _powerups, int _nr_of_powerups)
        {
            Enemy_type[] EnemyRows = new Enemy_type[_phalanx_countY];

            for(int i = 0; i <  _phalanx_countY; i++)
            {
                EnemyRows[i] = _type;
            }


            PhalanxPreset preset = new PhalanxPreset(EnemyRows, _phalanx_countX, _powerups, _nr_of_powerups, stadard_rowspacing, stadard_columnspacing, _vertical_advancement, _horizontal_movement, _death_acceleration, border_distance);
            return  preset;
        }

        public PhalanxPreset GeneratePreset_OneType(Enemy_type _type, PowerUp_Foundation[] _powerups, int _nr_of_powerups)
        {
            return GeneratePreset_OneType(_type, colum_count, row_count, standard_vertical_adv, standard_horizontal_move, standard_death_acceleration, _powerups, _nr_of_powerups);
        }
        

    }
}
