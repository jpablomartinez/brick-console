using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Screen
{

    public void DrawAreaGame(SpriteBatch spriteBatch, Texture2D texture2D)
    {
        //top line
        spriteBatch.Draw(
            texture2D,
            new Rectangle(Configuration.Padding - 5, Configuration.Padding - 5, Configuration.WidthAreaGame + 5, Configuration.LineWidth + 1),
            Color.Black
        );

        //bottom line
        spriteBatch.Draw(
            texture2D,
            new Rectangle(Configuration.Padding - 2, Configuration.HeightAreaGame + Configuration.Padding, Configuration.WidthAreaGame + 5, Configuration.LineWidth + 1),
            Color.Black
        );

        //right line
        spriteBatch.Draw(
            texture2D,
            new Rectangle(Configuration.WidthAreaGame + Configuration.Padding, Configuration.Padding - 5, Configuration.LineWidth + 1, Configuration.HeightAreaGame + 5),
            Color.Black
        );

        //left line
        spriteBatch.Draw(
            texture2D,
            new Rectangle(Configuration.Padding - 5, Configuration.Padding - 2, Configuration.LineWidth + 1, Configuration.HeightAreaGame + 5),
            Color.Black
        );
    }

    public void RenderInfo()
    {
        //TODO
    }

}