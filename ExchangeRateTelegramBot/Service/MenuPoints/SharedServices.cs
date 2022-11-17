using ExchangeRateTelegramBot.BotInitializer;
using ExchangeRateTelegramBot.Router;
using ExchangeRateTelegramBot.Util;

namespace ExchangeRateTelegramBot.Service.MenuPoints;

public class SharedServices
{
    public static BotTextMessage GotoProcessClickInMenuMain(TransmittedData transmittedData)
    {
        transmittedData.State = State.ClickInMenuMain;
        transmittedData.DataStorage.Clear();
        
        return new BotTextMessage(
            DialogsStringsStorage.MenuMain,
            InlineKeyboardsMarkupStorage.MenuMain
        );
    }
}