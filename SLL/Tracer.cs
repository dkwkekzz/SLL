using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace SLL
{
    internal class TextTraceListner : TraceListener
    {
        private DateTime createLogDateTime;
        private string logFilePath;
        private string prefixFileName;
        private string extension;
        DefaultTraceListener defaultListener;
        private int keepArchivedLogDays = 14;

        public TextTraceListner(string logFilePath, string prefixFileName = "Event", string extension = "txt")
        {
            this.logFilePath = logFilePath;
            this.prefixFileName = prefixFileName;
            this.extension = extension;

            DirectoryInfo directoryInfo = new DirectoryInfo(this.logFilePath);
            if (directoryInfo.Exists == false)
            {
                try
                {
                    Directory.CreateDirectory(directoryInfo.FullName);
                }
                catch (Exception exception)
                {
                    Trace.Assert(false, exception.Message);
                }
            }

            {
                FileInfo[] files = directoryInfo.GetFiles($"*.{this.extension}", SearchOption.AllDirectories);

                foreach (FileInfo file in files)
                {
                    DateTime deleteDateTime = file.CreationTime.AddDays(this.keepArchivedLogDays);
                    if (deleteDateTime > DateTime.Now)
                    {
                        continue;
                    }
                    file.Attributes = FileAttributes.Normal;
                    file.Delete();
                }
            }

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(OnUnhandledException);

            DateTime now = DateTime.Now;
            defaultListener = new DefaultTraceListener();
            defaultListener.LogFileName = String.Format($"{this.logFilePath}{this.prefixFileName}_{now.ToString("yyMMdd_HH")}.{this.extension}");
            defaultListener.AssertUiEnabled = false;

            this.createLogDateTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, 0, 0);
        }
        private void update()
        {
            DateTime now = DateTime.Now;
            TimeSpan interval = now - createLogDateTime;
            if (interval.Hours < 1)
            {
                return;
            }

            this.defaultListener.LogFileName = String.Format($"{this.logFilePath}{this.prefixFileName}_{now.ToString("yyMMdd_HH")}.{this.extension}");
            this.createLogDateTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, 0, 0);
        }
        private string time
        {
            get
            {
                return DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff");
            }
        }

        public override void Fail(string message)
        {
            this.WriteLine("");
            defaultListener.Fail(message);
            Environment.Exit(0);
        }
        public override void Fail(string message, string description)
        {
            this.WriteLine("");
            defaultListener.Fail(message, description);
            Environment.Exit(0);
        }
        public override void Write(string message)
        {
            this.update();
            defaultListener.Write(message);
        }

        public override void WriteLine(string message)
        {
            this.update();
            defaultListener.WriteLine(this.time + "\t" + message);
        }

        public static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Trace.WriteLine(e.ToString() + "\r\n" + e.ExceptionObject.ToString());
            Environment.Exit(0);
        }
    }

    public static class Tracer
    {
        public static void AddTextListener(string logPath)
        {
            Trace.Listeners.Add(new TextTraceListner(logPath));
        }

        public static string GetCaller(
            [CallerFilePath] string filePath = null, // __FILE__
            [CallerLineNumber] int n = 0, // __LINE__
            [CallerMemberName] string name = null) //__FUNC__
        {
            return $"filePath: {filePath}, lineNum: {n.ToString()}, memberName: {name}";
        }

        public static void Assert(bool condition)
        {
            Trace.Assert(condition);
        }

        public static void Assert(bool condition, string msg)
        {
            Trace.Assert(condition, msg);
        }

        public static void Write(string msg)
        {
            Trace.WriteLine(msg);
        }

        public static void Write(string tag, string msg)
        {
            Trace.WriteLine($"[{tag}] {msg}");
        }

        public static void Write(object caller, string msg)
        {
            Trace.WriteLine($"[{caller.GetType().Name}] {msg}");
        }

        public static void Error(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Trace.TraceError(msg);
            Console.ResetColor();
        }
        
        public static void Error(string tag, string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Trace.TraceError($"[{tag}] {msg}");
            Console.ResetColor();
        }

        public static void Exception(object caller, Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Trace.TraceError($"[{caller.GetType().Name}]\n{e.GetType().Name}\n{e.Message}\n{e.StackTrace}");
            Console.ResetColor();
        }

        public static void Exception(object caller, Exception e, string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Trace.TraceError($"[{caller.GetType().Name}]\n{e.Message}\n{e.StackTrace}\n=====\n{msg}");
            Console.ResetColor();
        }
    }
}
