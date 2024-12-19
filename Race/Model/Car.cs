using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Car
{
    public bool IsInLeftPosition { get; set; }

    public int[,] Matrix { get; set; }

    public Car(bool left, int[,] matrix)
    {
        this.IsInLeftPosition = left;
        this.Matrix = matrix;
        ChangePosition(0, 1);
    }

    public void ChangePosition(int factor, int value)
    {
        this.Matrix[16, 3 + factor] = value;
        this.Matrix[17, 3 + factor] = value;
        this.Matrix[18, 3 + factor] = value;
        this.Matrix[17, 2 + factor] = value;
        this.Matrix[17, 4 + factor] = value;
        this.Matrix[19, 2 + factor] = value;
        this.Matrix[19, 4 + factor] = value;
    }

    public void MoveRight()
    {
        if (IsInLeftPosition)
        {
            this.IsInLeftPosition = false;
            ChangePosition(0, 0);
            ChangePosition(3, 1);
        }
    }

    public void MoveLeft()
    {
        if (!IsInLeftPosition)
        {
            this.IsInLeftPosition = true;
            ChangePosition(3, 0);
            ChangePosition(0, 1);
        }
    }

}