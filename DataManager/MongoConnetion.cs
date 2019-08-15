using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager
{
    internal class MongoConnetion
    {
        private static MongoConnetion _instance = null;
        private static readonly string mongoLocalDBURL = "";
        private static readonly string mongoRemoteDBURL = "";
        private static bool _IsLocal;

        private MongoConnetion()
        {

        }

        internal static MongoConnetion GetInstance()
        {
            if (_instance == null)
                _instance = new MongoConnetion();
            return _instance;
        }

        internal static void SetLocalDB()
        {
            _IsLocal = true;
        }

        internal static void SetRemoteDB()
        {
            _IsLocal = false;
        }

        internal static string URL
        {
            get
            {
                if (_IsLocal)
                    return mongoLocalDBURL;
                return mongoRemoteDBURL;
            }
        }
    }
}
