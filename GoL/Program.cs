bool[,] prevBoard = new bool[8, 8];
bool[,] board = new bool[8, 8];




int Clamp(int i, int max)
{
    if (i < 0) return max;
    if(i>max) return 0;
    return i;
}

void UpdateBoard()
{
    // Copy current board to prevBoard
    for (int i = 0; i < prevBoard.GetLength(0); i++)
    {
        for (int j = 0; j < prevBoard.GetLength(1); j++)
        {
            prevBoard[i, j] = board[i, j];
        }
    }


    // Count the number of neighbors for each cell and update on next board
    for (int i = 0; i < prevBoard.GetLength(0); i++)
    {
        for (int j = 0; j < prevBoard.GetLength(1); j++)
        {
            int x = prevBoard.GetLength(0) - 1;
            int y = prevBoard.GetLength(1) - 1;
            int neighborCount = 0;
            if (prevBoard[Clamp(i+1, x), Clamp(j  , y)]) neighborCount++;
            if (prevBoard[Clamp(i-1, x), Clamp(j  , y)]) neighborCount++;
            if (prevBoard[Clamp(i  , x), Clamp(j+1, y)]) neighborCount++;
            if (prevBoard[Clamp(i+1, x), Clamp(j+1, y)]) neighborCount++;
            if (prevBoard[Clamp(i-1, x), Clamp(j+1, y)]) neighborCount++;
            if (prevBoard[Clamp(i  , x), Clamp(j-1, y)]) neighborCount++;
            if (prevBoard[Clamp(i+1, x), Clamp(j-1, y)]) neighborCount++;
            if (prevBoard[Clamp(i-1, x), Clamp(j-1, y)]) neighborCount++;

            // if less than 0 or 1, die
            if(neighborCount < 2)
            {
                board[i, j] = false;
            }
            // if 2, do nothing

            // if 3, become alive
            if (neighborCount == 3)
            {
                board[i, j] = true;
            }
            // if more than 3, die
            if (neighborCount > 3)
            {
                board[i, j] = false;
            }
        }
    }
}

 void DrawBoard()
 {
     for (int i = 0; i < board.GetLength(0); i++)
     {
         for (int j = 0; j < board.GetLength(1); j++)
         {
             Console.Write(board[i, j] ? "#" : " ");
         }
         Console.WriteLine();
     }
 }


bool[,] initBoard = new bool[,] {
    { false, false, false, false, false, false, false, false },
    { false, false, true , false, false, true , false, false },
    { false, false, true , false, false, true , false, false },
    { false, false, true , false, false, true , false, false },
    { false, false, false, false, false, false, false, false },
    { false, true , false, false, false, false, true , false },
    { false, true , true , true , true , true , true , false },
    { false, false, false, false, false, false, false, false },
};

 for (int i = 0; i < board.GetLength(0); i++)
 {
     for (int j = 0; j < board.GetLength(1); j++)
     {
         board[i, j] = initBoard[i,j];
     }
 }





 while (true)
 {
    DrawBoard();
    
    Console.ReadLine();

    UpdateBoard();
}
