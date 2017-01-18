using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OeilNoir
{
    public class People
    {
        int _PAV;
        int _EV;
        int _TM;
        int _TP;
        int _VI;
        string _Name;
        Dictionary<string, int> _Compulsory_Qualities_Modificators;
        Dictionary<string, int> _Choosable_Qualities_Modificators;
        List<Culture> _Choosable_Cultures;

        public string GetName()
        {
            return this._Name;
        }

        public People()
        {
            this._PAV = 0;
            this._EV = 0;
            this._TM = 0;
            this._TP = 0;
            this._VI = 0;
            this._Name = String.Empty;
            this._Compulsory_Qualities_Modificators = new Dictionary<string, int>();
            this._Choosable_Qualities_Modificators = new Dictionary<string, int>();
            this._Choosable_Cultures = new List<Culture>();
        }

        public People(string name)
        {
            this._Name = name;
            // Do Stuff 
        }

        public People(string name, int pav, int ev, int tm, int tp, int vi, Dictionary<string, int> cyqm, Dictionary<string, int> chqm, List<Culture> cults)
        {
            this._Name = name;
            this._PAV = pav;
            this._EV = ev;
            this._TM = tm;
            this._TP = tp;
            this._VI = vi;
            this._Compulsory_Qualities_Modificators = cyqm;
            this._Choosable_Qualities_Modificators = chqm;
            this._Choosable_Cultures = cults;
        }

        public int GetCost()
        {
            return this._PAV;
        }

        public Dictionary<string, int> GetModificators()
        {
            return this._Compulsory_Qualities_Modificators;
        }

        public Dictionary<string, int> GetChoosableModificators()
        {
            return this._Choosable_Qualities_Modificators;
        }

        public List<Culture> GetChoosableCultures()
        {
            return this._Choosable_Cultures;
        }

        public int GetEV()
        {
            return this._EV;
        }

        public int GetTM()
        {
            return this._TM;
        }

        public int GetTP()
        {
            return this._TP;
        }

        public int GetVI()
        {
            return this._VI;
        }
    }
}
