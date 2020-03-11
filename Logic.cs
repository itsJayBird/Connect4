using System;
using System.Collections.Generic;
using System.Text;

namespace Connect4
{
    class Logic
    {
        private Display gb;
        private UsrInput ui;
        private Boolean isPlayerOne;
        private int c;
        private String[,] board;
        private int[,] p1;
        private int[,] p2;
        private Boolean winDecided;

        public void startGame()
        {
            gb = new Display();
            ui = new UsrInput();
            setPlayerBoards();
            isPlayerOne = true;
            winDecided = false;
            while (winDecided == false)
            {
                c = ui.askChoice(isPlayerOne);
                gb.addPiece(isPlayerOne, c);
                changePlayer(isPlayerOne);
                board = gb.getBoard();
                int steps = gb.getSteps();
                checkWin(steps);
            }
        }
        private void checkWin(int s)
        {
            if (winDecided == false)
            {
                // first check columns for winning spots
                // loop will go until it finds 4 in a row in any column
                for (int i = 0; i < 6; i++)
                {
                    int win = 0; // sets up a counter for each one in a row
                    for (int k = 0; k < 5; i++)
                    {
                        if (p1[i, k] == 1)
                        {
                            win++; // adds if a spot has been claimed
                        }
                        else
                        {
                            win = 0; // resets if spot hasn't been claimed
                        }
                        if (win >= 4)
                        {
                            k = 6; // breaks loop once 4 in a row has been found
                            winDecided = true;
                        }
                    }
                    if (win >= 4) i = 7; // breaks loop if 4 found in a column
                }
            }
            if (winDecided == false)
            {
                // check rows for winning spots
                // uses same logic as columns
                for (int i = 0; i < 6; i++)
                {
                    int win = 0;
                    for (int k = 0; k < 5; k++)
                    {
                        if (p1[k, i] == 1)
                        {
                            win++;
                        }
                        else
                        {
                            win = 0;
                        }
                        if (win >= 4)
                        {
                            k = 6;
                            winDecided = true;
                        }
                    }
                    if (win >= 4) i = 7;
                }
            }
            if (winDecided == false)
            {
                // check diagonals 
                // first check the right diagonals
                int y = 5;
                int x;
                int z = 0;
                int inRow = 0;
                // this for loop checks corner through space 4
                for (int i = 0; i < 3; i++) 
                {
                    x = z;
                    for (int k = 0; k < y; k++)
                    {
                        if (p1[x, k] == 1)
                        {
                            inRow++;
                        }
                        else
                        {
                            inRow = 0;
                        }
                        if (inRow >= 4) k = 7;
                        x++;
                    }
                    if (z > 0) y--;
                    z++;
                    if (inRow >= 4) i = 3;
                }
                z = 1;
                y = 4;
                // this loop checks the two diagonals above corner
                for (int i = 0; i < 1; i++)
                {
                    x = z;
                    for (int k = 0; k < y; k++)
                    {
                        if (p1[k, x] == 1)
                        {
                            inRow++;
                        }
                        else
                        {
                            inRow = 0;
                        }
                        x++;
                        if (inRow >= 4) k = 5;
                    }
                    z++;
                    y--;
                    if (inRow >= 4) i = 3;
                }
                y = 5;
                z = 5;
                // checking right corner and the 3 before it
                for (int i = 0; i < 3; i++)
                {
                    x = z;
                    for (int k = 0; k < y; k++)
                    {
                        if (p1[x, k] == 1)
                        {
                            inRow++;
                        }
                        else
                        {
                            inRow = 0;
                        }
                        if (inRow >= 4) k = 7;
                        x--;
                    }
                    if (z < 5) y--;
                    z--;
                    if (inRow >= 4) i = 3;
                }
                z = 5;
                y = 5;
                // this loop checks the two diagonals above corner
                for (int i = 0; i < 1; i++)
                {
                    x = z;
                    for (int k = 1; k < y; k++)
                    {
                        if (p1[x, k] == 1)
                        {
                            inRow++;
                        }
                        else
                        {
                            inRow = 0;
                        }
                        x--;
                        if (inRow >= 4) k = 6;
                    }
                    y++;
                    if (inRow >= 4) i = 3;
                }
            }
        }
        private void changePlayer(Boolean player)
        {
            if (player == true)
            {
                isPlayerOne = false;
            }
            else
            {
                isPlayerOne = true;
            }
        }
        private void setPlayerBoards()
        {
            p1 = new int[7, 6] { 
                { 0, 0, 0, 0, 0, 0 }, 
                { 0, 0, 0, 0, 0, 0 }, 
                { 0, 0, 0, 0, 0, 0 }, 
                { 0, 0, 0, 0, 0, 0 }, 
                { 0, 0, 0, 0, 0, 0 }, 
                { 0, 0, 0, 0, 0, 0 }, 
                { 0, 0, 0, 0, 0, 0 }
            };
            p2 = new int[7, 6] { 
                { 0, 0, 0, 0, 0, 0 }, 
                { 0, 0, 0, 0, 0, 0 }, 
                { 0, 0, 0, 0, 0, 0 }, 
                { 0, 0, 0, 0, 0, 0 }, 
                { 0, 0, 0, 0, 0, 0 }, 
                { 0, 0, 0, 0, 0, 0 }, 
                { 0, 0, 0, 0, 0, 0 }
            };
        }
    }
}
