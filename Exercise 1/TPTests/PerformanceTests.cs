using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP;

namespace Tests
{
    [TestClass]
    public class PerformanceTest
    {
        DataRepository dataRepository;

        [TestMethod]
        public void RandomFillerTest()
        {
            dataRepository = new DataRepository(new DataContext(), new RandomFiller(1000, 1000));

            System.Diagnostics.Stopwatch clock = new System.Diagnostics.Stopwatch();
            dataRepository.UseFiller();
            clock.Stop();
            long time1000 = clock.ElapsedMilliseconds;

            dataRepository = new DataRepository(new DataContext(), new RandomFiller(10000, 10000));
            clock.Restart();
            dataRepository.UseFiller();
            clock.Stop();
            long time10000 = clock.ElapsedMilliseconds;

            dataRepository = new DataRepository(new DataContext(), new RandomFiller(100000, 100000));
            clock.Restart();
            dataRepository.UseFiller();
            clock.Stop();
            long time100000 = clock.ElapsedMilliseconds;

            // check for linearity of solution
            Assert.IsTrue(time1000 <= 10*time10000);
            Assert.IsTrue(time10000 <= 10*time100000);
        }
    }
}