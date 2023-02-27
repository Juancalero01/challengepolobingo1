namespace Bingoapp.Rule
{
    public class CardboardRule
    {
        public int[,] GenerateCardboard()
        {
            var carboard = new int[3, 9];
            var random = new Random();

            for (var column = 0; column < 9; column++)
            {
                for (var row = 0; row < 3; row++)
                {
                    var newNumber = 0;
                    var newFound = false;

                    while (!newFound)
                    {
                        if (column == 0) newNumber = random.Next(1, 10);
                        else if (column == 8) newNumber = random.Next(80, 91);
                        else newNumber = random.Next(column * 10, column * 10 + 10);
                        newFound = true;
                        for (var currentRow = 0; currentRow < 3; currentRow++)
                            if (carboard[currentRow, column] == newNumber) { newFound = false; break; }
                    }
                    carboard[row, column] = newNumber;
                }
            }
            var carboardWithEmptySpaces = GenerateEmpty(carboard);
            var cardboardInList = new List<int>();
            for (var column = 0; column < 9; column++)
            {
                for (var row = 0; row < 3; row++)
                    cardboardInList.Add(carboardWithEmptySpaces[row, column]);
            }
            return carboardWithEmptySpaces;
        }
        public int[,] GenerateEmpty(int[,] cardboard)
        {
            var random = new Random();
            var deleted = 0;

            while (deleted < 12)
            {
                var rowToDelete = random.Next(0, 3);
                var columnToDelete = random.Next(0, 9);
                if (cardboard[rowToDelete, columnToDelete] == 0) continue;
                var zerosInRow = 0;
                for (var column = 0; column < 9; column++)
                    if (cardboard[rowToDelete, column] == 0) zerosInRow++;
                var zerosInColumn = 0;
                for (var row = 0; row < 3; row++)
                    if (cardboard[row, columnToDelete] == 0) zerosInColumn++;
                var itemsByColumn = new int[9];
                for (var column = 0; column < 9; column++)
                {
                    for (var row = 0; row < 3; row++)
                        if (cardboard[row, column] != 0) itemsByColumn[column]++;
                }
                var columnWithASingleNumber = 0;
                for (var column = 0; column < 9; column++)
                    if (itemsByColumn[column] == 1) columnWithASingleNumber++;
                if (zerosInRow == 4 || zerosInColumn == 2) continue;
                if (columnWithASingleNumber == 3 && itemsByColumn[columnToDelete] != 3) continue;

                cardboard[rowToDelete, columnToDelete] = 0;
                deleted++;
            }
            return cardboard;
        }
    }
}
