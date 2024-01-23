using System.Xml.Linq;

namespace WebApplication1.Services
{
    public class LoggerService : ILogger
    {
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return (IDisposable)state;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel == LogLevel.Error
                    || logLevel == LogLevel.Critical;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            //Ecrire dans un fichier de log ou un TSDB en fonction de l'environnement bien sûr.
            Console.WriteLine(state.ToString());
        }
    }
}
