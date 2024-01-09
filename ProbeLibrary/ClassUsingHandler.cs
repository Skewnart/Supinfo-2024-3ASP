namespace ProbeLibraryJ2PMp2
{
    public delegate int ReturningIntHandler();

    public class ClassUsingHandler
    {
        public event ReturningIntHandler IntHandler;

        public int callHandler() { return IntHandler(); }
    }
}