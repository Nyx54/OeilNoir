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
using System.Windows.Shapes;

namespace OeilNoir
{
    /// <summary>
    /// Interaction logic for ChooseQuality.xaml
    /// </summary>
    public partial class ChooseQuality : Window
    {
        public string ReturnValue { get; set; } 

        public class Modificator
        {
            string _Name;
            int _Value;

            public Modificator()
            {
                this._Name = "";
                this._Value = 0;
            }

            public Modificator(string name, int value)
            {
                this._Name = name;
                this._Value = value;
            }

            public string GetName
            {
                get
                {
                    return this._Name;
                }
            }

            public int GetValue
            {
                get
                {
                    return this._Value;
                }
            }
            public override string ToString()
            {
                return (this._Name);
            }
        }


        public ChooseQuality(Dictionary<string, int> Modificators)
        {
            InitializeComponent();

            if (Ltv.Items.Count > 0)
                Ltv.Items.Clear();
            GridView gridView = new GridView();

            Ltv.View = gridView;
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Qualité",
                DisplayMemberBinding = new Binding("GetName"),
                Width = ((Ltv.Width / 4) - 2) * 2
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Modification",
                DisplayMemberBinding = new Binding("GetValue"),
                Width = ((Ltv.Width / 4) - 5) * 2
            });
            // Populate list
            foreach (KeyValuePair<string, int> kvp in Modificators)
            {
                Modificator _Mod = new Modificator(kvp.Key, kvp.Value);
                Ltv.Items.Add(_Mod);
            }
        }

        private void Btn_Validate_Click(object sender, RoutedEventArgs e)
        {
            if (Ltv.SelectedItems.Count > 0)
            {
                this.ReturnValue = Ltv.SelectedItems[0].ToString();
                this.DialogResult = true;
                this.Close();
            }
        }
    }
}
