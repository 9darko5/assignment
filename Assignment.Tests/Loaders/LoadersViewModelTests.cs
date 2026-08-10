using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment.ViewModels;

namespace Assignment.Tests.Loaders
{
    [TestClass]
    public class LoadersViewModelTests
    {
        [TestMethod]
        public void Threads_OnInitialization_ContainsExactlyThree()
        {
            var vm = new LoadersViewModel(false);
            Assert.AreEqual(3, vm.Threads.Count);
        }

        [TestMethod]
        public void TotalProgress_WhenOneThreadCancelled_ExcludesCancelledThread()
        {
            var vm = new LoadersViewModel(false);
            vm.Threads[0].Duration = 10;
            vm.Threads[0].Elapsed = 4;
            vm.Threads[1].Duration = 10;
            vm.Threads[1].Elapsed = 6;
            vm.Threads[2].Duration = 10;
            vm.Threads[2].Elapsed = 8;
            vm.Threads[0].Cancel();

            Assert.AreEqual(70.0, vm.TotalProgress);
        }

        [TestMethod]
        public void TotalProgress_WhenAllThreadsCancelled_ReturnsZero()
        {
            var vm = new LoadersViewModel(false);
            vm.Threads[0].Cancel();
            vm.Threads[1].Cancel();
            vm.Threads[2].Cancel();

            Assert.AreEqual(0.0, vm.TotalProgress);
        }
    }
}