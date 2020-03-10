using System;

namespace Connect4 {
    class UsrInput {
        public int askChoice (Boolean isPlayerOne) {
            String p = "";
            if (isPlayerOne == true) {
                p = "Player One";
            } else {
                p = "Player Two";
            }
            Boolean isNum = false;
            int choice = 0;
            while (isNum == false) {
                Console.WriteLine (p + " please make a choice!");
                String a = Console.ReadLine ();
                isNum = int.TryParse (a, out choice);
                if (isNum == false) Console.Write ("That's not a number! Try again!");
                if (isNum == true && choice > 7) {
                    Console.WriteLine ("Number is too big! Try again!");
                    isNum = false;
                }
            }
            return choice;
        }
    }
}