using Telegram.Bot.Types.ReplyMarkups;

namespace ExchangeRateTelegramBot.Util;

public class InlineKeyboardsMarkupStorage
{
    public static InlineKeyboardMarkup MenuMain = new(new[]
    {
        new[]
        {
            InlineKeyboardButton.WithCallbackData(BotButtonsStorage.GetCurrentExchangeRate.Name,
                BotButtonsStorage.GetCurrentExchangeRate.CallBackData),
        },
        new[]
        {
            InlineKeyboardButton.WithCallbackData(BotButtonsStorage.ShowTop250Movies.Name,
                BotButtonsStorage.ShowTop250Movies.CallBackData),
        },
        
    });

    
}