using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Helpers
{
    public static class Logger
    {
        private static ConcurrentQueue<string> _log = new ConcurrentQueue<string>();
        public static int DelayMilliseconds { get; set; } = 0;

        public static void Log(string message)
        {
            System.Threading.Thread.Sleep(DelayMilliseconds);
            _log.Enqueue(message);
        }

        public static void Clear()
        {
            string result;
            _log.ToList().ForEach(l =>
            {
                _log.TryDequeue(out result);
            });
        }

        public static string StringDump()
        {
            return string.Join(Environment.NewLine, _log);
        }

        public static List<string> Output()
        {
            return _log.ToList();
        }
    }
}
