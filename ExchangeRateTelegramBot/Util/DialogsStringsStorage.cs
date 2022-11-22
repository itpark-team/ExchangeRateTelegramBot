using System.Text;
using ExchangeRateTelegramBot.FakeApi;
using ExchangeRateTelegramBot.ImdbParser;

namespace ExchangeRateTelegramBot.Util;

public class DialogsStringsStorage
{
    public const string CommandStartInputErrorInput =
        "Команда не распознана. Для начала работы с ботом введите /start";

    public const string MenuMain = "Доброго времени друзья\nВы в главном меню\nВыберите действие";

    public static string CreateCurrentExchangeRate(DateTime dateTime, double usd, double eur)
    {
        return $"Курс валют на {dateTime}\n1 американский доллар = {usd} руб.\n1 евро = {eur} руб.";
    }
    
    public static string CreateTopFilms(List<Film> films)
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (Film film in films)
        {
            stringBuilder.AppendLine($"{film.Number}. {film.Name} {film.Year} {film.Rating}");
        }

        return stringBuilder.ToString();
    }
    
    public static string CreatePost(FakePost fakePost)
    {
        return $"userId:{fakePost.UserId}\nid:{fakePost.Id}\ntitle:{fakePost.Title}\nbody:{fakePost.Title}";
    }
    
    public static string CreateAllPosts(List<FakePost> fakePosts)
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (FakePost post in fakePosts)
        {
            stringBuilder.AppendLine(CreatePost(post));
        }

        return stringBuilder.ToString();
    }
    
}