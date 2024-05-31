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
                Write($"[{board[r,c]}] ");
            }
            WriteLine();
        }
    }

    public void setBoard(int num){
        for(int r = 0; r < board.GetLength(0); r++){
            for(int c = 0; c < board.GetLength(1); c++){
                int temp = Convert.ToInt32(new string(board[r,c], 1));
                if(temp == num){
                    board[r,c] = PlayerChar;
                    return;
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
        
        //Add from right to left
        for(int r = board.GetLength(0) - 1; r >= 0; r--)
            tempList.Add(board[r,r]);

        if(isAllEqual(tempList))
            return true;
        #endregion

        #region Horizontals
        //Top Row
        addToList(tempList, 0, false);
        if(isAllEqual(tempList))
            return true;
        //Middle Row
        addToList(tempList, 1, false);
        if(isAllEqual(tempList))
            return true;
        //Bottom Row
        addToList(tempList, 2, false);
        if(isAllEqual(tempList))
            return true;
        #endregion

        #region Verticals
        //First Col
        addToList(tempList, 0, true);
        if(isAllEqual(tempList))
            return true;
        //Second Col
        addToList(tempList, 1, true);
        if(isAllEqual(tempList))
            return true;
        //Third Col
        addToList(tempList, 2, true);
        if(isAllEqual(tempList))
            return true;

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
    public char PlayerChar{
        get{
            if(turn)
                return 'X';
            else
                return 'O';
        }
    }
    #endregion
}