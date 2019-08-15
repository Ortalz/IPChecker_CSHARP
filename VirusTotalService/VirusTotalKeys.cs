using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirusTotal
{
    class VirusTotalKeys
    {
        private static List<string> _apiKeys;
        private static int _position;

        static VirusTotalKeys()
        {
            InitiateKeys();
        }

        private static void InitiateKeys()
        {
            _apiKeys = new List<string>();
            _position = 0;
            _apiKeys.Add("cb02bab483043692bbf0c9f29fe1138797622fd3cea753869431aa0797810aff");
            _apiKeys.Add("c3aa433adbe5d86d93cbdf842969928bc18a352f2cda32b0f1ce573155660bd2");
            _apiKeys.Add("96daee46c02864aab516ec66685080cfd82dce789eae681374ebc69cc28a76c1");
            _apiKeys.Add("676279ca52ef52b782b93c0a72acd444ef218b122a83abc4a2df4f176a29d6dd");
            _apiKeys.Add("2137f219d2846f503cd2394f7c0e876cb1bd255e428f59caa676a5c497af9d93");
        }

        internal static string getCurrentKey()
        {
            return _apiKeys[_position];
        }

        internal static string getNextKey()
        {
            upPos();
            return getCurrentKey();
        }

        private static void upPos()
        {
            if(_position == _apiKeys.Count-1)
                _position = 0;
            else
                _position++;    
        }
        
        internal static int getAmountOfKeys()
        {
            return _apiKeys.Count;
        }
    }
}
