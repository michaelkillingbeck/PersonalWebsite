using System;
using System.Runtime.CompilerServices;

namespace CommonComponents.Interfaces
{
    public interface ILogger
    {
        string FormatString(string message, string callingMemberName);
        void DebugFormat(string message, [CallerMemberName]string methodName = "");
        void ErrorFormat(string message, [CallerMemberName]string methodName = "");
        void LogException(string Message, Exception ex, [CallerMemberName]string methodName = "");
        void WarnFormat(string message, [CallerMemberName]string methodName = "");
    }
}
