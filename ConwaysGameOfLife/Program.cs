namespace ConwaysGameOfLife
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Editor editor = new Editor(32, 24);
            editor.StartEditor();
        }
    }
}