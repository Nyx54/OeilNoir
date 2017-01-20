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
    /// Logique d'interaction pour CharacterSheet.xaml
    /// </summary>
    public partial class CharacterSheet : Window
    {
        public CharacterSheet()
        {
            InitializeComponent();
        }

        public CharacterSheet(Character _Char)
        {
            InitializeComponent();
        }
    }
}
