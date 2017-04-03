//-----------------------------------------------------------------------
// <copyright file="Logger.cs" company="InHisCompany">
//     Copyright (c) In His Company USA. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace SemanticLogging
{
    using System;
    using System.Diagnostics.Tracing;

    /// <summary>
    /// Defines messaging related events
    /// </summary>
    [EventSource(Name = "SemanticLogging-SemanticLogging-EventSource")]
    internal sealed class Logger : EventSource
    {
        /// <summary>
        /// Constant for Application Name
        /// </summary>
        private const string ApplicationName = "Example of Library Name";

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
        /// Logs that the application message processor stopped
        /// </summary>
        [NonEvent]
        public void ProcessorStart()
        {
            this.ProcessorStart(Logger.ApplicationName);
        }

        /// <summary>
        /// Logs that the application message processor started
        /// </summary>
        [NonEvent]
        public void ProcessRow(string rowIdentifier)
        {
            this.ProcessRow(rowIdentifier, Logger.ApplicationName);
        }

        /// <summary>
        /// Logs that the application configuration failed
        /// </summary>
        /// <param name="exceptionMessage">Exception message to include into the log entry</param>
        [NonEvent]
        public void ProcessRowFail(string rowIdentifier, string exceptionMessage)
        {
            this.ProcessRowFail(rowIdentifier, exceptionMessage, Logger.ApplicationName);
        }

        /// <summary>
        /// Logs that the application message processor stopped
        /// </summary>
        [NonEvent]
        public void ProcessorStop()
        {
            this.ProcessorStop(Logger.ApplicationName);
        }

        /// <summary>
        /// Logs that the application message processor stopped
        /// </summary>
        [NonEvent]
        public void ProcessorFail(string errorMessage)
        {
            this.ProcessorFail(errorMessage, Logger.ApplicationName);
        }

        /// <summary>
        /// Logs that the application configuration started
        /// </summary>
        /// <param name="applicationName">PREFILLED: Name of application</param>
        [Event(100, Message = "Configuration start for {0}", Opcode = EventOpcode.Start, Level = EventLevel.Informational)]
        private void ProcessorStart(string applicationName = Logger.ApplicationName)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(100, applicationName);
            }
        }

        /// <summary>
        /// Logs that the process of a row completed
        /// </summary>
        /// <param name="rowIdentifier">identifier for the row</param>
        /// <param name="applicationName">PREFILLED: Name of application</param>
        [Event(120, Message = "Row processed for {0}", Opcode = EventOpcode.Start, Level = EventLevel.Informational)]
        private void ProcessRow(string rowIdentifier, string applicationName = Logger.ApplicationName)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(120, rowIdentifier, applicationName);
            }
        }

        /// <summary>
        /// Logs that the processing of a row failed
        /// </summary>
        /// <param name="rowIdentifier">identifier for the row</param>
        /// <param name="exceptionMessage">Exception message to include into the log entry</param>
        /// <param name="applicationName">PREFILLED: Name of application</param>
        [Event(140, Message = "Processing row {0} failed: {1}", Opcode = EventOpcode.Suspend, Level = EventLevel.Warning)]
        private void ProcessRowFail(string rowIdentifier, string exceptionMessage, string applicationName = Logger.ApplicationName)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(140, rowIdentifier, exceptionMessage, applicationName);
            }
        }

        /// <summary>
        /// Logs that the processor stopped
        /// </summary>
        /// <param name="applicationName">PREFILLED: Name of application</param>
        [Event(160, Message = "Message processor stop for {0}", Opcode = EventOpcode.Stop, Level = EventLevel.Informational)]
        private void ProcessorStop(string applicationName = Logger.ApplicationName)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(160, applicationName);
            }
        }

        /// <summary>
        /// Logs that the processing failed
        /// </summary>
        /// <param name="exceptionMessage">Exception message to include into the log entry</param>
        /// <param name="applicationName">PREFILLED: Name of application</param>
        [Event(180, Message = "Process failed: {0}", Opcode = EventOpcode.Suspend, Level = EventLevel.Warning)]
        private void ProcessorFail(string exceptionMessage, string applicationName = Logger.ApplicationName)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(180, exceptionMessage, applicationName);
            }
        }
    }
}
