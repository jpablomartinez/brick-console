using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Car
{
    public Point head { get; private set; }

    public Car(Point head)
    {
        this.head = head;
    }

    public void moveRight()
    {
        if (isInLeftPosition())
        {
            this.head.X = 140;
        }

    }

    public void moveLeft()
    {
        if (isInRightPosition())
        {
            this.head.X = 80;
        }
    }

    public void destroy() { }

    public void draw(SpriteBatch _spriteBatch, Texture2D texture2D)
    {
        if (head == null)
        {
            throw new NullReferenceException("MISSING ENTRY POINT");
        }
        //body
        _spriteBatch.Draw(
            texture2D,
            new Rectangle(head.X, head.Y, 20, 20),
            Color.Red
        );
        _spriteBatch.Draw(
            texture2D,
            new Rectangle(head.X, head.Y + 20, 20, 20),
            Color.Red
        );
        _spriteBatch.Draw(
            texture2D,
            new Rectangle(head.X, head.Y + 40, 20, 20),
            Color.Red
        );

        //wheels
        _spriteBatch.Draw(
            texture2D,
            new Rectangle(head.X - 20, head.Y + 20, 20, 20),
            Color.Red
        );
        _spriteBatch.Draw(
            texture2D,
            new Rectangle(head.X - 20, head.Y + 60, 20, 20),
            Color.Red
        );
        _spriteBatch.Draw(
            texture2D,
            new Rectangle(head.X + 20, head.Y + 20, 20, 20),
            Color.Blue
        );
        _spriteBatch.Draw(
            texture2D,
            new Rectangle(head.X + 20, head.Y + 60, 20, 20),
            Color.Blue
        );
    }

    private bool isInLeftPosition()
    {
        return this.head.X == 80;
    }

    private bool isInRightPosition()
    {
        return this.head.X == 140;
    }

}