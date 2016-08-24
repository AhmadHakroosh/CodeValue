using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class TicTacToeGame
    {
        //Consider a better name
        private int N = 3;

        //Consider better enum names
        enum CELL { X, O, E };

        //The convention in C# for private fields is to start with "_" and then use camel casing. like _board.
        private CELL[][] Board;

        private CELL Turn = CELL.O;

        private bool isBoardEmpty = true;

        //It isn't a good idea to write console messages in a logic/query method...
        public bool IsGameOver()
        {
            bool isOver = CheckCols() || CheckRows() || CheckDiag();
            if (isOver)
            {
                //Why is this here? This methods hould be a query. It shouldn't change state.
                ChangeTurn();
                Console.WriteLine($"{Turn} has won! Game Over!");
            }

            return isOver;
        }

        public TicTacToeGame()
        {
            Board = new CELL[N][];
            for (int i = 0; i < N; i++)
            {
                Board[i] = new CELL[N];
            }
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Board[i][j] = CELL.E;
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    //code duplicaition
                    //Console.Write($"${Board[i][j]} {j == N - 1}");
                    if (j == N - 1)
                    {
                        Console.Write($"{Board[i][j]}  ");
                    }
                    else
                    {
                        Console.Write($"{Board[i][j]} | ");
                    }
                }

                //Console.WriteLine();
                Console.WriteLine("");
                if (i != N - 1)
                {
                    Console.WriteLine("---------");
                }
            }
        }

        public void Move(int cell)
        {
            if (IsLegal(cell))
            {
                Board[(cell - 1) / N][(cell - 1) % N] = Turn;
                isBoardEmpty = false;
                ChangeTurn();
                Print();
            }
        }

        private bool IsLegal(int cell)
        {
            if(cell <= 9 && cell >= 1)
            {
                return Board[(cell - 1)/N][(cell - 1)%N] == CELL.E;
            }

            else
            {
                Console.WriteLine($"{cell} is not a legal cell number!");
                return false;
            }
        }

        private void ChangeTurn()
        {
            if (Turn == CELL.O)
            {
                Turn = CELL.X;
                return;
            }

            if (Turn == CELL.X)
            {
                Turn = CELL.O;
                return;
            }
        }

        private bool CheckRows()
        {
            bool isOver = false;
            for (int i = 0; i < N; i++)
            {
                isOver = true;
                for (int j = 1; j < N; j++)
                {
                    isOver = isOver && (Board[i][j - 1] == Board[i][j]) && Board[i][j] != CELL.E;
                }
                if (isOver)
                {
                    return isOver;
                }
            }
            return isOver;
        }

        private bool CheckCols()
        {
            bool isOver = false;
            for (int i = 0; i < N; i++)
            {
                isOver = true;
                for (int j = 1; j < N; j++)
                {
                    isOver = isOver && (Board[j - 1][i] == Board[j][i]) && Board[j][i] != CELL.E;
                }
                if (isOver)
                {
                    return isOver;
                }
            }
            return isOver;
        }

        private bool CheckDiag()
        {
            bool isOver1 = false;
            bool isOver2 = false;

            isOver1 = true;
            for (int j = 1; j < N; j++)
            {
                isOver1 = isOver1 && (Board[j - 1][j - 1] == Board[j][j]) && Board[j][j] != CELL.E;
            }
            
            
            isOver2 = true;
            for (int j = 1; j < N; j++)
            {
                isOver2 = isOver2 && (Board[j - 1][j - 1] == Board[j][j]) && Board[j][j] != CELL.E;
            }

            return isOver1 && isOver2;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TicTacToeGame game = new TicTacToeGame();

            while (!game.IsGameOver())
            {
                Console.Write("Enter a cell number: ");
                int cell = int.Parse(Console.ReadLine());
                game.Move(cell);
            }
            Console.Read();
        }
    }
}
