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

    private Car car;
    private Car leftCar;

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
        _graphics.PreferredBackBufferWidth = 420;
        _graphics.PreferredBackBufferHeight = 600;
        _graphics.ApplyChanges();
        car = new Car(new Point(80, 500));
        leftCar = new Car(new Point(80, 300));
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
        KeyboardState state = Keyboard.GetState();
        if (state.IsKeyDown(Keys.Left))
        {
            car.moveLeft();
        }
        if (state.IsKeyDown(Keys.Right))
        {
            car.moveRight();
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(new Color(161, 170, 148));
        // TODO: Add your drawing code here
        _spriteBatch.Begin();

        for (int j = 1; j < 22; j++)
        {
            _spriteBatch.Draw(
                square,
                new Rectangle(j * 10, 10, 20, 2),
                Color.Red
            );
        }

        for (int j = 1; j < 22; j++)
        {
            _spriteBatch.Draw(
                square,
                new Rectangle(j * 10, 590, 20, 2),
                Color.Red
            );
        }

        for (int j = 0; j < 50; j += 10)
        {
            _spriteBatch.Draw(
                square,
                new Rectangle(230, j * 10 + 10, 2, 100),
                Color.Red
            );
        }

        _spriteBatch.Draw(
            square,
            new Rectangle(10, 500, 2, 92),
            Color.Red
        );

        for (int j = 0; j < 50; j += 10)
        {
            _spriteBatch.Draw(
                square,
                new Rectangle(10, j * 10 + 10, 2, 100),
                Color.Red
            );
        }

        _spriteBatch.Draw(
            square,
            new Rectangle(230, 500, 2, 92),
            Color.Red
        );

        for (int i = 0; i < 60; i += 20)
        {
            _spriteBatch.Draw(
                square,
                new Rectangle(200, 500 + i, 20, 20),
                Color.Red
            );
        }

        for (int i = 0; i < 60; i += 20)
        {

            _spriteBatch.Draw(
                square,
                new Rectangle(20, 300 + i, 20, 20),
                Color.Red
            );
        }

        car.draw(_spriteBatch, square);
        leftCar.draw(_spriteBatch, square);

        _spriteBatch.End();



        base.Draw(gameTime);
    }
}
