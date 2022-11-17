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
}