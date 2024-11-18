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

namespace TicTacToe
{
   
    public partial class SymbolsWindow : Window
    {
        public Board.Player Symbol { get; private set; }
        public SymbolsWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender;

            if (button == XButton)
            {
                Symbol = Board.Player.X;
            }
            else
            {
                Symbol = Board.Player.O;
            }

            DialogResult = true;
        }
    }
}
