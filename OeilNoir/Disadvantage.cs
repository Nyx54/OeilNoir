﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OeilNoir
{
    class Disadvantage
    {
        string _Name;
        List<string> _Conditions;
        int _PAV;

        public Disadvantage()
        {
            this._Name = String.Empty;
            this._Conditions = new List<string>();
            this._PAV = 0;
        }

        public Disadvantage(string name, List<string> cond, int pav)
        {
            this._Name = name;
            this._Conditions = cond;
            this._PAV = pav;
        }
    }
}
