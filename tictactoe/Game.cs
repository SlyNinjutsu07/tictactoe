using System;
using System.Collections.Generic;
using static System.Console;

public class Game{

    private char[,] board;
    public bool turn; //True = 'X'
                       //False = 'O'

    public Game(){
        board = new char[3,3];

        turn = false;

        int i = 1;

        for(int r = 0; r < board.GetLength(0); r++){
            for(int c = 0; c < board.GetLength(1); c++){
                board[r,c] = Convert.ToChar(new string(i.ToString()));
                i++;
            }
        }
    }

    public void printBoard(){
        for(int r = 0; r < board.GetLength(0); r++){
            for(int c = 0; c < board.GetLength(1); c++){
                if(board[r,c] == 'X'){
                    ForegroundColor = ConsoleColor.Red;
                    Write($"[{board[r,c]}] ");
                    ForegroundColor = ConsoleColor.White;
                } else if(board[r,c] == 'O'){
                    ForegroundColor = ConsoleColor.Green;
                    Write($"[{board[r,c]}] ");
                    ForegroundColor = ConsoleColor.White;
                } else
                    Write($"[{board[r,c]}] ");
                
            }
            WriteLine();
        }
    }

    public void setBoard(int num){
        for(int r = 0; r < board.GetLength(0); r++){
            for(int c = 0; c < board.GetLength(1); c++){
                //int temp = Convert.ToInt32(new string(board[r,c], 1));
                if(int.TryParse(new string(board[r,c], 1), out int temp)){
                    if(temp == num){
                        board[r,c] = PlayerChar;
                        return;
                    }
                }
            }
        }

    }

    public bool checkForWin(){
        List<char> tempList = new List<char>();

        #region Diagonals
        //Add from left to right
        for(int r = 0; r < board.GetLength(0); r++)
            tempList.Add(board[r,r]);

        if(isAllEqual(tempList))
            return true;
        tempList.Clear();
        //Add from right to left
        for(int r = board.GetLength(0) - 1; r >= 0; r--)
            tempList.Add(board[r,r]);

        if(isAllEqual(tempList))
            return true;
        tempList.Clear();
        #endregion

        #region Horizontals
        //Top Row
        addToList(tempList, 0, false);
        if(isAllEqual(tempList))
            return true;
        tempList.Clear();
        //Middle Row
        addToList(tempList, 1, false);
        if(isAllEqual(tempList))
            return true;
        tempList.Clear();
        //Bottom Row
        addToList(tempList, 2, false);
        if(isAllEqual(tempList))
            return true;
        tempList.Clear();
        #endregion

        #region Verticals
        //First Col
        addToList(tempList, 0, true);
        if(isAllEqual(tempList))
            return true;
        tempList.Clear();
        //Second Col
        addToList(tempList, 1, true);
        if(isAllEqual(tempList))
            return true;
        tempList.Clear();
        //Third Col
        addToList(tempList, 2, true);
        if(isAllEqual(tempList))
            return true;
        tempList.Clear();

        #endregion

        return false;
    }

    #region Helper Methods
    //Checks if all values in the list are equal to one another
    public bool isAllEqual(List<char> charList){
        for(int i = 1; i < charList.Count; i++){
            if(charList[i - 1] != charList[i])
                return false;
        }
        
        return true;
    }

    //Adds values to list, can choose if you want by row (isVertical = false) or by col (isVertical = true)
    public void addToList(List<char> list, int index, bool isVertical){
        if(isVertical){
            for(int r = 0; r < board.GetLength(0); r++)
                list.Add(board[r,index]);
        }
        else{
            for(int c = 0; c < board.GetLength(1); c++)
                list.Add(board[index,c]);
        }
    }
    #endregion

    #region Properties
    private char PlayerChar{
        get{
            if(turn)
                return 'X';
            else
                return 'O';
        }
    }

    public string Player{
        get{
            if(turn)
                return "Player 1";
            else
                return "Player 2";
        }
    }
    #endregion
}
