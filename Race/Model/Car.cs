using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Car
{
    public Point Head { get; private set; }

    public Car(Point head)
    {
        this.Head = head;
    }

    public void MoveRight()
    {
        if (IsInLeftPosition())
        {
            this.Head.X = 140;
        }

    }

    public void MoveLeft()
    {
        if (IsInRightPosition())
        {
            this.Head.X = 80;
        }
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
        throw new NotImplementedException();
    }
}