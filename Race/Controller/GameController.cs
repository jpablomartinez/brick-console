using System;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class GameController
{
    public int Level { get; private set; }
    public int Score { get; private set; }

    public int MaxLevel { get; private set; }

    public int MaxScore { get; private set; }

    private int Cars;

    public Car player { get; set; }

    public EnemyCar[] Enemies;

    public SpriteBatch _Sprite;

    public Texture2D _Texture;

    private Random rand;

    public Street LeftStreet;

    public GameController()
    {
        Enemies = new EnemyCar[3];
        rand = new Random();
        Enemies[0] = new EnemyCar(new Point(80, 0), _Sprite, _Texture);
        LeftStreet = new Street(Configuration.Block, Configuration.Padding * 2 + Configuration.Block);
    }

    public void StartGame(Car player)
    {
        Level = 1;
        Score = 0;
        this.player = player;
    }

    public void StartWave(float deltaTime)
    {
        Enemies[0].Move(deltaTime);
        LeftStreet.MoveStreet(deltaTime);
    }

    public void Update(SpriteBatch _spriteBatch, Texture2D texture2D)
    {
        Enemies[0].Update(_spriteBatch, texture2D);
        LeftStreet.Update(_spriteBatch, texture2D);
    }

    private Point[] BuildStreet(int direction)
    {
        Point[] street = new Point[3];
        int startPoint = Configuration.Padding * 2;
        street[0] = new Point(direction == 1 ? Configuration.Block : Configuration.WidthAreaGame - Configuration.Padding * 2, startPoint + Configuration.Block);
        street[1] = new Point(direction == 1 ? Configuration.Block : Configuration.WidthAreaGame - Configuration.Padding * 2, startPoint + Configuration.Block * 2);
        street[2] = new Point(direction == 1 ? Configuration.Block : Configuration.WidthAreaGame - Configuration.Padding * 2, startPoint + Configuration.Block * 3);
        return street;
    }




}