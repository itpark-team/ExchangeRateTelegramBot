using System.Text;
using ExchangeRateTelegramBot.Api;
using ExchangeRateTelegramBot.BotInitializer;
using ExchangeRateTelegramBot.ImdbParser;
using ExchangeRateTelegramBot.Router;
using ExchangeRateTelegramBot.Util;


namespace ExchangeRateTelegramBot.Service.MenuPoints;

public class MainMenuService
{
    private CbrApiWorker _cbrApiWorker;
    private ImdbSiteParser _imdbSiteParser;

    public MainMenuService()
    {
        _cbrApiWorker = new CbrApiWorker();
        _imdbSiteParser = new ImdbSiteParser();
    }

    public BotTextMessage ProcessCommandStart(string command, TransmittedData transmittedData)
    {
        if (command != SystemStringsStorage.CommandStart)
        {
            return new BotTextMessage(DialogsStringsStorage.CommandStartInputErrorInput);
        }

        return SharedServices.GotoProcessClickInMenuMain(transmittedData);
    }

    public BotTextMessage ProcessClickInMenuMain(string callBackData, TransmittedData transmittedData)
    {
        if (callBackData == BotButtonsStorage.GetCurrentExchangeRate.CallBackData)
        {
            ExchangeRate exchangeRate = _cbrApiWorker.GetCurrentExchangeRate();

            return new BotTextMessage(
                DialogsStringsStorage.CreateCurrentExchangeRate(exchangeRate.DateTime, exchangeRate.Usd,
                    exchangeRate.Eur)
            );
        }
        else if (callBackData == BotButtonsStorage.ShowTop250Movies.CallBackData)
        {
            List<Film> films = _imdbSiteParser.getFirstFilmsFromTop250(100);
            
            return new BotTextMessage(
                DialogsStringsStorage.CreateTopFilms(films)
            );
        }

        throw new Exception("CallBackData не распознана");
    }
}