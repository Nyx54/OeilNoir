using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OeilNoir
{
    public class Culture
    {
        int _PAV;
        string _Name;
        Dictionary<string, int> _Cultural_Baggage;

        public Culture()
        {
            this._PAV = 0;
            this._Name = String.Empty;
            this._Cultural_Baggage = new Dictionary<string, int>();
        }

        public Culture(string name, int pav, Dictionary<string, int> comp)
        {
            this._PAV = pav;
            this._Name = name;
            this._Cultural_Baggage = comp;
        }

        public int GetCost
        {
            get
            {
                return this._PAV;
            }
        }

        public string GetName
        {
            get
            {
                return this._Name;
            }
        }

        public Dictionary<string, int> GetBaggage
        {
            get
            {
                return this._Cultural_Baggage;
            }
        }

        public string GetCulturalBaggage
        {
            get
            {
                string res = string.Empty;
                foreach (KeyValuePair<string, int> kvp in this._Cultural_Baggage)
                {
                    if (!string.IsNullOrEmpty(res))
                    {
                        res += ", ";
                    }
                    res += string.Format("{0} +{1}", kvp.Key, kvp.Value.ToString());
                }
                return res;
            }
        }
    }
}
