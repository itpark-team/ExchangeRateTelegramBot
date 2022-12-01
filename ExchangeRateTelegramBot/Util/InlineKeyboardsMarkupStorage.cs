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
        new[]
        {
            InlineKeyboardButton.WithCallbackData(BotButtonsStorage.ShowPostById.Name,
                BotButtonsStorage.ShowPostById.CallBackData),
        },
        new[]
        {
            InlineKeyboardButton.WithCallbackData(BotButtonsStorage.ShowAllPosts.Name,
                BotButtonsStorage.ShowAllPosts.CallBackData),
        },
        new[]
        {
            InlineKeyboardButton.WithCallbackData(BotButtonsStorage.AddNewPosts.Name,
                BotButtonsStorage.AddNewPosts.CallBackData),
        },
        new[]
        {
            InlineKeyboardButton.WithCallbackData(BotButtonsStorage.DeletePostById.Name,
                BotButtonsStorage.DeletePostById.CallBackData),
        },
        new[]
        {
            InlineKeyboardButton.WithCallbackData(BotButtonsStorage.UpdatePostById.Name,
                BotButtonsStorage.UpdatePostById.CallBackData),
        }
    });

    
}