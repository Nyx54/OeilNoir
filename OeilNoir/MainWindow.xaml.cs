using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace OeilNoir
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Quality> _Qualities = new List<Quality>();
        List<People> _Peoples = new List<People>();
        List<StartLevel> _Levels = new List<StartLevel>();
        List<Culture> _Cultures = new List<Culture>();
        List<QualityIncrementor> _Qualinc = new List<QualityIncrementor>();
        Character _Char = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            /*
             * Load Levels 
             */
            XmlDocument doclvl = new XmlDocument();
            doclvl.LoadXml(DataResources.StartLevels);
            XmlNode rootlvl = doclvl.LastChild;

            if (rootlvl.HasChildNodes)
            {
                for (int i = 0; i < rootlvl.ChildNodes.Count; i++)
                {
                    StartLevel lvl = new StartLevel(Convert.ToInt32(rootlvl.ChildNodes[i].ChildNodes[0].InnerText), Convert.ToInt32(rootlvl.ChildNodes[i].ChildNodes[1].InnerText), Convert.ToInt32(rootlvl.ChildNodes[i].ChildNodes[2].InnerText),
                                                    Convert.ToInt32(rootlvl.ChildNodes[i].ChildNodes[3].InnerText), Convert.ToInt32(rootlvl.ChildNodes[i].ChildNodes[4].InnerText), Convert.ToInt32(rootlvl.ChildNodes[i].ChildNodes[5].InnerText),
                                                    Convert.ToInt32(rootlvl.ChildNodes[i].ChildNodes[6].InnerText), rootlvl.ChildNodes[i].ChildNodes[7].InnerText.Trim());
                    _Levels.Add(lvl);
                }
            }

            /*
             * Load Qualities 
             */
            XmlDocument docqual = new XmlDocument();
            docqual.LoadXml(DataResources.Qualities);
            XmlNode rootqual = docqual.LastChild;

            if (rootqual.HasChildNodes)
            {
                for (int i = 0; i < rootqual.ChildNodes.Count; i++)
                {
                    Quality q = new Quality(rootqual.ChildNodes[i].ChildNodes[0].InnerText.Trim(), rootqual.ChildNodes[i].ChildNodes[1].InnerText.Trim(), rootqual.ChildNodes[i].ChildNodes[2].InnerText.Trim());
                    _Qualities.Add(q);
                }
            }
            /*
             * Load Culture 
             */
            XmlDocument doccult = new XmlDocument();
            doccult.LoadXml(DataResources.Cultures);
            XmlNode rootcult = doccult.LastChild;

            if (rootcult.HasChildNodes)
            {
                for (int i = 0; i < rootcult.ChildNodes.Count; i++)
                {
                    Dictionary<string, int> _comp = new Dictionary<string, int>();
                    for (int j = 0; j < rootcult.ChildNodes[i].ChildNodes[2].ChildNodes.Count; j++)
                    {
                        _comp.Add(rootcult.ChildNodes[i].ChildNodes[2].ChildNodes[j].ChildNodes[0].InnerText.Trim(), Convert.ToInt32(rootcult.ChildNodes[i].ChildNodes[2].ChildNodes[j].ChildNodes[1].InnerText));
                    }
                    Culture c = new Culture(rootcult.ChildNodes[i].ChildNodes[0].InnerText.Trim(), Convert.ToInt32(rootcult.ChildNodes[i].ChildNodes[1].InnerText), _comp);
                    _Cultures.Add(c);
                }
            }

            /*
             * Load Peoples 
             */
            XmlDocument docpeople = new XmlDocument();
            docpeople.LoadXml(DataResources.Peoples);
            XmlNode rootpeople = docpeople.LastChild;
            if (rootpeople.HasChildNodes)
            {
                for (int i = 0; i < rootpeople.ChildNodes.Count; i++)
                {
                    Dictionary<string, int> _compqualities = new Dictionary<string, int>();
                    for (int j = 0; j < rootpeople.ChildNodes[i].ChildNodes[6].ChildNodes.Count; j++)
                    {
                        _compqualities.Add(rootpeople.ChildNodes[i].ChildNodes[6].ChildNodes[j].ChildNodes[0].InnerText.Trim(), Convert.ToInt32(rootpeople.ChildNodes[i].ChildNodes[6].ChildNodes[j].ChildNodes[1].InnerText));
                    }
                    Dictionary<string, int> _chosqualities = new Dictionary<string, int>();
                    for (int k = 0; k < rootpeople.ChildNodes[i].ChildNodes[7].ChildNodes.Count; k++)
                    {
                        _chosqualities.Add(rootpeople.ChildNodes[i].ChildNodes[7].ChildNodes[k].ChildNodes[0].InnerText.Trim(), Convert.ToInt32(rootpeople.ChildNodes[i].ChildNodes[7].ChildNodes[k].ChildNodes[1].InnerText));
                    }
                    List<string> _choscults = new List<string>();
                    for (int l = 0; l < rootpeople.ChildNodes[i].ChildNodes[8].ChildNodes.Count; l++)
                    {
                        _choscults.Add(rootpeople.ChildNodes[i].ChildNodes[8].ChildNodes[l].InnerText.Trim());
                    }
                    People p = new People(rootpeople.ChildNodes[i].ChildNodes[0].InnerText.Trim(), Convert.ToInt32(rootpeople.ChildNodes[i].ChildNodes[1].InnerText), Convert.ToInt32(rootpeople.ChildNodes[i].ChildNodes[2].InnerText),
                        Convert.ToInt32(rootpeople.ChildNodes[i].ChildNodes[3].InnerText), Convert.ToInt32(rootpeople.ChildNodes[i].ChildNodes[4].InnerText), Convert.ToInt32(rootpeople.ChildNodes[i].ChildNodes[5].InnerText),
                        _compqualities, _chosqualities, _choscults);
                    _Peoples.Add(p);
                }
            }
        }

        /*
        * Boutons
        */
        private void BtnCrea_Click(object sender, RoutedEventArgs e)
        {
            CbLevel.Visibility = Visibility.Visible;
            foreach (StartLevel lvl in _Levels)
            {
                CbLevel.Items.Add(lvl.GetName);
            }

        }

        private void BtnQual_Click(object sender, RoutedEventArgs e)
        {
            if (Ltv.Items.Count > 0)
                Ltv.Items.Clear();
            GridView gridView = new GridView();

            Ltv.View = gridView;
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Qualité",
                DisplayMemberBinding = new Binding("GetName"),
                Width = ((Ltv.Width / 5) - 2) * 2
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Sigle",
                DisplayMemberBinding = new Binding("GetSigle"),
                Width = ((Ltv.Width / 5) - 2)
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Couleur",
                DisplayMemberBinding = new Binding("GetColor"),
                Width = ((Ltv.Width / 5) - 2) * 2
            });
            // Populate list
            foreach (Quality q in _Qualities)
            {
                Ltv.Items.Add(q);
            }
        }

        private void BtnCult_Click(object sender, RoutedEventArgs e)
        {
            if (Ltv.Items.Count > 0)
                Ltv.Items.Clear();
            GridView gridView = new GridView();

            Ltv.View = gridView;
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Culture",
                DisplayMemberBinding = new Binding("GetName"),
                Width = ((Ltv.Width / 5) - 2) * 2
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Coût",
                DisplayMemberBinding = new Binding("GetCost"),
                Width = ((Ltv.Width / 5) - 2)
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Bagage Culturel",
                DisplayMemberBinding = new Binding("GetCulturalBaggage")
            });
            // Populate list
            foreach (Culture c in _Cultures)
            {
                Ltv.Items.Add(c);
            }
        }

        private void BtnPeo_Click(object sender, RoutedEventArgs e)
        {
            if (Ltv.Items.Count > 0)
                Ltv.Items.Clear();
            GridView gridView = new GridView();

            Ltv.View = gridView;
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Peuple",
                DisplayMemberBinding = new Binding("GetName"),
                Width = ((Ltv.Width / 8) - 2) * 3
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "EV",
                DisplayMemberBinding = new Binding("GetEV"),
                Width = ((Ltv.Width / 8) - 2)
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "TM",
                DisplayMemberBinding = new Binding("GetTM"),
                Width = ((Ltv.Width / 8) - 2)
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "TP",
                DisplayMemberBinding = new Binding("GetTP"),
                Width = ((Ltv.Width / 8) - 2)
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "VI",
                DisplayMemberBinding = new Binding("GetVI"),
                Width = ((Ltv.Width / 8) - 2)
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Coût",
                DisplayMemberBinding = new Binding("GetCost"),
                Width = ((Ltv.Width / 8) - 2)
            });

            // Populate list
            foreach (People p in _Peoples)
            {
                Ltv.Items.Add(p);
            }
        }

        private void BtnLevels_Click(object sender, RoutedEventArgs e)
        {
            if (Ltv.Items.Count > 0)
                Ltv.Items.Clear();
            GridView gridView = new GridView();

            Ltv.View = gridView;
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Level",
                DisplayMemberBinding = new Binding("GetName")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Compte PAV",
                DisplayMemberBinding = new Binding("GetPAV")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Val. Max. Qualité",
                DisplayMemberBinding = new Binding("GetMaxQualityValue")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Val. Max. Compétence",
                DisplayMemberBinding = new Binding("GetMaxCompetenceValue")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Val. Max. Technique de Combat",
                DisplayMemberBinding = new Binding("GetMaxFT")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Nbr. Max points de qualité",
                DisplayMemberBinding = new Binding("GetMaxQualityPoints")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Nbr. Max de sorts/liturgies",
                DisplayMemberBinding = new Binding("GetNbSpells")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Dont sorts hors tradition",
                DisplayMemberBinding = new Binding("GetNbSpellsHT")
            });

            // Populate list
            foreach (StartLevel lvl in _Levels)
            {
                Ltv.Items.Add(lvl);
            }
        }


        private void BtnAff_Click(object sender, RoutedEventArgs e)
        {
            CharacterSheet _CS = new CharacterSheet(_Char);
            _CS.ShowDialog();
       /*     PrintDialog dialog = new PrintDialog();
            bool? dialogResult = dialog.ShowDialog();
            if (dialogResult.HasValue && dialogResult.Value)
            {
                dialog.PrintVisual(BaseGrid, "test");
            }*/
        }


        /*
        * Combos
        */
        private void CbPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_Char == null)
            {
                int i = -1;
                while (_Peoples[++i].GetName != CbPeople.SelectedValue.ToString()) ;
                int j = -1;
                while (_Levels[++j].GetName != CbLevel.SelectedValue.ToString()) ;
                _Char = new Character(_Peoples[i], new StartLevel(_Levels[j]), _Qualities);
                _Char.ApplyModificators();
				_Char.UseBaseQuality();
				TxtbPav.DataContext = _Char.GetLevel;
				TxtbQualPtns.DataContext = _Char.GetLevel;
				CbCulture.Visibility = Visibility.Visible;
				CkbCulture.Visibility = Visibility.Visible;	
				for (int k = 0; k < _Char.GetChoosableCultures.Count; k++)
                {
                    CbCulture.Items.Add(_Char.GetChoosableCultures[k]);
                }

                if (_Peoples[i].GetChoosableModificators != null)
                {
                    ChooseQuality _ChooseQual = new ChooseQuality(_Peoples[i].GetChoosableModificators);
                    _ChooseQual.ShowDialog();
                    if (_ChooseQual.DialogResult == true)
                    {
                        _Char.ChooseQualityModificator(_ChooseQual.ReturnValue);
                    }
                }
            }
        }

        private void CbLevel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CbPeople.Visibility = Visibility.Visible;
            foreach (People p in _Peoples)
            {
                CbPeople.Items.Add(p.GetName);
            }
		}

        private void CbCulture_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = -1;
            while (_Cultures[++i].GetName != CbCulture.SelectedValue.ToString()) ;
            _Char.ChooseCulture(_Cultures[i]);

            foreach (Quality q in _Qualities)
            {
                QualityIncrementor qualinc = new QualityIncrementor(q.GetValue(), q.GetSigle, q.GetColor, _Char.GetLevel.GetMaxQualityValue);
                qualinc.BtnAdd.Click += (source, ev) =>
                {
                    try
                    {
                        if (_Char.ModifyQuality(q.GetSigle))
                        {
                            qualinc.IncValue();
                            TxtbPav.Text = _Char.GetLevel.GetPAVString;
							TxtbQualPtns.Text = _Char.GetLevel.GetQualityPointsString;
						}
                    }
                    catch (Exception ex)
                    {

                    }
                };
                qualinc.BtnDown.Click += (source, ev) =>
                {
                    try
                    {
                        if (_Char.DecreaseQuality(q.GetSigle))
                        {
                            qualinc.DecValue();
                            TxtbPav.Text = _Char.GetLevel.GetPAVString;
							TxtbQualPtns.Text = _Char.GetLevel.GetQualityPointsString;
						}
                    }
                    catch (Exception ex)
                    {

                    }
                };
                StpQual.Children.Add(qualinc);
                _Qualinc.Add(qualinc);
            }
        }

		/*
		* CheckBox
		*/

		private void CkbCulture_Click(object sender, RoutedEventArgs e)
		{
			if (CkbCulture.IsChecked == true)
			{
				this._Char.ApplyCulturalBagage();
				TxtbPav.Text = _Char.GetLevel.GetPAVString;
				AffCharComp();
			}
		}

		/*
		*
		*/
		public void AffCharComp()
		{
			if (LtvComp.Items.Count > 0)
				LtvComp.Items.Clear();
			GridView gridView = new GridView();

			LtvComp.View = gridView;
			gridView.Columns.Add(new GridViewColumn
			{
				Header = "Compétence",
				DisplayMemberBinding = new Binding("GetName"),
				Width = ((LtvComp.Width / 4) - 2) * 3
			});
			gridView.Columns.Add(new GridViewColumn
			{
				Header = "Niveau",
				DisplayMemberBinding = new Binding("GetValue"),
				Width = ((LtvComp.Width / 4) - 5)
			});
			// Populate list
			foreach (Competence c in this._Char.GetComp)
			{
				LtvComp.Items.Add(c);
			}
		}
	}
}
