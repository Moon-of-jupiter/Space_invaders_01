﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
//using System.Windows.Forms;

namespace Space_invaders_01
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public Texture2D pixel;

        public Vector2 Window_size = new Vector2(800,1000);
        //public Vector2 Game_size = new Vector2(500, 600);
        //public Vector2 Game_window_offset = new Vector2(0, 100);
        //public Rectangle Game_window;

        public Player P_one;
        public bool is_first_frame = true;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferHeight = (int)Window_size.Y;
            _graphics.PreferredBackBufferWidth = (int)Window_size.X;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        private void game_intitialize()
        {
            
            //Game_window = new Rectangle( (int)(Window_size.X*0.5f-Game_size.X*0.5+Game_window_offset.X), (int)Game_window_offset.Y, (int)Game_size.X, (int)Game_size.Y);
            P_one = new Player(new Vector2(100,500),pixel,Color.Wheat,10,10,100,100);
        }

        protected override void LoadContent()
        {
            pixel = Content.Load<Texture2D>("Pixel");
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (is_first_frame) { 
                game_intitialize();
            }

            P_one.run(gameTime);
            // TODO: Add your update logic here

            base.Update(gameTime);
            is_first_frame = false;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();
            //_spriteBatch.Draw(pixel, Game_window, new Color(50,50,50));

            P_one.draw(_spriteBatch);
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
