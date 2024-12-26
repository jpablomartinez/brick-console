using System;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class GameController
{
    const int LEFT = 3;
    const int RIGHT = 6;

    public int Level { get; private set; }
    public int Score { get; private set; }

    public int MaxLevel { get; private set; }

    public int MaxScore { get; private set; }

    public Car player { get; set; }

    public EnemyCar[] Enemies;

    private int[] Waves;

    public SpriteBatch _Sprite;

    public Texture2D _Texture;

    private Random rand;

    public int[,] Matrix;

    private float CurrentTime;

    private float WaitTime;

    private int ActualCar;

    private bool IsPlaying;

    public GameController()
    {
        CurrentTime = 0;
        WaitTime = 0;
        Enemies = new EnemyCar[2];
        rand = new Random();
        Matrix = new int[20, 10];
        Waves = new int[4];
        Waves = [0, 1, 2, 3];
        int fillValue = 0;
        int current = 0;
        for (int i = 0; i < 20; i++)
        {
            if ((fillValue == 0 && current == 2) || (fillValue == 1 && current == 3))
            {
                fillValue = 1 - fillValue;
                current = 0;
            }
            Matrix[i, 0] = fillValue;
            Matrix[i, 9] = fillValue;
            current++;
        }
        int first = rand.Next(0, 4);
        int second = rand.Next(0, 4);
        Enemies[0] = new EnemyCar(0, first <= 1 ? LEFT : RIGHT, Matrix);
        Enemies[1] = new EnemyCar(0, second <= 1 ? LEFT : RIGHT, Matrix);
        Enemies[1].Ready = false;
        IsPlaying = true;
    }



    public void StartGame(Car player)
    {
        Level = 1;
        Score = 0;
        this.player = player;
    }

    public void UpdateStreet()
    {
        int firstColumnLastElement = Matrix[19, 0];
        int lastColumnLastElement = Matrix[19, 9];

        for (int row = 19; row > 0; row--)
        {
            Matrix[row, 0] = Matrix[row - 1, 0];
            Matrix[row, 9] = Matrix[row - 1, 9];
        }

        Matrix[0, 0] = firstColumnLastElement;
        Matrix[0, 9] = lastColumnLastElement;
    }

    public void Update(GameTime gameTime)
    {
        if (IsPlaying)
        {
            CurrentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            WaitTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (CurrentTime > 0.2f)
            {
                UpdateStreet();
                for (int i = 0; i < 2; i++)
                {
                    if (Enemies[i].Ready)
                    {
                        Enemies[i].Clear();
                        Enemies[i].MoveDown();
                    }
                }
                CurrentTime = 0;
            }
            if (WaitTime > 2.8f)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (!Enemies[i].Ready)
                    {
                        Enemies[i].Ready = true;
                        int first = rand.Next(0, 4);
                        Enemies[i] = new EnemyCar(0, first <= 1 ? LEFT : RIGHT, Matrix);
                    }
                }
                WaitTime = 0;
            }
        }
    }

    public void Draw(SpriteBatch _spriteBatch, Texture2D texture2D)
    {
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (Matrix[i, j] == 1)
                {
                    _spriteBatch.Draw(
                        texture2D,
                        new Rectangle(Configuration.Padding + j * Configuration.Block, Configuration.Padding + Configuration.Block * i, Configuration.Block, Configuration.Block),
                        Color.Red
                    );
                }
            }
        }

    }
}