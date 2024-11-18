using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;



namespace TicTacToe
{



    public class Board
    {
        private Player[,] board;
        
        public enum Player
    {
        None,
        X,
        O
    }

        public Board()
        {
            board = new Player[3, 3];
        }

        public bool Select(int row, int col, Player player)
        {
            if (row < 0 || row >= 3 || col < 0 || col >= 3 || board[row, col] != Player.None)
            {
                return false;
            }

            board[row, col] = player;
            return true;
        }

        public Player CheckWin()
        {
            // Checks to see if row win occured
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                {
                    return board[i, 0];
                }

                // Checks to see if column win occured
                if (board[0, i] == board[1, i] && board[1, i] == board[2, i])
                {
                    return board[0, i];
                }
            }

            // Check to see if diagonal win occured
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                return board[0, 0];
            }

            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                return board[0, 2];
            }

            return Player.None; // No win
        }

       
    }


}

