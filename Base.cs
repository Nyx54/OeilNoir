//Rextester.Program.Main is the entry point for your code. Don't change it.
//Compiler version 4.0.30319.17929 for Microsoft (R) .NET Framework 4.5

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rextester
{
    public class Program
    {
		static Data data = new Data();
		
        public static void Main(string[] args)
        {
			Dictionary<string, int> BardeComp = new Dictionary<string, int> ();
			BardeComp.Add("Chant", 1);
			BardeComp.Add("Musique", 2);
			List<Profession> Jobs = new List<Profession>	{ 
										new Profession(157, "Barde", BardeComp),
										new Profession(263, "Chasseur", new Dictionary<string, int> ())
									};
			Character c = new Character("Elfe");
			c.ApplyModificators();
			c.ChooseQualityModificator("FO");
			c.ChooseCulture("Elf des Bois");
			c.ChooseProfession(Jobs[0]);
			c.BaseValues();
			c.ChooseName("Aby-Gaëlle");
			Console.WriteLine(c.ToString());
		}
	
		public class Data
		{
			public Dictionary<string, int> Elfenobli = new Dictionary<string, int> ();
			public Dictionary<string, int> Elfenchoo = new Dictionary<string, int> ();
			public Dictionary<string, int> ElfComp1 = new Dictionary<string, int> ();
			public Dictionary<string, int> ElfComp2 = new Dictionary<string, int> ();
			public People _Elf;
			public List<Culture> ElfCult;
			
			public List<Quality> _Qualities = new List<Quality>	{ 
											new Quality("Force", "FO", "Orange"),
											new Quality("Courage", "CO", "Rouge"),
											new Quality("Intelligence", "IN", "Violet"),
											new Quality("Intuition", "IU", "Vert"),
											new Quality("Dextérité", "DE", "Jaune"),
											new Quality("Agilité", "AG", "Bleu"),
											new Quality("Charisme", "CH", "Noir"),
											new Quality("Constitution", "CN", "Blanc")
										};
																	
			public List<Quality> GetQualities()
			{
				return this._Qualities;
			}
		
			public People GetElf()
			{
				return _Elf;
			}
			
			public Data()
			{
				Elfenobli.Add("IU", 1);
				Elfenobli.Add("AG", 1);
				Elfenchoo.Add("IN", -2);
				Elfenchoo.Add("FO", -2);
				ElfComp1.Add("Furtivité", 2);
				ElfComp1.Add("Survie", 1);
				ElfComp2.Add("Furtivité", 2);
				ElfComp2.Add("Survie", 2);
				ElfCult =  new List<Culture>	{
									new Culture("Elf des Bois", 47, ElfComp1),
									new Culture("Elf des Névés", 55, ElfComp2),
									new Culture("Elf des Prairies", 43, ElfComp1)
								};
				_Elf = new People ("Elf", 18, 2, -4, -6, 8, Elfenobli, Elfenchoo, ElfCult);			
			}
		}
		
		public class StartLevel
		{
			int _Nb_PAV;
			int _Nb_Fight_Techniques;
			int _Nb_Qualities_Points;
			int _Nb_Spells;
			int _Nb_Spells_HT;
			int _Max_Value_Competence;
			int _Max_Value_Quality;
			
			public StartLevel()
			{
				this._Nb_PAV = 0;
				this._Nb_Fight_Techniques = 0;
				this._Max_Value_Competence = 0;
				this._Max_Value_Quality = 0;
				this._Nb_Qualities_Points = 0;
				this._Nb_Spells = 0;
				this._Nb_Spells_HT = 0;
			}
			
			public StartLevel(int mpav, int mft, int mvc, int mvq, int nbqp, int nbs, int nbsht)
			{
				this._Nb_PAV = mpav;
				this._Nb_Fight_Techniques = mft;
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
			
			public int GetPAV()
			{
				return this._Nb_PAV;
			}
			
			public int GetMaxQualityValue()
			{
				return this._Max_Value_Quality;
			}
			
			public void UseQualityPoint(int cost)
			{
				if (this._Nb_Qualities_Points >= cost)
				{
					this._Nb_Qualities_Points -= cost;
				}
			}
		}
		
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
				this._PAV = data.GetElf().GetCost(); // elf pour l'exemple
				this._EV = data.GetElf().GetEV();
				this._TM = data.GetElf().GetTM();
				this._TP = data.GetElf().GetTP();
				this._VI = data.GetElf().GetVI();
				this._Compulsory_Qualities_Modificators = data.GetElf().GetModificators();
				this._Choosable_Qualities_Modificators = data.GetElf().GetChoosableModificators();
				this._Choosable_Cultures = data.GetElf().GetChoosableCultures();
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
			
			public int GetCost()
			{
				return this._PAV;
			}
			
			public string GetName()
			{
				return this._Name;
			}
			
			public Dictionary<string, int> GetBaggage()
			{
				return this._Cultural_Baggage;
			}
		}
		
		public class Profession
		{
			int _PAV;
			string _Name;
			Dictionary<string, int> _Professional_Experience;
			
			public Profession()
			{
				this._PAV = 0;
				this._Name = String.Empty;
				this._Professional_Experience = new Dictionary<string, int> ();
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
		
		public class Character : People
		{
			StartLevel _CreationLevel = new StartLevel (1000, 10, 10, 13, 98, 10, 1);
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
			List<Culture> _Current_Cultures;
			Profession _Job;
			List<Competence> _Competences;
								
			public Character() : base ("Humain")
			{
				this._Qualities = new List<Quality> ();
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
				this._Current_Cultures = new List<Culture>();
				this._Job = new Profession();
				this._Competences = new List<Competence>();
			}
			
			public Character(string people) : base (people)
			{
				//this._Qualities = new List<Quality> ();
				this._Qualities = data.GetQualities();
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
				this._Current_Cultures = new List<Culture>();
				this._Job = new Profession();
				this._Competences = new List<Competence>();
				
				this._CreationLevel.UsePAV(base.GetCost());
			}
			
			public int QualityIncreaseCost(string sigle)
			{
				for (int i = 0; i < this._Qualities.Count; i++)
				{
					if (this._Qualities[i].GetSigle() == sigle)
					{
						if (this._Qualities[i].GetValue() < this._CreationLevel.GetMaxQualityValue())
						{	
							return this._Qualities[i].Cost();
						}
					}
				}
				return -1;
			}
			
			public void ModifyQuality(string sigle)
			{
				for (int i = 0; i < this._Qualities.Count; i++)
				{
					if (this._Qualities[i].GetSigle() == sigle)
					{
						if (this._Qualities[i].GetValue() < this._CreationLevel.GetMaxQualityValue())
						{
							this._CreationLevel.UseQualityPoint(this._Qualities[i].Cost());
							this._Qualities[i].ModifyValue(1);
						}
					}
				}	
			}
			
			public void ApplyModificators()
			{
				foreach(KeyValuePair<string, int> kvp in base.GetModificators())
				{
					for (int i = 0; i < this._Qualities.Count; i++)
					{
						if (this._Qualities[i].GetSigle() == kvp.Key)
						{
							this._Qualities[i].ModifyValue(kvp.Value);
						}
					}
				}
			}
			
			public void ChooseQualityModificator(string sigle)
			{
				if (base.GetChoosableModificators().ContainsKey(sigle))
				{
					for (int i = 0; i < this._Qualities.Count; i++)
					{
						if (this._Qualities[i].GetSigle() == sigle)
						{
							this._Qualities[i].ModifyValue(base.GetChoosableModificators()[sigle]);
						}
					}
				}

			}
			
			public void ChooseCulture(string culture)
			{
				foreach (Culture cult in base.GetChoosableCultures())
				{
					if (cult.GetName() == culture)
					{
						this._Current_Cultures.Add(cult);
						if (this._Current_Cultures.Count > 1)
						{
							this._CreationLevel.UsePAV(cult.GetCost());
						}
						foreach (KeyValuePair<string, int> kvp in  cult.GetBaggage())
						{
							ModifyComp(kvp.Key, kvp.Value);
						}
					}
				}
			}
			
			public void ChooseProfession(Profession job)
			{
				this._Job = job;
				this._CreationLevel.UsePAV(job.GetCost());
				foreach (KeyValuePair<string, int> kvp in  job.GetExperience())
				{
					ModifyComp(kvp.Key, kvp.Value);
				}
			}
			
			protected void ModifyComp(string comp, int val)
			{
				for (int i = 0; i < this._Competences.Count; i++)
				{
					if (this._Competences[i].GetName() == comp)
					{
						this._Competences[i].ModifyValue(val);
						return;
					}
				}
				this._Competences.Add(new Competence(comp, val));
			}
			
			public List<Quality> GetQualities()
			{
				return this._Qualities;
			}
			
			public void BaseValues()
			{
				this._EV = base.GetEV() + (2 * this.GetQualityValue("CN"));
				this._TM = base.GetTM() + Convert.ToInt32(Math.Round((double)((this.GetQualityValue("CO") + this.GetQualityValue("IN") + this.GetQualityValue("IU")) / 6), 0));
				this._TP = base.GetTP() + Convert.ToInt32(Math.Round((double)(((this.GetQualityValue("CN") * 2) + this.GetQualityValue("FO")) / 6), 0));
				this._Esquive = Convert.ToInt32(Math.Round((double)(this.GetQualityValue("AG") / 2)));
				this._Init = Convert.ToInt32(Math.Round((double)((this.GetQualityValue("CO") + this.GetQualityValue("AG")) / 2)));
				this._VI = base.GetVI();
			}
			
			protected int GetQualityValue(string sigle)
			{
				foreach (Quality q in this._Qualities)
				{
					if (q.GetSigle() == sigle)
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
			
			public override string ToString()
			{
				string qual = String.Empty;
				foreach (Quality q in this._Qualities)
				{
					qual += (q.ToString() + "\n");
				}
				string cult = String.Empty;
				foreach (Culture c in this._Current_Cultures)
				{
					cult += (c.GetName() + "\t");
				}
				string comp = String.Empty;
				foreach (Competence cp in this._Competences)
				{
					comp += (cp.ToString() + "\n");
				}
				return String.Format("{0}\t{14}\n{1}\t{11}\n{2} ans\tMain directrice: {3}\n{4}Energie Vitale: {5}\nTenacité Mentale: {6}\nTenacité Physique: {7}\nEsquive: {8}\nInitiative: {9}\nVitesse: {10}\n\n{12}\n\nPAV: {13}",
										this._Name, base.GetName(), this._Age.ToString(), this._Leading_Hand, qual, this._EV.ToString(), 
										this._TM.ToString(), this._TP.ToString(), this._Esquive.ToString(), this._Init.ToString(), this._VI.ToString(), 
										cult, comp, this._CreationLevel.GetPAV().ToString(), this._Job.GetName());
			}
		}
		
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
		
		public class Advantage
		{
			
		}
		
		public class Disadvantage
		{
			
		}
	
	}
}
