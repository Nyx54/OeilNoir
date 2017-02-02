using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OeilNoir
{
    public class StartLevel
    {
        string _Name;
        int _Nb_PAV;
        int _Max_Value_Fight_Techniques;
        int _Nb_Qualities_Points;
        int _Nb_Spells;
        int _Nb_Spells_HT;
        int _Max_Value_Competence;
        int _Max_Value_Quality;
       // Dictionary<char, Dictionary<int, int>> _Facteurs_Amelioration;

        public StartLevel()
        {
            this._Name = String.Empty;
            this._Nb_PAV = 0;
            this._Max_Value_Fight_Techniques = 0;
            this._Max_Value_Competence = 0;
            this._Max_Value_Quality = 0;
            this._Nb_Qualities_Points = 0;
            this._Nb_Spells = 0;
            this._Nb_Spells_HT = 0;
        }

        public StartLevel(StartLevel lvl)
        {
            this._Name = lvl.GetName;
            this._Nb_PAV = lvl.GetPAV;
            this._Max_Value_Fight_Techniques = lvl.GetMaxFT;
            this._Max_Value_Competence = lvl.GetMaxCompetenceValue;
            this._Max_Value_Quality = lvl.GetMaxQualityValue;
            this._Nb_Qualities_Points = lvl.GetMaxQualityPoints;
            this._Nb_Spells = lvl.GetNbSpells;
            this._Nb_Spells_HT = lvl.GetNbSpellsHT;
        }

        public StartLevel(int mpav, int mft, int mvc, int mvq, int nbqp, int nbs, int nbsht, string name)
        {
            this._Name = name;
            this._Nb_PAV = mpav;
            this._Max_Value_Fight_Techniques = mft;
            this._Max_Value_Competence = mvc;
            this._Max_Value_Quality = mvq;
            this._Nb_Qualities_Points = nbqp;
            this._Nb_Spells = nbs;
            this._Nb_Spells_HT = nbsht;
        }

        public void UsePAV(int pav)
        {
            if (this._Nb_PAV >= pav)
            {
                this._Nb_PAV -= pav;
            }
        }

        public void AddPAV(int pav)
        {
            this._Nb_PAV += pav;
        }

        public string GetName
        {
            get
            {
                return this._Name;
            }
        }

        public int GetPAV
        {
            get
            {
                return this._Nb_PAV;
            }
        }

        public string GetPAVString
        {
            get
            {
                return this._Nb_PAV.ToString();
            }
        }

        public int GetMaxQualityValue
        {
            get
            {
                return this._Max_Value_Quality;
            }
        }

        public int GetMaxQualityPoints
        {
            get
            {
                return this._Nb_Qualities_Points;
            }
        }

		public string GetQualityPointsString
		{
			get
			{
				return this._Nb_Qualities_Points.ToString();
			}
		}
		public int GetNbSpells
        {
            get
            {
                return this._Nb_Spells;
            }
        }

        public int GetNbSpellsHT
        {
            get
            {
                return this._Nb_Spells_HT;
            }
        }
        public int GetMaxCompetenceValue
        {
            get
            {
                return this._Max_Value_Competence;
            }
        }

        public int GetMaxFT
        {
            get
            {
                return this._Max_Value_Fight_Techniques;
            }
        }

        public void UseQualityPoint(int cost)
        {
            if (this._Nb_Qualities_Points >= cost)
            {
                this._Nb_Qualities_Points -= cost;
            }
        }

        public void AddQualityPoint(int cost)
        {
            if (this._Nb_Qualities_Points >= cost)
            {
                this._Nb_Qualities_Points += cost;
            }
        }
    }
}
