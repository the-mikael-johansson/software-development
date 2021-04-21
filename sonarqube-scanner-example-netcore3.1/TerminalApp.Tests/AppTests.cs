using Xunit;

namespace TerminalApp.Tests
{
    public class AppTests
    {
        [Fact]
        public void TestPrint()
        {
            var app = new App();
            Assert.True(app.Print(true));
        }

        [Fact]
        public void TestNotToPrint()
        {
            var app = new App();
            Assert.True(app.Print(false));
        }
    }
}
