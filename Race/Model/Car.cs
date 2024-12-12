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

    public void Destroy() { }

    public void Draw(SpriteBatch _spriteBatch, Texture2D texture2D)
    {
        if (Head == null)
        {
            throw new NullReferenceException("MISSING ENTRY POINT");
        }
        //body
        _spriteBatch.Draw(
            texture2D,
            new Rectangle(Head.X, Head.Y, 20, 20),
            Color.Red
        );
        _spriteBatch.Draw(
            texture2D,
            new Rectangle(Head.X, Head.Y + 20, 20, 20),
            Color.Red
        );
        _spriteBatch.Draw(
            texture2D,
            new Rectangle(Head.X, Head.Y + 40, 20, 20),
            Color.Red
        );

        //wheels
        _spriteBatch.Draw(
            texture2D,
            new Rectangle(Head.X - 20, Head.Y + 20, 20, 20),
            Color.Red
        );
        _spriteBatch.Draw(
            texture2D,
            new Rectangle(Head.X - 20, Head.Y + 60, 20, 20),
            Color.Red
        );
        _spriteBatch.Draw(
            texture2D,
            new Rectangle(Head.X + 20, Head.Y + 20, 20, 20),
            Color.Blue
        );
        _spriteBatch.Draw(
            texture2D,
            new Rectangle(Head.X + 20, Head.Y + 60, 20, 20),
            Color.Blue
        );
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

}