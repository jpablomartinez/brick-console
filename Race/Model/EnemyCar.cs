using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class EnemyCar
{
    public Point Head { get; private set; }
    public SpriteBatch _Sprite { get; set; }

    public Texture2D _Texture { get; set; }

    private Random rand;

    public EnemyCar(Point head, SpriteBatch sprite, Texture2D texture)
    {
        this.Head = head;
        this._Sprite = sprite;
        this._Texture = texture;
        this.rand = new Random();
    }

    public void Move(float deltaTime)
    {
        this.Head.Y += (int)(20 * (float)deltaTime * 12);
        Destroy();
    }

    public void MoveRight()
    {
        this.Head.X = 140;
    }

    public void MoveLeft()
    {
        this.Head.X = 80;
    }

    public void Update(SpriteBatch _spriteBatch, Texture2D texture2D)
    {
        if (Head == null)
        {
            throw new NullReferenceException("MISSING ENTRY POINT");
        }
        int[] body = GetBody();
        int[] leftWheels = GetLeftWheels();
        int[] rightWheels = GetRightWheels();

        for (int i = 0; i < body.Length; i += 2)
        {
            _spriteBatch.Draw(
                texture2D,
                new Rectangle(body[i], body[i + 1], Configuration.Block, Configuration.Block),
                Color.Red
            );
        }

        for (int i = 0; i < leftWheels.Length; i += 2)
        {
            _spriteBatch.Draw(
                texture2D,
                new Rectangle(leftWheels[i], leftWheels[i + 1], Configuration.Block, Configuration.Block),
                Color.Red
            );
        }

        for (int i = 0; i < rightWheels.Length; i += 2)
        {
            _spriteBatch.Draw(
                texture2D,
                new Rectangle(rightWheels[i], rightWheels[i + 1], Configuration.Block, Configuration.Block),
                Color.Red
            );
        }

    }

    private bool IsInLeftPosition()
    {
        return this.Head.X == 80;
    }

    private bool IsInRightPosition()
    {
        return this.Head.X == 140;
    }

    private bool DetectCollision()
    {
        return false;
    }

    private int[] GetBody()
    {
        return [
            Head.X, Head.Y,
            Head.X, Head.Y + Configuration.Block,
            Head.X, Head.Y + Configuration.Block * 2
        ];
    }

    private int[] GetLeftWheels()
    {
        return [
            Head.X - Configuration.Block, Head.Y + Configuration.Block,
            Head.X - Configuration.Block, Head.Y + Configuration.Block * 3,
        ];
    }

    private int[] GetRightWheels()
    {
        return [
            Head.X + Configuration.Block, Head.Y + Configuration.Block,
            Head.X + Configuration.Block, Head.Y + Configuration.Block * 3,
        ];
    }

    public void Destroy()
    {
        if (GetBody()[1] >= 600)
        {
            ResetPosition();
        }
    }

    public void ResetPosition()
    {
        int position = rand.Next(2);
        this.Head = new Point(position == 1 ? 80 : 140, 0);
    }
}