/// <summary>
/// class describing game
/// </summary>
class Game
{
    private char[] board;
    private int player;
    private bool isOver;

    public Game()
    {
        board = new char[9];
        player = 1;
        isOver = false;
        InitializeFields();
    }

    /// <summary>
    /// cr
    /// </summary>
    private void InitializeFields()
    {
        for (int i = 1; i <= board.Length; i++)
        {
            board[i - 1] = Char.Parse(i.ToString());
        }
    }

    /// <summary>
    /// Start game
    /// </summary>
    public void Play()
    {
        do
        {
            Console.Clear();
            PrintBoard();
            int choice;

            while (true)
            {
                Console.WriteLine($"Очередь игрока - {player}. Введите номер ячейки 1-9");
                if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 9 || board[choice - 1] != (choice + '0'))
                {
                    Console.WriteLine("Некорректный ход!");
                    continue;
                }
                break;
            }

            if (player == 1)
            {
                board[choice - 1] = 'X';
                player = 2;
            }
            else
            {
                board[choice - 1] = 'O';
                player = 1;
            }

            if (CheckWin() || CheckDraw())
            {
                isOver = true;
                Console.Clear();
                PrintBoard();
                if (CheckWin())
                {
                    Console.WriteLine($"Игрок {player} выиграл!");
                }
                else
                {
                    Console.WriteLine("Ничья!");
                }
            }
        } while (!isOver);
    }

    /// <summary>
    /// Check if win
    /// </summary>
    /// <returns></returns>
    private bool CheckWin()
    {
        for (int i = 0; i < 3; i++)
        {
            if (board[i] == board[i + 3] && board[i + 3] == board[i + 6])
            {
                return true;
            }
            if (board[i * 3] == board[i * 3 + 1] && board[i * 3 + 1] == board[i * 3 + 2])
            {
                return true;
            }
        }

        if (board[0] == board[4] && board[4] == board[8])
        {
            return true;
        }
        if (board[2] == board[4] && board[4] == board[6])
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// Check if draw
    /// </summary>
    /// <returns></returns>
    private bool CheckDraw()
    {
        return !Array.Exists(board, cell => cell != 'X' && cell != 'O');
    }

    /// <summary>
    /// Print board
    /// </summary>
    private void PrintBoard()
    {
        Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
    }
}