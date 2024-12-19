using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class EnemyCar
{
    public int Row { get; set; }

    public int Column { get; set; }

    public int[,] Matrix { get; set; }

    public EnemyCar(int row, int[,] matrix)
    {
        this.Row = row;
        this.Column = 3;
        this.Matrix = matrix;
        StartPosition();
    }

    public void StartPosition()
    {
        this.Matrix[Row, Column + 1] = 1;
        this.Matrix[Row, Column - 1] = 1;
    }

    public void Clear()
    {
        this.Matrix[Row, Column] = 0;
        this.Matrix[Row + 1, Column] = 0;
        this.Matrix[Row + 2, Column] = 0;
        this.Matrix[Row + 1, Column] = 0;
        this.Matrix[Row + 1, Column] = 0;
        this.Matrix[Row + 2, Column] = 0;
        this.Matrix[Row + 2, Column] = 0;
    }

    public void MoveDown(int factor, int value)
    {
        int r = Row;
        int c = Column;
        Clear();
        this.Matrix[r, c] = value;
        this.Matrix[r + 1, c] = value;
        this.Matrix[r + 2, c] = value;
        this.Matrix[r + 1, c] = value;
        this.Matrix[r + 1, c] = value;
        this.Matrix[r + 2, c] = value;
        this.Matrix[r + 2, c] = value;
        Row = r;
        Column = c;
    }
}