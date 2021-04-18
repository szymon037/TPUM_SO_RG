using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reactive.Linq;

using Logic;

namespace Logic.Tests
{
    [TestClass]
    public class ReactiveTimerTests
    {
        [TestMethod]
        public void ReactiveTimerTest()
        {
            using (ReactiveTimer reactiveTimer = new ReactiveTimer(TimeSpan.FromSeconds(1)))
            {
                bool test = false;

                IObservable<System.Reactive.EventPattern<ReactiveEvent>> _tickObservable = Observable.FromEventPattern<ReactiveEvent>(reactiveTimer, "Tick");
                IDisposable _observer = _tickObservable.Subscribe(x => test = !test);
                reactiveTimer.Start();

                Assert.IsFalse(test);

                System.Threading.Thread.Sleep(1100);
                Assert.IsTrue(test);

                System.Threading.Thread.Sleep(1100);
                Assert.IsFalse(test);
            }
        }
    }
}
