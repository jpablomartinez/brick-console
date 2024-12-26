using System;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class EnemyCar
{
    public int Row { get; set; }

    public int Column { get; set; }

    public int[,] Matrix { get; set; }

    private int[] car;

    public bool Ready { get; set; }

    public EnemyCar(int row, int col, int[,] matrix)
    {
        Row = row;
        Column = col;
        Matrix = matrix;
        car = [1, 0, 1, 0, 0, 1, 0, -1, 1, 1, 1, -2, 0, 1, 0, -3];
        Ready = true;
    }


    public void Clear()
    {
        for (int i = 1; i < car.Length; i += 4)
        {
            if (car[i + 2] > 0)
            {
                int pos = car[i + 2];
                Matrix[pos - 1 + Row, Column - 1] = 0;
                Matrix[pos - 1 + Row, Column] = 0;
                Matrix[pos - 1 + Row, Column + 1] = 0;
            }
        }
        IsCarOut();
    }

    public void MoveDown()
    {
        for (int i = 1; i < car.Length; i += 4)
        {
            int pos = car[i + 2];
            if (pos >= 0 && pos < 20)
            {

                Matrix[pos + Row, Column - 1] = car[i - 1];
                Matrix[pos + Row, Column] = car[i];
                Matrix[pos + Row, Column + 1] = car[i + 1];
            }
            if (car[i + 2] < 20)
            {
                car[i + 2] = car[i + 2] + 1;
            }
        }
    }

    public void IsCarOut()
    {
        if (Ready)
        {
            if (car[3] == 20 && car[7] == 20 && car[11] == 20 && car[15] == 20)
            {
                Ready = false;
                Restart();
            }
        }
    }

    public void Restart()
    {
        car = [1, 0, 1, -1, 0, 1, 0, -2, 1, 1, 1, -3, 0, 1, 0, -4];
    }

}