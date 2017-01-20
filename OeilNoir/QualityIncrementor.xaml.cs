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

namespace OeilNoir
{
    /// <summary>
    /// Logique d'interaction pour QualityIncrementor.xaml
    /// </summary>
    public partial class QualityIncrementor : UserControl
    {
        int _Value;
        string _Name;
        string _Color;
        int _MaxQualValue;
        Dictionary<string, SolidColorBrush> _Colors = new Dictionary<string, SolidColorBrush>(); 

        public QualityIncrementor()
        {
            this._Value = 8;
            this._MaxQualValue = 0;
            this._Name = string.Empty;
            this._Color = string.Empty;
            this._Colors.Add("Rouge", Brushes.Red);
            this._Colors.Add("Orange", Brushes.Orange);
            this._Colors.Add("Vert", Brushes.Green);
            this._Colors.Add("Violet", Brushes.Purple);
            this._Colors.Add("Bleu", Brushes.Blue);
            this._Colors.Add("Jaune", Brushes.Yellow);
            this._Colors.Add("Noir", Brushes.Black);
            this._Colors.Add("Blanc", Brushes.White);
            InitializeComponent();
            TxtQual.Text = GetValueString;
        }

        public QualityIncrementor(int val, string name, string color, int maxqv)
        {
            this._Value = val;
            this._MaxQualValue = maxqv;
            this._Name = name;
            this._Color = color;
            this._Colors.Add("Rouge", Brushes.Red);
            this._Colors.Add("Orange", Brushes.Orange);
            this._Colors.Add("Vert", Brushes.Green);
            this._Colors.Add("Violet", Brushes.Purple);
            this._Colors.Add("Bleu", Brushes.Blue);
            this._Colors.Add("Jaune", Brushes.Yellow);
            this._Colors.Add("Noir", Brushes.Black);
            this._Colors.Add("Blanc", Brushes.White);
            InitializeComponent();
            TxtQual.Text = GetValueString;
            TxtName.Text = name;
            TxtName.Background = this._Colors[color];
            if (TxtName.Background == Brushes.Black)
            {
                TxtName.Foreground = Brushes.White;
            }
        }

        public int GetValue
        {
            get
            {
                return this._Value;
            }
        }

        public string GetValueString
        {
            get
            {
                return this._Value.ToString();
            }
        }


        public void IncValue()
        {
            this._Value++;
            TxtQual.Text = GetValueString;
        }

        public void DecValue()
        {
            this._Value--;
            TxtQual.Text = GetValueString;
        }
    }
}
