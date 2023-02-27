using Bingoapp.Data;
using Bingoapp.Models;

namespace Bingoapp.Rule
{
    public class BallNumberRule
    {
        private static readonly Random random = new();
        private static readonly HashSet<int> numbersGenerated = new();
        public async Task<int> GetUniqueBallNumberAsync(ApplicationDbContext context)
        {
            int randomNumber;
            do
            {
                randomNumber = random.Next(1, 91);
            } while (numbersGenerated.Contains(randomNumber) && numbersGenerated.Count < 90);
            numbersGenerated.Add(randomNumber);
            context.BallHistories.Add(new BallHistory { BallNumber = randomNumber, GeneratedAt = DateTime.Now });
            await context.SaveChangesAsync();
            return randomNumber;
        }
        public void ClearNumbersGenerated()
        {
            numbersGenerated.Clear();
        }

    }
}
