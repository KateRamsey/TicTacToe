using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.app
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameBoard = new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            char Player = 'X';
            bool isGameOver = false;
            int currentMove = 1;
            bool isGameBoardFull;
            string gameEndMessage = "Games's not over";
            bool badMove = false;
            char AIDifficulty;

            Console.WriteLine("Welcome to Kate's Tic-Tac-Toe!");
            Console.WriteLine();
            Console.WriteLine("What Difficulty would you like to play? (E, M, H)");
            AIDifficulty = char.Parse(Console.ReadLine());
            Console.WriteLine("Human Player X goes first");
            Console.WriteLine();

            while (!isGameOver)
            {
                writeBoard(gameBoard);
                Console.WriteLine();
                if (Player == 'X')
                {
                    Console.WriteLine("Player {0}, which box would you like to play in (please enter 1-9)?", Player);
                    currentMove = int.Parse(Console.ReadLine());
                    badMove = currentMove < 1 || currentMove > 9 || gameBoard[currentMove - 1] == 'X' || gameBoard[currentMove - 1] == 'O';
                    while (badMove)
                    {
                        Console.WriteLine("Why you try to cheat?? Pick an open spot");
                        currentMove = int.Parse(Console.ReadLine());
                        badMove = currentMove < 1 || currentMove > 9 || gameBoard[currentMove - 1] == 'X' || gameBoard[currentMove - 1] == 'O';
                    }
                }
                else
                {
                    if (AIDifficulty == 'E')
                    {
                        currentMove = easyTicTacToeAI(gameBoard);
                        while (gameBoard[currentMove - 1] == 'X' || gameBoard[currentMove - 1] == 'O')
                        {
                            currentMove = easyTicTacToeAI(gameBoard);
                        }
                    }
                    else if (AIDifficulty == 'M')
                    {
                        currentMove = medTicTacToeAI(gameBoard);
                        while (gameBoard[currentMove - 1] == 'X' || gameBoard[currentMove - 1] == 'O')
                        {
                            currentMove = medTicTacToeAI(gameBoard);
                        }
                    }
                    else if (AIDifficulty == 'H')
                    {
                        currentMove = hardTicTacToeAI(gameBoard);
                        while (gameBoard[currentMove - 1] == 'X' || gameBoard[currentMove - 1] == 'O')
                        {
                            currentMove = hardTicTacToeAI(gameBoard);
                        }
                    }
                }

                gameBoard[currentMove - 1] = Player;

                isGameOver = CheckWin(gameBoard, Player);
                if (isGameOver)
                {
                    gameEndMessage = $"Yay, Player {Player} wins!";
                    break;
                }


                isGameBoardFull = true;
                foreach (char spot in gameBoard)
                {
                    if (spot != 'X' && spot != 'O')

                    {
                        isGameBoardFull = false;
                        break;
                    }
                }
                if (isGameBoardFull)
                {
                    gameEndMessage = "The Board is full, tie game";
                    isGameOver = true;
                }

                if (Player == 'X')
                {
                    Player = 'O';
                }
                else
                {
                    Player = 'X';
                }

                Console.Clear();
            }

            Console.Clear();
            writeBoard(gameBoard);
            Console.WriteLine();
            Console.WriteLine(gameEndMessage);
            Console.WriteLine();
            Console.WriteLine("Thanks for playing Kate's awesome Tic-Tac-Toe, have a great day!");

            Console.ReadLine();
        }

        public static void writeBoard(char[] Board)
        {
            Console.WriteLine($"{Board[0]} | {Board[1]} | {Board[2]} ");
            Console.WriteLine("---------");
            Console.WriteLine($"{Board[3]} | {Board[4]} | {Board[5]} ");
            Console.WriteLine("---------");
            Console.WriteLine($"{Board[6]} | {Board[7]} | {Board[8]} ");
        }

        public static int easyTicTacToeAI(char[] gameBoard)
        {
            //Adventurer Mode
            Random r = new Random();
            int move = r.Next(1, 9);
            return move;
        }

        public static bool CheckWin(char[] gameBoard, char Player)
        {
            bool isGameOver = false;
            if (gameBoard[0] == Player && gameBoard[1] == Player && gameBoard[2] == Player)
            {
                isGameOver = true;
            }
            else if (gameBoard[3] == Player && gameBoard[4] == Player && gameBoard[5] == Player)
            {
                isGameOver = true;
            }
            else if (gameBoard[6] == Player && gameBoard[7] == Player && gameBoard[8] == Player)
            {
                isGameOver = true;
            }
            else if (gameBoard[0] == Player && gameBoard[3] == Player && gameBoard[6] == Player)
            {
                isGameOver = true;
            }
            else if (gameBoard[1] == Player && gameBoard[4] == Player && gameBoard[7] == Player)
            {
                isGameOver = true;
            }
            else if (gameBoard[2] == Player && gameBoard[5] == Player && gameBoard[8] == Player)
            {
                isGameOver = true;
            }
            else if (gameBoard[0] == Player && gameBoard[4] == Player && gameBoard[8] == Player)
            {
                isGameOver = true;
            }
            else if (gameBoard[2] == Player && gameBoard[4] == Player && gameBoard[6] == Player)
            {
                isGameOver = true;
            }
            return isGameOver;
        }

        public static int medTicTacToeAI(char[] gameBoard)
        {
            //Epic Mode
            int move = 1;
            bool WinningMove = false;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                if (gameBoard[i] != 'X' && gameBoard[i] != 'O')
                {
                    gameBoard[i] = 'O';
                    WinningMove = CheckWin(gameBoard, 'O');
                    if (WinningMove)
                    {
                        move = i + 1;
                    }
                    switch (i)
                    {
                        case 0: gameBoard[i] = '1'; break;
                        case 1: gameBoard[i] = '2'; break;
                        case 2: gameBoard[i] = '3'; break;
                        case 3: gameBoard[i] = '4'; break;
                        case 4: gameBoard[i] = '5'; break;
                        case 5: gameBoard[i] = '6'; break;
                        case 6: gameBoard[i] = '7'; break;
                        case 7: gameBoard[i] = '8'; break;
                        case 8: gameBoard[i] = '9'; break;
                        default: break;
                    }
                    if (WinningMove) break;
                }
            }
            for (int i = 0; i < gameBoard.Length; i++)
            {
                if (gameBoard[i] != 'X' && gameBoard[i] != 'O')
                {
                    gameBoard[i] = 'X';
                    WinningMove = CheckWin(gameBoard, 'X');
                    if (WinningMove)
                    {
                        move = i + 1;
                    }
                    switch (i)
                    {
                        case 0: gameBoard[i] = '1'; break;
                        case 1: gameBoard[i] = '2'; break;
                        case 2: gameBoard[i] = '3'; break;
                        case 3: gameBoard[i] = '4'; break;
                        case 4: gameBoard[i] = '5'; break;
                        case 5: gameBoard[i] = '6'; break;
                        case 6: gameBoard[i] = '7'; break;
                        case 7: gameBoard[i] = '8'; break;
                        case 8: gameBoard[i] = '9'; break;
                        default:
                            break;
                    }
                    if (WinningMove) break;
                }
            }

            if (!WinningMove)
            {
                Random r = new Random();
                move = r.Next(1, 9);
            }

            return move;
        }

        public static int hardTicTacToeAI(char[] gameBoard)
        {
            //Epic Mode
            int move = 1;
            bool WinningMove = false;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                if (gameBoard[i] != 'X' && gameBoard[i] != 'O')
                {
                    gameBoard[i] = 'O';
                    WinningMove = CheckWin(gameBoard, 'O');
                    if (WinningMove)
                    {
                        move = i + 1;
                    }
                    switch (i)
                    {
                        case 0: gameBoard[i] = '1'; break;
                        case 1: gameBoard[i] = '2'; break;
                        case 2: gameBoard[i] = '3'; break;
                        case 3: gameBoard[i] = '4'; break;
                        case 4: gameBoard[i] = '5'; break;
                        case 5: gameBoard[i] = '6'; break;
                        case 6: gameBoard[i] = '7'; break;
                        case 7: gameBoard[i] = '8'; break;
                        case 8: gameBoard[i] = '9'; break;
                        default: break;
                    }
                    if (WinningMove) break;
                }
            }
            for (int i = 0; i < gameBoard.Length; i++)
            {
                if (gameBoard[i] != 'X' && gameBoard[i] != 'O')
                {
                    gameBoard[i] = 'X';
                    WinningMove = CheckWin(gameBoard, 'X');
                    if (WinningMove)
                    {
                        move = i + 1;
                    }
                    switch (i)
                    {
                        case 0: gameBoard[i] = '1'; break;
                        case 1: gameBoard[i] = '2'; break;
                        case 2: gameBoard[i] = '3'; break;
                        case 3: gameBoard[i] = '4'; break;
                        case 4: gameBoard[i] = '5'; break;
                        case 5: gameBoard[i] = '6'; break;
                        case 6: gameBoard[i] = '7'; break;
                        case 7: gameBoard[i] = '8'; break;
                        case 8: gameBoard[i] = '9'; break;
                        default:
                            break;
                    }
                    if (WinningMove) break;
                }
            }

            if (!WinningMove)
            {
                if (gameBoard[4] != 'X' && gameBoard[4] != 'O')
                {
                    move = 5;
                }
                else if (gameBoard[0] != 'X' && gameBoard[0] != 'O')
                {
                    move = 1;
                }
                else if (gameBoard[2] != 'X' && gameBoard[2] != 'O')
                {
                    move = 3;
                }
                else if (gameBoard[6] != 'X' && gameBoard[6] != 'O')
                {
                    move = 7;
                }
                else if (gameBoard[8] != 'X' && gameBoard[8] != 'O')
                {
                    move = 9;
                }
                else if (gameBoard[1] != 'X' && gameBoard[1] != 'O')
                {
                    move = 2;
                }
                else if (gameBoard[3] != 'X' && gameBoard[3] != 'O')
                {
                    move = 4;
                }
                else if (gameBoard[5] != 'X' && gameBoard[5] != 'O')
                {
                    move = 6;
                }
                else if (gameBoard[7] != 'X' && gameBoard[7] != 'O')
                {
                    move = 8;
                }
            }

            return move;
        }
    }
}
