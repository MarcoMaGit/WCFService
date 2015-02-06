namespace SensorDataService
{
    public static class SensorDataRepositoryFactory
    {
        /// <summary>
        /// This is a thread-safe, lazy singleton.  See http://www.yoda.arachsys.com/csharp/singleton.html
        /// for more details about its implementation.
        /// </summary>
        public static SensorDataRepository Instance
        {
            get { return Nested.SensorDataRepository; }
        }

        private class Nested
        {
            internal static readonly SensorDataRepository SensorDataRepository = new SensorDataRepository();
        }
    }
}