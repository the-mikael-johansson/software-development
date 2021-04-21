namespace TerminalApp
{
    /// <summary>
    /// An application built for showing how SonarQube
    /// can be used for analyzing unit test results and
    /// code coverage.
    /// </summary>
    public static class Program
    {
        static void Main(string[] args)
        {
            IApp app = new App();
            app.Print(true);
        }
    }
}
