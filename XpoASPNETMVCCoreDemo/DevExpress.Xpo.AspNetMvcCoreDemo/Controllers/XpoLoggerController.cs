using Microsoft.AspNetCore.Mvc;
using DevExpress.Xpo.Logger;

// This controller implements the methods necessary to enable application profiling with XPO Profiler
// If you do not plan to use the XPO profiler with this application, remove this class

namespace DevExpress.Xpo.AspNetCoreMvcDemo.Controllers
{
    public class XpoLoggerController : Controller
    {
        readonly static LoggerBase logger = new LoggerBase(50000);
        static XpoLoggerController() {
            LogManager.SetTransport(logger);
        }
        [HttpGet]
        public LogMessage[] GetCompleteLog() {
            return logger.GetCompleteLog();
        }
        [HttpGet]
        public LogMessage GetMessage() {
            return logger.GetMessage();
        }
        [HttpGet]
        public LogMessage[] GetMessages(int messagesAmount) {
            return logger.GetMessages(messagesAmount);
        }
    }
}
