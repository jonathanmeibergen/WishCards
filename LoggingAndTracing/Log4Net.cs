using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WishCards.LoggingAndTracing
{
    public class Log4Net
    {
        static protected ILog Log = LogManager.GetLogger("TASK");

        public static void logging()
        {
            FileInfo fi = new FileInfo("log4net.xml");
            log4net.Config.XmlConfigurator.Configure(fi);
            log4net.GlobalContext.Properties["host"] = Environment.MachineName;
         
        }
    }
}
