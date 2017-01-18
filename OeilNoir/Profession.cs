using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OeilNoir
{
    public class Profession
    {
        int _PAV;
        string _Name;
        Dictionary<string, int> _Professional_Experience;

        public Profession()
        {
            this._PAV = 0;
            this._Name = String.Empty;
            this._Professional_Experience = new Dictionary<string, int>();
        }

        public Profession(int pav, string name, Dictionary<string, int> comp)
        {
            this._PAV = pav;
            this._Name = name;
            this._Professional_Experience = comp;
        }

        public int GetCost()
        {
            return this._PAV;
        }

        public string GetName()
        {
            return this._Name;
        }

        public Dictionary<string, int> GetExperience()
        {
            return this._Professional_Experience;
        }
    }
}
