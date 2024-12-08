public class Point(int x, int y)
{

    public int X { get; set; } = x;
    public int Y { get; set; } = y;

    override public string ToString()
    {
        return string.Format("{0},{1}", X, Y);
    }

}