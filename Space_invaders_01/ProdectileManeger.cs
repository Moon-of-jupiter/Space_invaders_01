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
    public class ProdectileManeger
    {
        public List<Prodectile> prodectiles = new List<Prodectile>();

        public ProdectileManeger() { }

        public void Create_Player_Prodjectile(Vector2 pos,Prodectile_type type)
        {
            prodectiles.Add(new Prodectile(type, pos+type.startoffset));
        }

        public void Destroy_Prodjectile(Prodectile marked)
        {
            for (int i = 0; i < prodectiles.Count; i++)
            {
                if(prodectiles[i] == marked)
                {
                    prodectiles.RemoveAt(i);
                    return;
                }
            }
        }

        public void Update()
        {
            for (int i = 0; i < prodectiles.Count; i++)
            {
                if (prodectiles[i].heath <= 0) { Destroy_Prodjectile(prodectiles[i]); }
               
  

            }

            for (int i = 0; i < prodectiles.Count; i++)
            {
                if (prodectiles[i].hitbox.Bottom < -10) { prodectiles[i].heath = -100; }
                prodectiles[i].Update();

                
                
            }



        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            foreach (Prodectile p in prodectiles)
            {
                p.Draw(_spriteBatch);
            }
        }

        
    }
}
