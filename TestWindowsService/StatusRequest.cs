using System;
using System.Net;
using System.Timers;

namespace TestWindowsService
{
    public class StatusRequest : IDisposable
    {
        private readonly Timer timer;
        private readonly string url;

        private readonly int hours;
        private readonly int minutes;
        private readonly int dayInterval;
        private readonly DateTime startDate;

        public StatusRequest(string url, long millisecondsInterval)
        {
            this.url = url;

            timer = new Timer
            {
                Interval = millisecondsInterval
            };

            timer.Elapsed += OnTimer;
            timer.Start();
        }

        public StatusRequest(string url, int dayInterval, int hours, int minutes, DateTime startDate)
        {
            this.url = url;

            this.hours = hours;
            this.minutes = minutes;
            this.dayInterval = dayInterval;
            this.startDate = startDate;

            timer = new Timer
            {
                Interval = 60000
            };

            timer.Elapsed += OnDayTimer;
            timer.Start();
        }

        public void Dispose()
        {
            timer.Stop();
        }

        private void OnTimer(object sender, ElapsedEventArgs args)
        {
            MakeRequest();
        }

        private void OnDayTimer(object sender, ElapsedEventArgs args)
        {
            var nowTime = DateTime.Now;
            int daysGone;
            if (startDate < nowTime)
            {
                TimeSpan timeSpan = nowTime - startDate;
                daysGone = timeSpan.Days;
            }
            else
            {
                throw new Exception("Start Date is bigger than current");
            }

            if (nowTime.Hour == hours && nowTime.Minute == minutes && daysGone % dayInterval == 0)
            {
                MakeRequest();
            }
        }

        private void MakeRequest()
        {
            var request = WebRequest.Create(url);

            try
            {
                using (var response = request.GetResponse())
                {
                    Logger.Append(new ResultMessage(url, DateTime.UtcNow, ((HttpWebResponse)response).StatusCode.ToString()));
                }
            }
            catch (WebException ex)
            {
                Logger.Append(new ResultMessage(url, DateTime.UtcNow, ex.ToString()));
            }
        }
    }
}