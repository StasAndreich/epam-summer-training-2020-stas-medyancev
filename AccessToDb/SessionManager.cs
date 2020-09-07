using AccessToDb.Contracts;

namespace AccessToDb
{
    /// <summary>
    /// Business logic of a session.
    /// </summary>
    public class SessionManager
    {
        private readonly IDaoFactory daoFactory;

        /// <summary>
        /// Default ctor.
        /// </summary>
        /// <param name="factory"></param>
        public SessionManager(IDaoFactory factory)
        {
            this.daoFactory = factory;
        }


    }
}
