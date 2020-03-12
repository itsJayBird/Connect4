using System;

namespace Connect4 {
    class Logic {
        private Display gb;
        private UsrInput ui;
        private Boolean isPlayerOne;
        private int c;
        private String[, ] board;
        private int[, ] p1;
        private int[, ] p2;
        private Boolean winDecided;
        private String winner;
        private int turn;
        private int[, ] winningLine;

        public void startGame () {
            gb = new Display ();
            ui = new UsrInput ();
            setPlayerBoards ();
            isPlayerOne = true;
            winDecided = false;
            turn = 0;
            while (winDecided == false) {
                Console.Clear ();
                gb.updateDisplay ();
                c = ui.askChoice (isPlayerOne);
                if (c == 69) {
                    demoMode ();
                } else {
                    Boolean canAdd = gb.addPiece (isPlayerOne, c);
                    while (canAdd == false) {
                        c = ui.askChoice (isPlayerOne);
                        canAdd = gb.addPiece (isPlayerOne, c);
                    }
                    board = gb.getBoard ();
                    int steps = gb.getSteps ();
                    addPiece (isPlayerOne, c, steps);
                    Console.Clear ();
                    gb.updateDisplay ();
                    checkWin (c, steps, isPlayerOne);
                    changePlayer (isPlayerOne);
                    turn++;
                    if (turn == 42) winDecided = true;
                    if (winDecided == true) displayWinner ();
                }

            }
        }
        private void checkWin (int c, int s, Boolean player) {
            int[, ] a = new int[1, 1];
            if (player == true) {
                a = p1;
            } else {
                a = p2;
            }
            int x = c - 1;
            int y = s - 1;
            if (winDecided == false) { // check row of choice for win
                winningLine = new int[7, 6];
                int line = 0;
                for (int i = 0; i < 7; i++) {
                    if (a[i, y] == 1) {
                        line++;
                        winningLine[i, y] = 1;
                    } else {
                        line = 0;
                        winningLine = new int[7, 6];
                    }
                    if (line == 4) {
                        i = 7;
                        winDecided = true;
                    }
                }
            }
            if (winDecided == false) { // check column of choice for win
                winningLine = new int[7, 6];
                int line = 0;
                for (int i = 0; i < 6; i++) {
                    if (a[x, i] == 1) {
                        line++;
                        winningLine[x, i] = 1;
                    } else {
                        line = 0;
                        winningLine = new int[7, 6];
                    }
                    if (line == 4) {
                        i = 6;
                        winDecided = true;
                    }
                }
            }
            if (winDecided == false) { // check for right diagonal
                winningLine = new int[7, 6];
                // determine the starting point
                int z = x; // place holders so we do not modify the original inputs
                int w = y;
                while (z != 0 && w != 0) // this will find our starting point, once the X value is 0 it breaks out of the loop
                { // and we can use these to start our search
                    z--;
                    w--;
                }
                int line = 0;
                for (int i = w; i < 6; i++) { // iterate through every diagonal to the right of the starting point
                    if (a[z, i] == 1) {
                        line++;
                        winningLine[z, i] = 1;
                    } else {
                        line = 0;
                        winningLine = new int[7, 6];
                    }
                    if (line == 4) // this check runs every iteration to see if 4 has been matched
                    {
                        winDecided = true;
                        i = 6;
                    }
                    z++;
                    if (z >= 7) i = 7;

                }
            }
            if (winDecided == false) { // check for left diagonal
                winningLine = new int[7, 6];
                // determine the starting point
                int z = x; // using placeholders again
                int w = y;
                while (w != 0 && z != 0) {
                    z++;
                    w--;
                    if (z > 6) z = 6;
                }
                int line = 0;
                for (int i = w; i < 6; i++) {
                    if (a[z, i] == 1) {
                        line++;
                        winningLine[z, i] = 1;
                    } else {
                        line = 0;
                        winningLine = new int[7, 6];
                    }
                    if (line == 4) {
                        winDecided = true;
                        i = 6;
                    }
                    z--;
                    if (z < 0) i = 7;
                }
            }
            if (winDecided == true) {
                if (player == true) {
                    winner = "Player One";
                } else {
                    winner = "Player Two";
                }
            }
        }
        private void addPiece (Boolean player, int ch, int st) {
            if (player == true) {
                st--;
                ch--;
                p1[ch, st] = 1;
            } else {
                st--;
                ch--;
                p2[ch, st] = 1;
            }
        }
        private void displayWinner () {
            gb.showWinningBoard (winningLine);
            if (turn != 42) {
                Console.Clear ();
                gb.updateDisplay ();
                Console.WriteLine ("{0} has won the match in {1} turns!", winner, turn);
            } else {
                Console.WriteLine ("Tie Game!");
            }

        }
        private void changePlayer (Boolean player) {
            if (player == true) {
                isPlayerOne = false;
            } else {
                isPlayerOne = true;
            }
        }

        // demo mode will fill pieces in at random
        private void demoMode () {
            Random r = new Random ();
            while (winDecided == false) {
                Console.Clear ();
                gb.updateDisplay ();
                c = r.Next (1, 8);
                Boolean canAdd = gb.addPiece (isPlayerOne, c);
                while (canAdd == false) {
                    c = r.Next (1, 8);
                    canAdd = gb.addPiece (isPlayerOne, c);
                }
                board = gb.getBoard ();
                int steps = gb.getSteps ();
                addPiece (isPlayerOne, c, steps);
                Console.Clear ();
                gb.updateDisplay ();
                checkWin (c, steps, isPlayerOne);
                changePlayer (isPlayerOne);
                turn++;
                Console.WriteLine ("Turn: " + turn);
                System.Threading.Thread.Sleep (100);
                if (turn == 42) winDecided = true;
                if (winDecided == true) displayWinner ();
            }
        }
        private void setPlayerBoards () {
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