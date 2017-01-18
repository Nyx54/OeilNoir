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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<Quality> _Qualities = new List<Quality>();
            /*
             * Load People 
             */
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(DataResources.Qualities);
            XmlNode root = doc.FirstChild;

            if (root.HasChildNodes)
            {
                for (int i = 0; i < root.ChildNodes.Count; i++)
                {
                    Quality q = new Quality(root.ChildNodes[i].ChildNodes[0].InnerText, root.ChildNodes[i].ChildNodes[1].InnerText, root.ChildNodes[i].ChildNodes[2].InnerText);
                    _Qualities.Add(q);
                }
            }
            /*
             * Load Culture 
             */
             
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreaPerso _CreaPerso = new CreaPerso();
            _CreaPerso.Show();
        }
    }
}
