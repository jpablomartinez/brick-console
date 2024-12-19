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

    private Screen screen;

    private GameController _gameController;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        Height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        Width = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        screen = new Screen();
        _gameController = new GameController();
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here  
        _graphics.PreferredBackBufferWidth = 420;
        _graphics.PreferredBackBufferHeight = 600;
        _graphics.ApplyChanges();
        //leftCar = new Car(new Point(80, 300));
        car = new Car(true, _gameController.Matrix);
        _gameController.StartGame(car);
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

        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

        // TODO: Add your update logic here
        KeyboardState state = Keyboard.GetState();
        if (state.IsKeyDown(Keys.Left))
        {
            car.MoveLeft();
        }
        if (state.IsKeyDown(Keys.Right))
        {
            car.MoveRight();
        }
        _gameController.StartWave(deltaTime);
        _gameController.Update(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(new Color(161, 170, 148));
        // TODO: Add your drawing code here
        _spriteBatch.Begin();

        screen.DrawAreaGame(_spriteBatch, square);

        //car.Update(_spriteBatch, square);
        _gameController.Draw(_spriteBatch, square);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
