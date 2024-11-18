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

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Board board;
        private Board.Player currentPlayer;
        private bool gameOver;
        int gamesTotal = 0;
        int x = 0;
        int o = 0;


        public MainWindow()
        {
            InitializeComponent();

            var symbolsWindows = new SymbolsWindow();
            if (symbolsWindows.ShowDialog() == true)
            {
                currentPlayer = symbolsWindows.Symbol;
                board = new Board();
                gameOver = false;
            }
            else
            {
                Close(); 
            }

        }

        private void cell_Click(object sender, RoutedEventArgs e)
        {
            if (gameOver)
            {
                return;
            }

            var button = (Button)sender;
            var row = Grid.GetRow(button);
            var col = Grid.GetColumn(button);



            if (board.Select(row, col, currentPlayer))
            {
                var image = new Image();
                if (currentPlayer == Board.Player.X)
                {
                    image.Source = new BitmapImage(new Uri("Images/tic-tac-toe_x.png", UriKind.Relative));
                }
                else if (currentPlayer == Board.Player.O)
                {
                    image.Source = new BitmapImage(new Uri("Images/tic-tac-toe_o.png", UriKind.Relative));
                }
                button.Content = image;


                var winner = board.CheckWin();
                if (winner != Board.Player.None)
                {
                    MessageBox.Show($"Player {winner} wins!");
                    gameOver = true;
                    gamesTotal++;

                    if (winner == Board.Player.X)
                    {
                        x++;
                        
                    }
                    else
                    {
                        o++;
                       
                    }
                }

                if (currentPlayer == Board.Player.X)
                {
                    currentPlayer = Board.Player.O;
                }
                else
                {
                    currentPlayer = Board.Player.X;
                }


               
            }
        }
       
    }
}
