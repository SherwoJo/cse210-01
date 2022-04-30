/* Program Name: Tic-Tac-Toe Game
   Author: Jordan Sherwood
*/

using System;
using System.Collections.Generic;

namespace cse210_01
{
    class Program
    {
        static void Main(string[] args)
        {
            // Introduce the game to the user.
            Console.WriteLine("Let's play tic-tac-toe! Get three in a row to win!");

            // Create and display the initial game board.
            List<char> gameBoard = new List<char> {'1', '2', '3', '4', '5', '6', '7', '8', '9'};
            drawGameBoard(gameBoard);

            // Start the main gameplay loop
            bool gameOver = false;
            char currentPlayer = 'X';
            int turnCounter = 0;
            while (!gameOver)
            {
                // Ask for the first move.
                Console.Write($"{currentPlayer}'s turn to choose a square (1-9): ");
                string userInput = Console.ReadLine();

                // Convert the chosen square into an index and replace that index
                // with the symbol of the current player.
                int chosenSquareIndex = int.Parse(userInput) - 1;
                gameBoard[chosenSquareIndex] = currentPlayer;

                // Display the updated game board
                drawGameBoard(gameBoard);

                // Check the board for a three in a row.
                gameOver = detectWin(gameBoard);

                // Declare the winner if there is one.
                if (gameOver)
                {
                    char winner = currentPlayer;
                    Console.WriteLine($"Congratulations! The winner is {winner}!");
                }
                else if (turnCounter == 8) // If turnCounter is 8, the board is full and the game is a draw.
                {
                    gameOver = true;
                    Console.WriteLine("Cat's game!");
                }

                // Change the turn to the other player.
                if (currentPlayer == 'X')
                {
                    currentPlayer = 'O';
                }
                else
                {
                    currentPlayer = 'X';
                }
                
                // Increment the turnCounter.
                turnCounter++;
            }
        }

        static void drawGameBoard(List<char> gameBoard)
        {
            /*
            This function takes a list of strings as an argument
            ans displays the elements of the list in a 3x3 grid
            seperated by lines which make it appear like the
            tic-tac-toe game board.
            */
            Console.WriteLine($" {gameBoard[0]} | {gameBoard[1]} | {gameBoard[2]} ");
            Console.WriteLine($"---+---+---");
            Console.WriteLine($" {gameBoard[3]} | {gameBoard[4]} | {gameBoard[5]} ");
            Console.WriteLine($"---+---+---");
            Console.WriteLine($" {gameBoard[6]} | {gameBoard[7]} | {gameBoard[8]} ");            
        }

        static bool detectWin(List<char> gameBoard)
        {
            bool gameOver = false;

            // Check each row, column, and diagonal for three of a kind.
            // Rows
            if (gameBoard[0] == gameBoard[1] && gameBoard[1] == gameBoard[2]) // Row 1
            {
                gameOver = true;
            }
            else if (gameBoard[3] == gameBoard[4] && gameBoard[4] == gameBoard[5]) // Row 2
            {
                gameOver = true;
            }
            else if (gameBoard[6] == gameBoard[7] && gameBoard[7] == gameBoard[8]) // Row 3
            {
                gameOver = true;
            }

            // Columns
            else if (gameBoard[0] == gameBoard[3] && gameBoard[3] == gameBoard[6]) // Column 1
            {
                gameOver = true;
            }
            else if (gameBoard[1] == gameBoard[4] && gameBoard[4] == gameBoard[7]) // Column 2
            {
                gameOver = true;
            }
            else if (gameBoard[2] == gameBoard[5] && gameBoard[5] == gameBoard[8]) // Column 3
            {
                gameOver = true;
            }

            // Diagonals
            else if (gameBoard[0] == gameBoard[4] && gameBoard[4] == gameBoard[8]) // Diagonal 1
            {
                gameOver = true;
            }
            else if (gameBoard[2] == gameBoard[4] && gameBoard[4] == gameBoard[6]) // Diagonal 2
            {
                gameOver = true;
            }

            return gameOver;
        }
    }

}
