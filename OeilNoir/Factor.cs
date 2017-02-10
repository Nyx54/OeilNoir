using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OeilNoir
{
	class Factor
	{
		List<int> _FA;
		string _Lvl;
		public Factor()
		{
			_Lvl = "";
			_FA = null;
		}

		public Factor(string lvl, List<int> fa)
		{
			_Lvl = lvl;
			_FA = fa;
		}

		public string GetLevel
		{
			get
			{
				return _Lvl;
			}
		}

		public int GetAValue
		{
			get
			{
				return _FA[0];
			}
		}
		public int GetBValue
		{
			get
			{
				return _FA[1];
			}
		}
		public int GetCValue
		{
			get
			{
				return _FA[2];
			}
		}
		public int GetDValue
		{
			get
			{
				return _FA[3];
			}
		}
		public int GetEValue
		{
			get
			{
				return _FA[4];
			}
		}
	}
}
