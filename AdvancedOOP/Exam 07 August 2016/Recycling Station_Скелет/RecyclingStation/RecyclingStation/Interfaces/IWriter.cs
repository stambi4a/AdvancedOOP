namespace RecyclingStation.Interfaces
{
    public interface IWriter
    {
        void Write(string input);

        void WriteLine(string input);

        void Write(object obj);

        void WriteLine(object obj);
    }
}
