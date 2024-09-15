using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Space_invaders_01;
//using System.Windows.Forms;

namespace Space_invaders_01
{
    public class Game1 : Game
    {
        public static Game1 Instance => instance;

        static Game1 instance;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public static Texture2D pixel;

        //public Enemy_type standard_Enemy_Type;

        static public Vector2 Window_size = new Vector2(800,1000);
        //public Vector2 Game_size = new Vector2(500, 600);
        //public Vector2 Game_window_offset = new Vector2(0, 100);
        //public Rectangle Game_window;
        //public GameSpace _gamespace;


        private GameState_Maneger GS_Maneger;

        public static TypeManeger _TypeManeger;


        bool space_is_pressed = false;
        

        
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
            _TypeManeger = new TypeManeger();
            GS_Maneger = new GameState_Maneger();
            
            //Game_window = new Rectangle( (int)(Window_size.X*0.5f-Game_size.X*0.5+Game_window_offset.X), (int)Game_window_offset.Y, (int)Game_size.X, (int)Game_size.Y);
            

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

            
                

            GS_Maneger.Update_Current_Gamespace();
            // TODO: Add your update logic here

            base.Update(gameTime);
            is_first_frame = false;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();
            //_spriteBatch.Draw(pixel, Game_window, new Color(50,50,50));

            GS_Maneger.Draw_Current_Gamespace(_spriteBatch);
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
