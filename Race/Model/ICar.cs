using Microsoft.Xna.Framework.Graphics;

abstract class ICar
{
    public abstract void Update(SpriteBatch _spriteBatch, Texture2D texture2D);
    public abstract void Destroy();

    public abstract void GetBody();

    public abstract void GetWheels();

}