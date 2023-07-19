using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Save_Editor
{
    internal class SaveEncryptionManager
    {
        public static string process(string data, string key = "pumpkinheadBossLvl")
        {
            string result = "";
            for (int i = 0; i < data.Length; i++)
            {
                result += (char)(data[i] ^ key[i % key.Length]);
            }
            return result;
        }
    }
}
