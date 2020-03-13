using System;
namespace Connect4 {
    public class AI {
        private int[, ] gb;
        private int xL;
        private int yL;
        private Boolean isAI;
        private int[, ] winningColumn;
        private int[, ] winningRow;
        private int[, ] winningDiagL;
        private int[, ] winningDiagR;
        public void startAI (int[, ] gb) {
            this.gb = gb;
            isAI = true; // set to AI
            checkWin (); // first we check if we can win the game this turn
        }
        private Boolean checkWin () {
            xL = gb.GetLength (0); // finding the length x width
            yL = gb.GetLength (1); // this will tell us our max in the search alg
            winningColumn = new int[xL, yL];
            winningRow = new int[xL, yL];
            winningDiagL = new int[xL, yL];
            winningDiagR = new int[xL, yL];
            Boolean canWin = false;
            while (canWin == false) {
                // check if AI can win
                if (checkColumns () == true || checkRows () == true || checkDiag () == true) {
                    canWin = true;
                }
            }
            return canWin;
        }
        private Boolean checkColumns () {
            Boolean cW = false;
            int wL = 0;
            int n = 0;
            // set piece we are looking for
            if (isAI == true) {
                n = 2;
            } else {
                n = 1;
            }
            if (cW == false) {
                for (int i = 0; i < xL; i++) { // iterating each x value
                    for (int k = 0; k < yL; k++) { // iterating each y value
                        if (gb[i, k] == n) { // check to see if it has our piece
                            wL++; // add one to the winning Line if it matches
                            winningColumn[i, k] = 1;
                        } else {
                            winningColumn[i, k] = 0;
                            wL = 0; // reset if it doesn't
                        }
                        // check if we have a potential win
                        if (wL == 3) {
                            cW = true;
                            k = 10000; // to break out of loop
                            i = 10000;
                        }
                    }
                }
            }
            return cW;
        }
        private Boolean checkRows () {
            Boolean cW = false;
            int wL = 0;
            int n = 0;
            // set piece we are looking for
            if (isAI == true) {
                n = 2;
            } else {
                n = 1;
            }
            if (cW == false) {
                for (int i = 0; i < yL; i++) { // iterating each y value
                    for (int k = 0; k < xL; k++) { // iterating each x value
                        if (gb[k, i] == n) { // check to see if it has our piece
                            wL++; // add one to the winning Line if it matches
                            winningRow[k, i] = 1;
                        } else {
                            winningRow[k, i] = 0;
                            wL = 0; // reset if it doesn't
                        }
                        // check if we have a potential win
                        if (wL == 3) {
                            cW = true;
                            k = 10000; // to break out of loop
                            i = 10000;
                        }
                    }
                }
            }
            return cW;
        }
        private Boolean checkDiag () {
            // set piece
            int n = 0;
            if (isAI == true) {
                n = 2;
            } else {
                n = 1;
            }
            int wL = 0;
            Boolean cW = false;
            // minimum starting point to get a win on left diagonal is 0,3
            // max point for lower diagonal is  0,(yL-1)
            // min starting point for upper diagonal is 1,(yL-1)
            // max point for upper diagonal is (xL-4),(yL-1)
            // ex: if our board is 7x6 our max would be (7-4),(6-1) or 3,5
            int minY = 3;
            int maxY = yL - 1;
            int minupdx = 1;
            int maxupdx = xL - 4;
            // first we check left diagonals
            // start with lower diagonals
            int x = 0;
            int y = minY;
            for (int i = 0; i < (yL - minY); i++) {
                int tY = y; // need to store the values so we can manipulate in while loop
                int tX = x;
                while (tX != (xL - 1) && tY != 0) { // this will break out when it reaches the bottom of the diag
                    if (gb[x, tY] == n) {
                        wL++;
                        winningDiagL[x, tY] = 1;
                    } else {
                        wL = 0;
                        winningDiagL[x, tY] = 0;
                    }
                    if (wL == 3) { // if we get 3 in a row then we found a potential win
                        cW = true;
                        tX = xL - 1; // so we break out of the loop
                        tY = 0;
                    }
                    tX++; // move one to the right
                    tY--; // then down one
                }
                y++; // after we check a diagonal and don't find anything, start one point higher
            }
            // next upper left diagonals
            x = minupdx;
            y = maxY;
            for (int i = 0; i < maxupdx; i++) { // iterates upper diagonals 1,(yL-1) through (xL-4),(yL-1)
                int tX = x;
                int tY = y;
                while (tX == xL && tY != 0) {
                    if (gb[tX, tY] == n) {
                        wL++;
                        winningDiagL[tX, tY] = 1;
                    } else {
                        wL = 0;
                        winningDiagL[tX, tY] = 0;
                    }
                    if (wL == 3) {
                        cW = true;
                        tX = xL - 1;
                        tY = 0;
                    }
                    tX++;
                    tY--;
                }
                x++;
            }
            // minimum starting point to get a win on right diagonal is (xL-1),3
            // max point for lower diagonal is (xL-1),(yL-1)
            // min starting point for upper diagonal is (xL-2),(yL-1)
            // max point for upper diagonal is 3,(yL-1)
            // ex: if our board is 7x6 our max would be 3,(6-1) or 3,5
            minY = 3;
            maxY = yL - 1;
            minupdx = xL - 2;
            maxupdx = 3;
            // check right diagonals
            // start with the lower diagonals
            x = xL - 1;
            y = minY;
            for (int i = 0; i < (yL - 1); i++) {
                int tY = y;
                int tX = x;
                while (tX != 0 && tY != 0) {
                    if (gb[tX, tY] == n) {
                        wL++;
                        winningDiagR[tX, tY] = 1;
                    }
                } 
            }
            return cW;
        }
    }
}