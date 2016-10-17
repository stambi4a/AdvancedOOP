namespace ReflectionExercises.Commands
{
    using ReflectionExercises.Interfaces;
    public abstract class Command : ICommand
    {

        public abstract void Execute();
    }
}
