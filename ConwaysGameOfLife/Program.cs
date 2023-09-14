namespace ConwaysGameOfLife
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(32, 24);
            board.Run();
        }
    }
}