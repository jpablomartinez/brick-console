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
                new Rectangle(j + Configuration.Padding, Configuration.Padding, Configuration.Block, Configuration.LineWidth),
                Color.Black
            );
        }

        //bottom line
        for (int j = 0; j < Configuration.WidthAreaGame; j += Configuration.Block)
        {
            spriteBatch.Draw(
                texture2D,
                new Rectangle(j + Configuration.Padding, Configuration.HeightAreaGame + Configuration.Padding, Configuration.Block, Configuration.LineWidth),
                Color.Black
            );
        }

        //right line
        for (int j = 0; j < Configuration.HeightAreaGame; j += Configuration.Block)
        {
            spriteBatch.Draw(
                texture2D,
                new Rectangle(Configuration.WidthAreaGame + Configuration.Padding, j + Configuration.Padding, Configuration.LineWidth, Configuration.Block),
                Color.Black
            );
        }

        //left line
        for (int j = 0; j < Configuration.HeightAreaGame; j += Configuration.Block)
        {
            spriteBatch.Draw(
                texture2D,
                new Rectangle(Configuration.Padding, j + Configuration.Padding, Configuration.LineWidth, Configuration.Block),
                Color.Black
            );
        }

    }

    public void RenderInfo()
    {
        //TODO
    }

}