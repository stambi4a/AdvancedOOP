namespace Problem_06.Mirror_Image
{
    using Problem_06.Mirror_Image.Core;
    using Problem_06.Mirror_Image.Data;

    public class MirrorImageLauncher
    {
        private static void Main(string[] args)
        {
            var repository = new Repository();
            var engine = new Engine(repository);
            engine.Run();
        }
    }
}
