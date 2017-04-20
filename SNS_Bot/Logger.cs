
using NLog;

public class Logger
{
    static private NLog.Logger _logger = LogManager.GetCurrentClassLogger();

    public static void NLogInfo(string message)
    {
        _logger.Info(message);
    }

    public static void NLogFatal(string message)
    {
        _logger.Fatal(message);
    }


}
