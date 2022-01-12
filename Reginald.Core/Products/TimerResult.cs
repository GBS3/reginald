﻿using Reginald.Core.Notifications;
using System;
using System.Threading.Tasks;
using System.Timers;

namespace Reginald.Core.Products
{
    public class TimerResult : SearchResult
    {
        private const string TimerDescriptionFormat = "{0}:{1:D2}:{2:D2}";

        private const string AltCaption = "Cancel Timer?";

        private double _time;
        public double Time
        {
            get => _time;
            set
            {
                _time = value;
                NotifyOfPropertyChange(() => Time);
            }
        }

        private Timer _timer;
        public Timer Timer
        {
            get => _timer;
            set
            {
                _timer = value;
                NotifyOfPropertyChange(() => Timer);
            }
        }

        private string _originalDescription;
        public string OriginalDescription
        {
            get => _originalDescription;
            set
            {
                _originalDescription = value;
                NotifyOfPropertyChange(() => OriginalDescription);
            }
        }

        public TimerResult(TimerKeyword keyword)
        {
            Guid = Guid.NewGuid();
            Name = keyword.Name;
            Icon = keyword.Icon;
            Caption = keyword.Completion;
            Time = keyword.Time;
            TimeSpan span = TimeSpan.FromMilliseconds(Time);
            Description = string.Format(TimerDescriptionFormat, span.Hours, span.Minutes, span.Seconds);
            OriginalDescription = keyword.Completion;
        }

        public override bool Predicate()
        {
            return Timer.Enabled;
        }

        public override Task<bool> EnterDownAsync(bool isAltDown, Action action, object o)
        {
            if (isAltDown)
            {
                Timer.Stop();
            }
            return Task.FromResult(!isAltDown);
        }

        public override (string, string) AltDown()
        {
            return (null, AltCaption);
        }

        public override (string, string) AltUp()
        {
            return (null, OriginalDescription);
        }

        public void OnTimeChanged(object sender, ElapsedEventArgs e)
        {
            Time -= 1000;
            if (Time <= 0)
            {
                Timer.Stop();
                ToastNotifications.SendSimpleToastNotification(Name, OriginalDescription);
            }

            TimeSpan span = TimeSpan.FromMilliseconds(Time);
            Description = string.Format(TimerDescriptionFormat, span.Hours, span.Minutes, span.Seconds);
        }

        public void StartTimer()
        {
            Timer = new Timer(1000);
            Timer.Elapsed += OnTimeChanged;
            Timer.AutoReset = true;
            Timer.Enabled = true;
        }
    }
}
