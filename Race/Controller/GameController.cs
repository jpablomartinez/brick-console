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

    public GameController()
    {
        Enemies = new EnemyCar[3];
        rand = new Random();
        Enemies[0] = new EnemyCar(new Point(80, 0), _Sprite, _Texture);
    }

    public void DrawStreet(SpriteBatch spriteBatch, Texture2D texture2D)
    {
        //draw left street
        int startPoint = Configuration.Padding * 2;
        for (int i = 0; i < 5; i++)
        {

            for (int j = 0; j < 3; j++)
            {
                spriteBatch.Draw(
                    texture2D,
                    new Rectangle(Configuration.Block, startPoint + Configuration.Block * j, Configuration.Block, Configuration.Block),
                    Color.Red
                );
            }
            startPoint += Configuration.Block * 6;
        }

        //draw right street
        startPoint = Configuration.Padding * 2;
        for (int i = 0; i < 5; i++)
        {

            for (int j = 0; j < 3; j++)
            {
                spriteBatch.Draw(
                    texture2D,
                    new Rectangle(Configuration.WidthAreaGame - Configuration.Padding * 2, startPoint + Configuration.Block * j, Configuration.Block, Configuration.Block),
                    Color.Red
                );
            }
            startPoint += Configuration.Block * 6;
        }

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
        /*for (int i = 0; i < Enemies.Length; i++)
        {
            
        }*/
    }

    public void Update(SpriteBatch _spriteBatch, Texture2D texture2D)
    {
        Enemies[0].Update(_spriteBatch, texture2D);
        /*for (int i = 0; i < Enemies.Length; i++)
        {
            Enemies[i].Update(_spriteBatch, texture2D);
        }*/
    }


}