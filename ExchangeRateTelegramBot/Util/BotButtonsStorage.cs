namespace ExchangeRateTelegramBot.Util;

public class BotButtonsStorage
{
    #region ButtonsInMenuMain
    public static BotButton GetCurrentExchangeRate { get; } = new BotButton("Показать текущий курс валют", "GetCurrentExchangeRate");
    public static BotButton ShowTop250Movies { get; } = new BotButton("Показать топ фильмов с IMDb", "ShowTop250Movies");
    
    public static BotButton ShowPostById { get; } = new BotButton("Показать пост по ИД", "ShowPostById");
    
    public static BotButton ShowAllPosts { get; } = new BotButton("Показать все посты", "{");
    #endregion

   
    
}