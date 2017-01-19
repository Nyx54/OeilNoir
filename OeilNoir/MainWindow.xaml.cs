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
                                                    Convert.ToInt32(rootlvl.ChildNodes[i].ChildNodes[6].InnerText), rootlvl.ChildNodes[i].ChildNodes[7].InnerText);
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
                    Quality q = new Quality(rootqual.ChildNodes[i].ChildNodes[0].InnerText, rootqual.ChildNodes[i].ChildNodes[1].InnerText, rootqual.ChildNodes[i].ChildNodes[2].InnerText);
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
                        _comp.Add(rootcult.ChildNodes[i].ChildNodes[2].ChildNodes[j].ChildNodes[0].InnerText, Convert.ToInt32(rootcult.ChildNodes[i].ChildNodes[2].ChildNodes[j].ChildNodes[1].InnerText));
                    }
                    Culture c = new Culture(rootcult.ChildNodes[i].ChildNodes[0].InnerText, Convert.ToInt32(rootcult.ChildNodes[i].ChildNodes[1].InnerText), _comp);
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
                        _compqualities.Add(rootpeople.ChildNodes[i].ChildNodes[6].ChildNodes[j].ChildNodes[0].InnerText, Convert.ToInt32(rootpeople.ChildNodes[i].ChildNodes[6].ChildNodes[j].ChildNodes[1].InnerText));
                    }
                    Dictionary<string, int> _chosqualities = new Dictionary<string, int>();
                    for (int k = 0; k < rootpeople.ChildNodes[i].ChildNodes[7].ChildNodes.Count; k++)
                    {
                        _chosqualities.Add(rootpeople.ChildNodes[i].ChildNodes[7].ChildNodes[k].ChildNodes[0].InnerText, Convert.ToInt32(rootpeople.ChildNodes[i].ChildNodes[7].ChildNodes[k].ChildNodes[1].InnerText));
                    }
                    List<Culture> _choscults = new List<Culture>();
                    People p = new People(rootpeople.ChildNodes[i].ChildNodes[0].InnerText, Convert.ToInt32(rootpeople.ChildNodes[i].ChildNodes[1].InnerText), Convert.ToInt32(rootpeople.ChildNodes[i].ChildNodes[2].InnerText),
                        Convert.ToInt32(rootpeople.ChildNodes[i].ChildNodes[3].InnerText), Convert.ToInt32(rootpeople.ChildNodes[i].ChildNodes[4].InnerText), Convert.ToInt32(rootpeople.ChildNodes[i].ChildNodes[5].InnerText),
                        _compqualities, _chosqualities, _choscults);
                    _Peoples.Add(p);
                }
            }


            /*
            Dictionary<string, int> BardeComp = new Dictionary<string, int>();
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
            MessageBox.Show(c.ToString());
             * */
        }

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

        private void CbPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_Char == null)
            {
                int i = -1;
                while (_Peoples[++i].GetName != CbPeople.SelectedValue.ToString()) ;
                int j = -1;
                while (_Levels[++j].GetName != CbLevel.SelectedValue.ToString()) ;
                _Char = new Character(_Peoples[i], _Levels[j]);
                _Char.ApplyModificators();
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
                DisplayMemberBinding = new Binding("GetCulturalBaggage"),
                Width = ((Ltv.Width / 5) - 2) * 2
            });
            // Populate list
            foreach (Culture c in _Cultures)
            {
                Ltv.Items.Add(c);
            }
        }
    }
}
