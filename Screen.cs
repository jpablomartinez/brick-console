using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Screen
{

    public void DrawAreaGame(SpriteBatch spriteBatch, Texture2D texture2D)
    {
        //top line
        for (int j = 0; j < Configuration.WidthAreaGame; j += Configuration.Block)
        {
            spriteBatch.Draw(
                texture2D,
                new Rectangle(j + Configuration.Padding - 5, Configuration.Padding - 5, Configuration.Block + 5, Configuration.LineWidth + 1),
                Color.Black
            );
        }

        //bottom line
        for (int j = 0; j < Configuration.WidthAreaGame; j += Configuration.Block)
        {
            spriteBatch.Draw(
                texture2D,
                new Rectangle(j + Configuration.Padding - 5, Configuration.HeightAreaGame + Configuration.Padding, Configuration.Block + 5, Configuration.LineWidth + 1),
                Color.Black
            );
        }

        //right line
        for (int j = 0; j < Configuration.HeightAreaGame; j += Configuration.Block)
        {
            spriteBatch.Draw(
                texture2D,
                new Rectangle(Configuration.WidthAreaGame + Configuration.Padding, j + Configuration.Padding - 5, Configuration.LineWidth + 1, Configuration.Block + 5),
                Color.Black
            );
        }

        //left line
        for (int j = 0; j < Configuration.HeightAreaGame; j += Configuration.Block)
        {
            spriteBatch.Draw(
                texture2D,
                new Rectangle(Configuration.Padding - 5, j + Configuration.Padding - 5, Configuration.LineWidth + 1, Configuration.Block + 5),
                Color.Black
            );
        }

    }

    public void RenderInfo()
    {
        //TODO
    }

}