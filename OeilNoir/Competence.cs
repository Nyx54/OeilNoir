using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OeilNoir
{
    public class Competence
    {
        string _Name;
        int _Value;

        public Competence()
        {
            this._Name = String.Empty;
            this._Value = 0;
        }

        public Competence(string comp, int val)
        {
            this._Name = comp;
            this._Value = val;
        }

        public string GetName()
        {
            return this._Name;
        }

        public void ModifyValue(int val)
        {
            this._Value += val;
        }

        public override string ToString()
        {
            return String.Format("{0}: {1}", this._Name, this._Value);
        }
    }
}
