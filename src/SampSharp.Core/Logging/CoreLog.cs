﻿// SampSharp
// Copyright 2017 Tim Potze
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace SampSharp.Core.Logging
{
    /// <summary>
    ///     Contains simply utility methods used by SampSharp for logging.
    /// </summary>
    public static class CoreLog
    {
        /// <summary>
        ///     Initializes the <see cref="CoreLog" /> class.
        /// </summary>
        static CoreLog()
        {
            Stream = Console.OpenStandardOutput();
            LogLevel = CoreLogLevel.Info;
        }

        /// <summary>
        ///     Gets or sets the minimum log level.
        /// </summary>
        internal static CoreLogLevel LogLevel { get; set; }

        /// <summary>
        ///     Gets or sets the output stream.
        /// </summary>
        internal static Stream Stream { get; set; }

        private static string GetLevelName(CoreLogLevel level)
        {
            return level.ToString().ToUpper();
        }

        /// <summary>
        ///     Gets a value indicating whether the specified log level is logged
        /// </summary>
        /// <param name="level">The level.</param>
        /// <returns>Whether the specified log level is logged.</returns>
        [DebuggerHidden]
        public static bool DoesLog(CoreLogLevel level)
        {
            return LogLevel >= level || level == CoreLogLevel.Initialisation;
        }
        /// <summary>
        ///     Logs the specified message at the specified log level.
        /// </summary>
        /// <param name="level">The level.</param>
        /// <param name="message">The message.</param>
        [DebuggerHidden]
        public static void Log(CoreLogLevel level, string message)
        {
            if (Stream != null && (LogLevel >= level || level == CoreLogLevel.Initialisation))
            {
                using (var sw = new StreamWriter(Stream, Encoding.ASCII, 1024, true))
                {

                    sw.WriteLine(level == CoreLogLevel.Initialisation ? message : $"[SampSharp:{GetLevelName(level)}] {message}");
                }
            }
        }
    }
}