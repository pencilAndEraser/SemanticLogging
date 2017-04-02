//-----------------------------------------------------------------------
// <copyright file="Logger.cs" company="InHisCompany">
//     Copyright (c) In His Company USA. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace DemoConsole
{
    using System;
    using System.Diagnostics.Tracing;

    /// <summary>
    /// Defines messaging related events
    /// </summary>
    [EventSource(Name = "SemanticLogging-DemoConsole-EventSource")]
    internal sealed class Logger : EventSource
    {
        /// <summary>
        /// Constant for Application Name
        /// </summary>
        private const string ApplicationName = "Example of Console Application Name";

        /// <summary>
        /// holds a static instance this Logger, initialized via lazy-load
        /// </summary>
        private static Lazy<Logger> log = new Lazy<Logger>(() => new Logger());

        /// <summary>
        /// Prevents a default instance of the <see cref="Logger"/> class from being created.
        /// </summary>
        private Logger() : base()
        {
        }

        /// <summary>
        /// Gets the static instance of the Logger
        /// </summary>
        public static Logger Log
        {
            get
            {
                return log.Value;
            }
        }

        /// <summary>
        /// Logs that the application started
        /// </summary>
        [NonEvent]
        public void ApplicationStart()
        {
            this.ApplicationStart(Logger.ApplicationName);
        }

        /// <summary>
        /// Logs that the application stopped
        /// </summary>
        [NonEvent]
        public void ApplicationStop()
        {
            this.ApplicationStop(Logger.ApplicationName);
        }

        /// <summary>
        /// Logs that the application started
        /// </summary>
        /// <param name="applicationName">PREFILLED: Name of application</param>
        [Event(100, Message = "{0} start", Opcode = EventOpcode.Start, Level = EventLevel.Informational)]
        private void ApplicationStart(string applicationName = Logger.ApplicationName)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(100, applicationName);
            }
        }

        /// <summary>
        /// Logs that the application stopped
        /// </summary>
        /// <param name="applicationName">PREFILLED: Name of application</param>
        [Event(120, Message = "{0} stop", Opcode = EventOpcode.Stop, Level = EventLevel.Informational)]
        private void ApplicationStop(string applicationName = Logger.ApplicationName)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(120, applicationName);
            }
        }
    }
}
