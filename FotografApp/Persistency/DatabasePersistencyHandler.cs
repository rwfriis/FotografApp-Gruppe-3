using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotografApp.Persistency
{
    class DatabasePersistencyHandler
    {
        private readonly static DatabasePersistencyHandler instance = new DatabasePersistencyHandler();

        public static DatabasePersistencyHandler Instance { get { return instance; } }
    }
}
