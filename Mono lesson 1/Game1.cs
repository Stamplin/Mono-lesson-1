using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Mono_lesson_1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //add all the images
        Texture2D kingBlueTexture, kingRedTexture, theTitleTexture, goblinBarrelTexture;

        //background
        Texture2D theBackgroudTexture, theBackgroudTexture2, theBackgroudTexture3;

        

        //random number generator
        Random random = new Random();

        //random backgroud picker
        int pickedBackground;

        //goblin
        int goblinLocation;
        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 680;
            _graphics.ApplyChanges();
            //goblin location
            goblinLocation = random.Next(0, 1200);
            //picked background
            pickedBackground = random.Next(3);

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
                
            kingBlueTexture = Content.Load<Texture2D>("Blue");
            kingRedTexture = Content.Load<Texture2D>("Red");
            theTitleTexture = Content.Load<Texture2D>("Title");
            goblinBarrelTexture = Content.Load<Texture2D>("Goblin");

            //background
            theBackgroudTexture = Content.Load<Texture2D>("background");
            theBackgroudTexture2 = Content.Load<Texture2D>("bg2");
            theBackgroudTexture3 = Content.Load<Texture2D>("bg3");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            
            //background changes based on random number
            if (pickedBackground == 0)
            {
                _spriteBatch.Draw(theBackgroudTexture, new Vector2(0, 0), Color.White);
            }
            if (pickedBackground == 1) 
            {
                _spriteBatch.Draw(theBackgroudTexture2, new Vector2(0, 10), Color.White);
            }
            if (pickedBackground == 2)
            {
                _spriteBatch.Draw(theBackgroudTexture3, new Vector2(0, 0), Color.White);
            }




            //title in the bottom center of the screen
            _spriteBatch.Draw(theTitleTexture, new Vector2(190, 100), Color.White);
            
            //the kings on their sides
            _spriteBatch.Draw(kingBlueTexture, new Vector2(0, 430), Color.White);
            _spriteBatch.Draw(kingRedTexture, new Vector2(800, 200), Color.White);

            //golbin
            _spriteBatch.Draw(goblinBarrelTexture, new Vector2(goblinLocation, 0), Color.White);

            //end
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
