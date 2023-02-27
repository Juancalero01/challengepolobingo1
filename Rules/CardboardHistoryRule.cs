using Bingoapp.Data;
using Bingoapp.Models;
using System.Reflection;

namespace Bingoapp.Rule
{
    public class CardboardHistoryRule
    {
        public async Task AddWinnersAsync(ApplicationDbContext context, List<int> winners)
        {
            var cardboardHistory = new CardboardHistory
            {
                GeneratedAt = DateTime.Now
            };
            var properties = typeof(CardboardHistory).GetProperties()
                .Where(p => p.PropertyType == typeof(int?) && p.Name.StartsWith("Cardboard"))
                .ToList();
            for (int i = 0; i < winners.Count; i++)
            {
                properties[i].SetValue(cardboardHistory, winners[i]);
            }
            context.CardboardHistories.Add(cardboardHistory);
            await context.SaveChangesAsync();
        }
    }
}