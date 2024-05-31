using System;

public class Program{

    public static void Main(string[] args){
        string startMessage = "Type \"start\" to begin:";
        string quitMessage = "Type \"quit\" to quit game:";
        Console.WriteLine(startMessage);

        Input:
        string? input = Console.ReadLine();
        try{
            if(input==null){
                Console.WriteLine(startMessage);
                goto Input;
            } 
        } catch(IOException){
            Console.Clear();
            goto Input;
        }

        Game game = new Game();

        while(!game.checkForWin()){
            game.turn = !game.turn;
            game.printBoard();

            Console.WriteLine(quitMessage + "\n");

            input = Console.ReadLine();
            if(input?.ToLower() == "quit") break;
            readInput(game, input);
        }    
    }

    public static void readInput(Game g, string? input){
        if(input == null){
            Console.WriteLine("No input found");
            g.turn = !g.turn;
            return;
        }

        try{
            int val = int.Parse(input);
            if(val > 9 && val <= 0){
                Console.WriteLine("Not a position");
                g.turn = !g.turn;
                return;
            }
            g.setBoard(val);
        } catch(Exception) { 
            Console.WriteLine("Not a number");
            g.turn = !g.turn;
            return;
        }
    }

}