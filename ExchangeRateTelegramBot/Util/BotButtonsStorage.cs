namespace ExchangeRateTelegramBot.Util;

public class BotButtonsStorage
{
    #region ButtonsInMenuMain
    public static BotButton GetCurrentExchangeRate { get; } = new BotButton("Показать текущий курс валют", "GetCurrentExchangeRate");
    public static BotButton ShowTop250Movies { get; } = new BotButton("Показать топ фильмов с IMDb", "ShowTop250Movies");
    #endregion

   
    
}