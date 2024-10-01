using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Space_invaders_01;

using System.Runtime.CompilerServices;
//using System.Windows.Forms;

namespace Space_invaders_01
{
    public class Game1 : Game
    {
        public static Game1 Instance => instance;

        static Game1 instance;
        
        public KeybindManeger _keybindmaneger;

        private bool pause_active = false;

        public static ContentManager _content;

        private GraphicsDeviceManager _graphics;
        
        private SpriteBatch _spriteBatch;

        public static SpriteFont font_1;
        public static Texture2D pixel;

        private static RenderTarget2D screen_render;
        private static RenderTarget2D screen_render2;
        public Texture2D previous_screen_render;

        //public Enemy_type standard_Enemy_Type;

        static public Vector2 Window_size = new Vector2(1000,1000);
        //public Vector2 Game_size = new Vector2(500, 600);
        //public Vector2 Game_window_offset = new Vector2(0, 100);
        //public Rectangle Game_window;
        //public GameSpace _gamespace;


        private GameState_Controler GS_Controler;


        //public static PhalanxPresetManeger _PhalanxPresetManeger;

        //public static TypeManeger _TypeManeger;


        bool space_is_pressed = false;
        

        
        public bool is_first_frame = true;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            
            Content.RootDirectory = "Content";
            _content = Content;
            _content.RootDirectory = "Content";
            
            

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
            _keybindmaneger = new KeybindManeger();

            //_TypeManeger = new TypeManeger();
            
            GS_Controler = new GameState_Controler(_keybindmaneger);
            
            //Game_window = new Rectangle( (int)(Window_size.X*0.5f-Game_size.X*0.5+Game_window_offset.X), (int)Game_window_offset.Y, (int)Game_size.X, (int)Game_size.Y);
            

        }

        protected override void LoadContent()
        {
            font_1 = Content.Load<SpriteFont>("font1");
            pixel = Content.Load<Texture2D>("Pixel");
            
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            screen_render = new RenderTarget2D(GraphicsDevice, (int)Window_size.X, (int)Window_size.Y);
            screen_render2 = new RenderTarget2D(GraphicsDevice, (int)Window_size.X, (int)Window_size.Y);

            // TODO: use this.Content to load your game content here
        }

        

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (is_first_frame) { 
                game_intitialize();
            }

            _keybindmaneger.Run();


            GS_Controler.Update_Current_Gamespace();
            // TODO: Add your update logic here

            base.Update(gameTime);
            is_first_frame = false;
        }

        

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(screen_render);

           
            GraphicsDevice.Clear(Color.Black);

            


            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
            //_spriteBatch.Draw(pixel, Game_window, new Color(50,50,50));

            GS_Controler.Draw_Current_Gamespace(_spriteBatch);
            
            
            _spriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);

            
            _spriteBatch.Begin();
            _spriteBatch.Draw(screen_render, new Rectangle(0, 0, (int)Window_size.X, (int)Window_size.Y),Color.White);
            

            _spriteBatch.End();


           
            
            // TODO: Add your drawing code here

            base.Draw(gameTime);

            
        }
    }
}
