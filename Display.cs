using System;
using System.Collections.Generic;
using System.Text;

namespace Connect4
{
    class Display
    {
        private String[,] gameBoard;
        private int steps;
        public Display()
        {
            // sets a new game board up for use
            gameBoard = new String[7, 6] {
                { " ", " ", " ", " ", " ", " " },
                { " ", " ", " ", " ", " ", " " },
                { " ", " ", " ", " ", " ", " " },
                { " ", " ", " ", " ", " ", " " },
                { " ", " ", " ", " ", " ", " " },
                { " ", " ", " ", " ", " ", " " },
                { " ", " ", " ", " ", " ", " " }
            };
            // displays board on start
            updateDisplay();
        }
        public void updateDisplay()
        {
            Console.WriteLine("| {5} | {11} | {17} | {23} | {29} | {35} | {41} |\n" +
                               "| {4} | {10} | {16} | {22} | {28} | {34} | {40} |\n" +
                               "| {3} | {9} | {15} | {21} | {27} | {33} | {39} |\n" +
                               "| {2} | {8} | {14} | {20} | {26} | {32} | {38} |\n" +
                               "| {1} | {7} | {13} | {19} | {25} | {31} | {37} |\n" +
                               "| {0} | {6} | {12} | {18} | {24} | {30} | {36} |\n" +
                               "----------------------------\n" +
                               "| 1 | 2 | 3 | 4 | 5 | 6 | 7 |",
                gameBoard[0, 0], gameBoard[0, 1], gameBoard[0, 2], gameBoard[0, 3], gameBoard[0, 4], gameBoard[0, 5],
                gameBoard[1, 0], gameBoard[1, 1], gameBoard[1, 2], gameBoard[1, 3], gameBoard[1, 4], gameBoard[1, 5],
                gameBoard[2, 0], gameBoard[2, 1], gameBoard[2, 2], gameBoard[2, 3], gameBoard[2, 4], gameBoard[2, 5],
                gameBoard[3, 0], gameBoard[3, 1], gameBoard[3, 2], gameBoard[3, 3], gameBoard[3, 4], gameBoard[3, 5],
                gameBoard[4, 0], gameBoard[4, 1], gameBoard[4, 2], gameBoard[4, 3], gameBoard[4, 4], gameBoard[4, 5],
                gameBoard[5, 0], gameBoard[5, 1], gameBoard[5, 2], gameBoard[5, 3], gameBoard[5, 4], gameBoard[5, 5],
                gameBoard[6, 0], gameBoard[6, 1], gameBoard[6, 2], gameBoard[6, 3], gameBoard[6, 4], gameBoard[6, 5]);
        }
        public void addPiece(Boolean isPlayerOne, int choice)
        {
            String piece = ""; // deciding which piece to use
            if (isPlayerOne == true)
            {
                piece = "X";
            }
            else
            {
                piece = "O";
            }
            // adding piece to board
            int k = choice - 1;
            steps = 0;
            for (int i = 0; i < 6; i++)
            {
                steps++;
                if (gameBoard[k, i] == " ")
                {
                    gameBoard[k, i] = piece;
                    i = 7;
                }
            }
        }
        public void showWinningBoard(int[,] winner)
        {
            for (int i = 0; i < 7; i++)
            {
                for (int k = 0; k < 6; k++)
                {
                    if (winner[i, k] == 1) gameBoard[i, k] = "W";
                }
            }
        }
        public String[,] getBoard()
        {
            return this.gameBoard;
        }
        public int getSteps()
        {
            return this.steps;
        }
    }
}
