using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace WebJob1
{
    public class Functions
    {
        public static void ProcessQueueMessage([ServiceBusTrigger("kalyazin-queue")] string message, TextWriter logger)
        {
            logger.WriteLine(message);
        }
    }
}
