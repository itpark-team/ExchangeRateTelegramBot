namespace ExchangeRateTelegramBot.Util;

public class BotButtonsStorage
{
    #region ButtonsInMenuMain
    public static BotButton GetCurrentExchangeRate { get; } = new BotButton("Показать текущий курс валют", "GetCurrentExchangeRate");
    public static BotButton ShowTop250Movies { get; } = new BotButton("Показать топ фильмов с IMDb", "ShowTop250Movies");
    
    public static BotButton ShowPostById { get; } = new BotButton("Показать пост по ИД", "ShowPostById");
    
    public static BotButton ShowAllPosts { get; } = new BotButton("Показать все посты", "ShowAllPosts");
    
    public static BotButton AddNewPosts { get; } = new BotButton("Добавить новый пост", "AddNewPosts");
    
    public static BotButton DeletePostById { get; } = new BotButton("Удалить пост по ИД", "DeletePostById");
    
    public static BotButton UpdatePostById { get; } = new BotButton("Обновить пост по ИД", "UpdatePostById");
    #endregion

   
    
}