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

        public void Create_Enemy_Prodectile(Vector2 pos, Prodectile_type type)
        {
            prodectiles.Add(new EnemyProdectile(type, pos - type.startoffset));
        }

        public void Handle_Enemy_Shooting(Enemy[] enemies)
        {
            foreach(Enemy enemy in enemies)
            {
                if(enemy != null)
                {
                    if(enemy.type.prodectile != null && enemy.has_shot)
                    {
                        Create_Enemy_Prodectile(enemy.position, enemy.type.prodectile);
                    }
                }
            }
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
                if (prodectiles[i].health <= 0) 
                { 
                    Destroy_Prodjectile(prodectiles[i]); 
                }
               
  
                   
            }

            for (int i = 0; i < prodectiles.Count; i++)
            {
                if (prodectiles[i].hitbox.Bottom < -10 || prodectiles[i].hitbox.Top > Game1.Window_size.Y + 10) { prodectiles[i].health = -100; }
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
