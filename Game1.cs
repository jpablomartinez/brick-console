using System;
using System.IO;
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

    private Texture2D GridSquare;

    private Texture2D Limit;

    private Texture2D BackgroundTexture;

    private Car car;

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
        _graphics.PreferredBackBufferWidth = 360;
        _graphics.PreferredBackBufferHeight = 420;
        _graphics.ApplyChanges();
        car = new Car(true, _gameController.Matrix);
        _gameController.StartGame(car);
        base.Initialize();
    }

    public Texture2D LoadTexture(GraphicsDevice graphicsDevice, string filePath)
    {
        using (var fileStream = File.OpenRead(filePath))
        {
            return Texture2D.FromStream(graphicsDevice, fileStream);
        }
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        square = LoadTexture(GraphicsDevice, "Content/Sprites/full.png"); //new Texture2D(GraphicsDevice, 1, 1);//Content.Load<Texture2D>("Sprites/full.png"); //new Texture2D(GraphicsDevice, 1, 1);
        BackgroundTexture = LoadTexture(GraphicsDevice, "Content/Sprites/opacity3.png");
        Limit = new Texture2D(GraphicsDevice, 1, 1);
        GridSquare = new Texture2D(GraphicsDevice, 1, 1);
        GridSquare.SetData(new[] { Color.White });
        Limit.SetData(new[] { Color.Black });

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
        _gameController.Update(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(new Color(161, 170, 148));

        _spriteBatch.Begin();

        screen.DrawAreaGame(_spriteBatch, Limit);

        _gameController.Draw(_spriteBatch, GridSquare, BackgroundTexture);

        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
