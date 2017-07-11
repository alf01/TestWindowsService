using System;

namespace TestWindowsService
{
    public class ResultMessage
    {
        public ResultMessage(
            string url,
            DateTime date,
            string message)
        {
            Url = url;
            Date = date;
            Message = message;
        }

        public string Url { get; }

        public DateTime Date { get; }

        public string Message { get; }

        public override string ToString()
        {
            return $"Site '{Url}'; Date '{Date}' UTC; Message '{Message}'";
        }
    }
}