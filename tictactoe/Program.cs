using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace tictactoe
{
    /// <summary>
    /// Author: Lance Noble 
    /// Started: 3/11/2023 12 AM
    /// Finished: 
    /// This is an attempt at dynamically programming the win conditions for a tictactoe game
    /// So that the win conditions work for any square board dimensions
    /// Must also dynamically print the board
    /// Restriction: board must have perfectly square dimensions
    ///              otherwise, the diagonal checks will stop working
    ///              the checks were made for perfectly square diagonals
    /// Work left: have to dynamically program the printing of the board
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            // CODE: Make empty board

            // Restrict the board to only being perfectly square
            byte dimension = 3; 
            byte rows = dimension;
            byte cols = dimension;

            char[,] spots = new char[rows, cols];
            for (byte i = 0; i < rows; i++) 
            {
                for (byte j = 0; j < cols; j++)
                {
                    spots[i, j] = ' ';
                }     
            }
            // CODE END

            bool game = false; // See if game is over or not
            bool tie = false; // See if there was a tie
            byte turn = 1; // See whose turn it is
            char currChar = 'E';// Unnecessary assignment, but C++ wouldn't like uninitialized variables

            while (!game && !tie) // Game loop
            {
                if (turn % 2 == 1) currChar = 'X';
                else currChar = 'O';
                Console.WriteLine($"Player {currChar} turn");
                ShowBoard(spots);

                // CODE: Allow player to fill board
                byte row = 0;
                byte col = 0;

                // Loop to make sure the user inputs something valid
                bool validInput = false;
                while (!validInput) 
                {
                    // The user might input something that's not a number
                    // So we use a try catch to handle this exception
                    try
                    {
                        // I would make the input more user friendly (by not making it 0-based)
                        // But this would lead to a whole new branch of possible exceptions...
                        // I'll probably do it later, but as of now I'm too lazy
                        Console.WriteLine("Choose row (0-based): ");
                        row = Convert.ToByte(Console.ReadLine());
                        Console.WriteLine("Choose col (0-based): ");
                        col = Convert.ToByte(Console.ReadLine());
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine($"{e.Message}, Please input a number");
                        throw new Exception("Please input a number.", e);
                    }
                    catch (OverflowException e)
                    {
                        Console.WriteLine($"{e.Message}, Please input a number that can fit in a {dimension.GetType()}");
                        throw new Exception($"Please input a number that can fit in a {dimension.GetType()}.", e);
                    }

                    // Note: the continues here are so the final statement doesn't get reached in the loop
                    //       which states that the input is now valid

                    // Next, check if the chosen row and col are actually within the bounds of the board
                    if (row >= rows || col >= cols)
                    {
                        Console.WriteLine($"Please make sure your chosen row and column is within the bounds of the board (0 - {dimension - 1})");
                        continue;
                    }

                    // Next, check if the spot is actually empty
                    if (spots[row, col] != ' ')
                    {
                        Console.WriteLine("Please choose an empty spot");
                        continue;
                    }

                    validInput = true;
                }

                spots[row, col] = currChar;
                turn++;
                // CODE END

                // CODE: See if there's a row streak
                for (byte i = 0; i < rows; i++)
                {
                    // Assume game is over so it's easier to condition check.
                    // That way, we only have one condition to worry about, that is,
                    // the condition that the spot does not match the current player's character.
                    // Also, we reassume game is over with every new row we check
                    // because there's a chance that the other rows may have the winning streak.
                    game = true;
                    
                    for (byte j = 0; j < cols; j++)
                    {
                        // Only one player can go at a time, so we only have to check for that player's letter
                        // to see if they have a streak.
                        if (spots[i, j] != currChar)
                        {
                            game = false;
                            break; // No point in checking the rest of the row if there's already one mismatching char
                        }

                        // If the current loop iteration passed the above check,
                        // and the next iteration marks the end of the loop,
                        // then that means this entire row has the same char (aka a winning streak).
                        // So before that next iteration begins, make i equal to rows.
                        // That way, we can exit the outside loop early since we already have our win
                        // Otherwise, the other rows will be checked, and if those other rows have a mismatch,
                        // Then game will be reassumed as not over even though we already have our win.
                        if (j + 1 == cols) i = rows;
                    } 
                }
                // If the above row streak check finds a winning streak,
                // then exit out of this while loop early as there's no reason to keep checking for wins.
                // Otherwise, the other checks will go through and may potentially reassume the game as
                // not being over.
                if (game) break;
                // CODE END

                // CODE: See if there's a column streak
                // There's no explanation here since it's similar to the row streak check
                for (byte j = 0; j < cols; j++)
                {
                    game = true;
                    for (byte i = 0; i < rows; i++)
                    {
                        if (spots[i, j] != currChar)
                        {
                            game = false;
                            break;
                        }
                        if (i + 1 == rows) j = cols;
                    }
                }
                if (game) break;
                // CODE END

                // CODE: Check top-left to bottom-right diagonal streak
                // This time, we reassume game is won outside the loop
                // Because there is only one top-left to bottom-right diagonal we can possibly check
                // Whereas with the rows and columns, there were multiple of them
                game = true;
                for (byte i = 0; i < rows; i++)
                {
                    for (byte j = i; j < i + 1; j++)
                    {
                        if (spots[i, j] != currChar)
                        {
                            game = false;

                            // Exit out the outer loop early as well after breaking this inner loop
                            // Since there's already a mismatch, there's no reason to go further down the diagonal
                            i = rows;
                            break;
                        }
                    }
                }
                if (game) break;
                // CODE END

                // CODE: Check top-right to bottom-left diagonal streak (broken)
                // Similar to top-left to bottom-right diagonal check, with slight differences in the indices
                game = true;
                for (byte i = 0; i < rows; i++)
                {
                    if (spots[i, (byte)(cols - 1 - i)] != currChar)
                    {
                        game = false;
                        break;
                    }
                }
                if (game) break;
                // CODE END

                tie = true;
                foreach (char spot in spots)
                    if (spot == ' ')
                    {
                        tie = false;
                        break;
                    }
                       
                Console.WriteLine(); // Spacing
            }
            Console.WriteLine(); // Spacing
            ShowBoard(spots); // Show board state one more time since the game loop cuts before ShowBoard() if a win is found
            if (game) Console.WriteLine($"Game: Player {currChar} wins");
            else Console.WriteLine("Tie");
            Console.ReadKey(); // Prevent window from closing out immediately once program ends in debug mode
        }

        /// <summary>
        /// Show current board state to the player
        /// </summary>
        /// <param name="spots">the spots to fill into the empty board</param>
        private static void ShowBoard(char[,] spots)
        {
            Console.WriteLine($" {spots[0, 0]} | {spots[0, 1]} | {spots[0, 2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {spots[1, 0]} | {spots[1, 1]} | {spots[1, 2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {spots[2, 0]} | {spots[2, 1]} | {spots[2, 2]} ");
        }
    }
}
