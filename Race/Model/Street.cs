using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Street
{

    const int StreetLength = 3;

    public Point Head { get; set; }

    public Street(int x, int y)
    {
        Head = new Point(x, y);
    }

    public void MoveStreet(float deltaTime)
    {
        Head.Y += (int)(20 * (float)deltaTime * 12); ;
        ResetPosition();
    }

    private void ResetPosition()
    {
        if (Head.Y >= 600)
        {
            this.Head.Y = 20;
        }
    }

    public void Update(SpriteBatch spriteBatch, Texture2D texture2D)
    {
        for (int i = 1; i <= StreetLength; i++)
        {
            spriteBatch.Draw(
                texture2D,
                new Rectangle(Head.X, Head.Y, Configuration.Block, Configuration.Block * i),
                Color.Red
            );
        }

    }

}