using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace brick_console;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    int Width;
    int Height;

    private Texture2D square;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        Height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        Width = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here  
        _graphics.PreferredBackBufferWidth = 400;
        _graphics.PreferredBackBufferHeight = 700;
        _graphics.ApplyChanges();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        square = new Texture2D(GraphicsDevice, 1, 1);
        square.SetData(new[] { Color.Black });

        // TODO: use this.Content to load your game content here
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
        GraphicsDevice.Clear(new Color(161, 170, 148));
        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        for (int i = 0; i < 4; i++)
        {
            _spriteBatch.Draw(
                square,
                new Rectangle(100 * i, 100, 100, 100),
                Color.Red);
        }

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
