﻿using System;
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
    public class Enemy_type
    {
        public float max_HP;
        public float damege;
        public Prodectile_type prodectile;
        public int points_uppon_destruction;
        public Vector2 size;
        public Color color;
        public Texture2D texture;
        

        public Enemy_type(Prodectile_type _prodectile,  float _max_HP, float _damege, int _points, Vector2 _size, Color _color, Texture2D _texture)
        {
            max_HP = _max_HP;
            damege = _damege;
            prodectile = _prodectile;
            points_uppon_destruction = _points;
            size = _size;
            color = _color;
            texture = _texture;


        }



    }
}
