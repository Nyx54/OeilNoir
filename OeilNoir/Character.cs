using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OeilNoir
{
    public class Character : People
    {
        StartLevel _CreationLevel;
        List<Quality> _Qualities;
        int _AT;
        int _PRD;
        int _CD;
        int _EV;
        int _EA;
        int _EK;
        int _TM;
        int _TP;
        int _Esquive;
        int _Init;
        int _VI;
        int _PDD;
        string _Name;
        int _Age;
        string _MonthofBirth;
        int _DayofBirth;
        string _Leading_Hand;
        Culture _Current_Cultures;
        Profession _Job;
        List<Competence> _Competences;
        List<Advantage> _Advantages;
        List<Disadvantage> _Disadvantages;

        public Character()
            : base()
        {
            this._Qualities = new List<Quality>();
            this._AT = 0;
            this._PRD = 0;
            this._CD = 0;
            this._EV = 0;
            this._EA = 0;
            this._EK = 0;
            this._TM = 0;
            this._TP = 0;
            this._Esquive = 0;
            this._Init = 0;
            this._VI = 0;
            this._PDD = 0;
            this._Name = String.Empty;
            this._Age = 0;
            this._MonthofBirth = String.Empty;
            this._DayofBirth = 0;
            this._Leading_Hand = String.Empty;
            this._Current_Cultures = new Culture();
            this._Job = new Profession();
            this._Competences = new List<Competence>();
            this._CreationLevel = new StartLevel();
            List<Advantage> _Advantages = new List<Advantage>();
            List<Disadvantage> _Disadvantages = new List<Disadvantage>();
        }

        public Character(People people, StartLevel lvl, List<Quality> qual)
            : base(people)
        {
            this._Qualities = qual;
            this._AT = 0;
            this._PRD = 0;
            this._CD = 0;
            this._EV = 0;
            this._EA = 0;
            this._EK = 0;
            this._TM = 0;
            this._TP = 0;
            this._Esquive = 0;
            this._Init = 0;
            this._VI = 0;
            this._PDD = 3;
            this._Name = String.Empty;
            this._Age = 0;
            this._MonthofBirth = String.Empty;
            this._DayofBirth = 0;
            this._Leading_Hand = "Right";
            this._Current_Cultures = new Culture();
            this._Job = new Profession();
            this._Competences = new List<Competence>();
            this._CreationLevel = lvl;
            this._CreationLevel.UsePAV(base.GetCost);
            List<Advantage> _Advantages = new List<Advantage>();
            List<Disadvantage> _Disadvantages = new List<Disadvantage>();
        }

        protected int QualityIncreaseCost(string sigle)
        {
            for (int i = 0; i < this._Qualities.Count; i++)
            {
                if (this._Qualities[i].GetSigle == sigle)
                {
                    if (this._Qualities[i].GetValue() < this._CreationLevel.GetMaxQualityValue)
                    {
                        return this._Qualities[i].Cost();
                    }
                }
            }
            return -1;
        }

        public bool ModifyQuality(string sigle)
        {
            for (int i = 0; i < this._Qualities.Count; i++)
            {
                if (this._Qualities[i].GetSigle == sigle)
                {
                    if (this._Qualities[i].GetValue() < this._CreationLevel.GetMaxQualityValue && this._CreationLevel.GetMaxQualityPoints > 0)
                    {
                        this._CreationLevel.UseQualityPoint(1);
                        this._CreationLevel.UsePAV(this._Qualities[i].Cost());
                        this._Qualities[i].ModifyValue(1);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool DecreaseQuality(string sigle)
        {
            for (int i = 0; i < this._Qualities.Count; i++)
            {
                if (this._Qualities[i].GetSigle == sigle)
                {
                    if (this._Qualities[i].GetValue() > 8)
                    {
                        this._Qualities[i].ModifyValue(-1);
                        this._CreationLevel.AddQualityPoint(1);
                        this._CreationLevel.AddPAV((this._Qualities[i].GetValue() > 14) ? (this._Qualities[i].Cost() - 15) : (this._Qualities[i].Cost()));
                        return true;
                    }
                }
            }
            return false;
        }

        public void ApplyModificators()
        {
            foreach (KeyValuePair<string, int> kvp in base.GetModificators)
            {
                for (int i = 0; i < this._Qualities.Count; i++)
                {
                    if (this._Qualities[i].GetSigle == kvp.Key)
                    {
                        this._Qualities[i].ModifyValue(kvp.Value);
                    }
                }
            }
        }

        public void ChooseQualityModificator(string sigle)
        {
            if (base.GetChoosableModificators.ContainsKey(sigle))
            {
                for (int i = 0; i < this._Qualities.Count; i++)
                {
                    if (this._Qualities[i].GetSigle == sigle)
                    {
                        this._Qualities[i].ModifyValue(base.GetChoosableModificators[sigle]);
                    }
                }
            }

        }

        public void ApplyCulturalBagage()
        {
            this._CreationLevel.UsePAV(this._Current_Cultures.GetCost);
            foreach (KeyValuePair<string, int> kvp in this._Current_Cultures.GetBaggage)
            {
                ModifyComp(kvp.Key, kvp.Value);
            }
        }

        public void ChooseCulture(Culture culture)
        {
            this._Current_Cultures = culture;
        }

        public void ChooseProfession(Profession job)
        {
            this._Job = job;
            this._CreationLevel.UsePAV(job.GetCost());
            foreach (KeyValuePair<string, int> kvp in job.GetExperience())
            {
                ModifyComp(kvp.Key, kvp.Value);
            }
        }

        protected void ModifyComp(string comp, int val, char fa = 'A')
        {
			bool applied = false;
            for (int i = 0; i < this._Competences.Count; i++)
            {
                if (this._Competences[i].GetName == comp)
                {
					applied = true;
                    this._Competences[i].ModifyValue(val);
                    return;
                }
            }
			if (!applied)
			{
				this._Competences.Add(new Competence(comp, val, fa));
			}
        }

		public void UseBaseQuality()
		{
			int qualitycost = 0;
			foreach (Quality q in this._Qualities)
			{
				qualitycost += q.GetValue();
			}
			this.GetLevel.UseQualityPoint(qualitycost);
		}

        public List<Quality> GetQualities()
        {
            return this._Qualities;
        }

        public void BaseValues()
        {
            this._EV = base.GetEV + (2 * this.GetQualityValue("CN"));
            this._TM = base.GetTM + Convert.ToInt32(Math.Round((double)((this.GetQualityValue("CO") + this.GetQualityValue("IN") + this.GetQualityValue("IU")) / 6), 0));
            this._TP = base.GetTP + Convert.ToInt32(Math.Round((double)(((this.GetQualityValue("CN") * 2) + this.GetQualityValue("FO")) / 6), 0));
            this._Esquive = Convert.ToInt32(Math.Round((double)(this.GetQualityValue("AG") / 2)));
            this._Init = Convert.ToInt32(Math.Round((double)((this.GetQualityValue("CO") + this.GetQualityValue("AG")) / 2)));
            this._VI = base.GetVI;
        }

        public int GetQualityValue(string sigle)
        {
            foreach (Quality q in this._Qualities)
            {
                if (q.GetSigle == sigle)
                {
                    return q.GetValue();
                }
            }
            return 0;
        }

        public void ChooseName(string name)
        {
            this._Name = name;
        }


        public string GetCurrentCultures
        {
            get
            {
                return this._Current_Cultures.GetName;
            }
        }

        public StartLevel GetLevel
        {
            get
            {
                return this._CreationLevel;
            }
        }

		public List<Competence> GetComp
		{
			get
			{
				return this._Competences;
			}
		}

        public override string ToString()
        {
            string qual = String.Empty;
            foreach (Quality q in this._Qualities)
            {
                qual += (q.ToString() + "\n");
            }
            string comp = String.Empty;
            foreach (Competence cp in this._Competences)
            {
                comp += (cp.ToString() + "\n");
            }
            return String.Format("{0}\t{14}\n{1}\t{11}\n{2} ans\tMain directrice: {3}\n{4}Energie Vitale: {5}\nTenacité Mentale: {6}\nTenacité Physique: {7}\nEsquive: {8}\nInitiative: {9}\nVitesse: {10}\n\n{12}\n\nPAV: {13}",
                                    this._Name, base.GetName, this._Age.ToString(), this._Leading_Hand, qual, this._EV.ToString(),
                                    this._TM.ToString(), this._TP.ToString(), this._Esquive.ToString(), this._Init.ToString(), this._VI.ToString(),
                                    this._Current_Cultures.GetName, comp, this._CreationLevel.GetPAV.ToString(), this._Job.GetName());
        }
    }
}
