namespace ExchangeRateTelegramBot.Util;

public class BotButtonsStorage
{
    #region ButtonsInMenuMain
    public static BotButton GetCurrentExchangeRate { get; } = new BotButton("Показать текущий курс валют", "GetCurrentExchangeRate");
    public static BotButton ShowRandomQuote { get; } = new BotButton("Показать случайную цитату из bashorg.org", "ShowInMenuMain");
    #endregion

   
    
}