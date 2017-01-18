using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OeilNoir
{
    public class Quality
    {
        string _Name;
        string _Sigle;
        int _Value;
        string _Color;

        public Quality()
        {
            this._Name = String.Empty;
            this._Sigle = String.Empty;
            this._Value = 0;
            this._Color = String.Empty;
        }

        public Quality(string name, string sigle, string color)
        {
            this._Name = name;
            this._Sigle = sigle;
            this._Value = 8;
            this._Color = color;
        }

        public string GetSigle()
        {
            return this._Sigle;
        }

        public void ModifyValue(int val)
        {
            this._Value += val;
        }

        public int GetValue()
        {
            return this._Value;
        }

        public int Cost()
        {
            int cost = 15;
            if (this._Value >= 14)
            {
                for (int i = 0; (i + 14) <= this._Value; i++)
                {
                    cost += 15;
                }
            }
            return cost;
        }

        public override string ToString()
        {
            return String.Format("{0} ({1}) [{2}] Value: {3}", this._Name, this._Sigle, this._Color, this._Value.ToString());
        }
    }
}
