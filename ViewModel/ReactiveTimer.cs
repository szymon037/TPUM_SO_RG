using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace ViewModel
{
    public class ReactiveEvent : EventArgs
    {
        public ReactiveEvent(long counter)
        {
            Counter = counter;
        }

        public long Counter
        {
            get;
            private set;
        }
    }

    public class ReactiveTimer : IDisposable
    {
        public ReactiveTimer(TimeSpan period)
        {
            Period = period;
        }

        public event EventHandler<ReactiveEvent> Tick;
        public void Start()
        {
            IObservable<long> _TimerObservable = Observable.Interval(Period);
            m_TimerSubscription = _TimerObservable.ObserveOn(Scheduler.Default).Subscribe(c => RaiseTick(c));
        }

        public TimeSpan Period
        {
            get;
            private set;
        }

        IDisposable m_TimerSubscription = null;
        private void RaiseTick(long counter)
        {
            Tick?.Invoke(this, new ReactiveEvent(counter));
        }

        private bool disposedValue = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

    }
}