using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OeilNoir
{
    class SpecialCapacity
    {
        string _Name;
        int _PAV;
        List<Competence> _Conditions;

        public SpecialCapacity()
        {
            this._Name = string.Empty;
            this._PAV = 0;
            this._Conditions = new List<Competence>();
        }

        public SpecialCapacity(string name, int pav, List<Competence> cond)
        {
            this._Name = name;
            this._PAV = pav;
            this._Conditions = cond;
        }
    }
}
