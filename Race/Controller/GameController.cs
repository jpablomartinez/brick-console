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

    public async void StartWave()
    {
        for (int i = 0; i < 10 * Level; i++)
        {

            await Task.Delay(1000);
        }
    }




}