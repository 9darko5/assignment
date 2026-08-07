using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment.Loaders;

namespace Assignment.Tests.Loaders
{
    // Ovi testovi proveravaju logiku jednog thread-a (npr. klasa ThreadWorker).
    //
    // Ocekivana klasa ima sledece:
    //   - int Duration  — ukupno vreme izvrsavanja u sekundama
    //   - int Elapsed   — koliko sekundi je proslo
    //   - double Progress — izracunati property: (Elapsed / Duration) * 100
    //   - bool IsActive — true sve dok se ne pozove Cancel()
    //   - void Cancel() — zaustavlja thread

    [TestClass]
    public class ThreadWorkerTests
    {
        [TestMethod]
        public void Progress_WhenElapsedIsHalfOfDuration_Returns50()
        {
            // Arrange
            var worker = new ThreadWorker(50) { Elapsed = 25 };

            // Act
            double result = worker.Progress;

            // Assert
            Assert.AreEqual(50.0, result);
        }

        [TestMethod]
        public void Progress_WhenCompleted_Returns100()
        {
            // Arrange
            var worker = new ThreadWorker(30) { Elapsed = 30 };

            // Act
            double result = worker.Progress;

            // Assert
            Assert.AreEqual(100.0, result);
        }

        [TestMethod]
        public void Cancel_WhenCalled_SetsIsActiveToFalse()
        {
            // Arrange
            var worker = new ThreadWorker(10);

            // Act
            worker.Cancel();

            // Assert
            Assert.IsFalse(worker.IsActive);
        }
    }
}
