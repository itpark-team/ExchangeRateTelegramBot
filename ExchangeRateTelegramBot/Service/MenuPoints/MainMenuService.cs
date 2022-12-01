using System.Text;
using ExchangeRateTelegramBot.CbrApi;
using ExchangeRateTelegramBot.BotInitializer;
using ExchangeRateTelegramBot.FakeApi;
using ExchangeRateTelegramBot.ImdbParser;
using ExchangeRateTelegramBot.Router;
using ExchangeRateTelegramBot.Util;


namespace ExchangeRateTelegramBot.Service.MenuPoints;

public class MainMenuService
{
    private CbrApiWorker _cbrApiWorker;
    private ImdbSiteParser _imdbSiteParser;
    private FakeApiWorker _fakeApiWorker;

    public MainMenuService()
    {
        _cbrApiWorker = new CbrApiWorker();
        _imdbSiteParser = new ImdbSiteParser();
        _fakeApiWorker = new FakeApiWorker();
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
        else if (callBackData == BotButtonsStorage.ShowPostById.CallBackData)
        {
            FakePost fakePost = _fakeApiWorker.GetById(1);

            return new BotTextMessage(
                DialogsStringsStorage.CreatePost(fakePost)
            );
        }
        else if (callBackData == BotButtonsStorage.ShowAllPosts.CallBackData)
        {
            List<FakePost> fakePosts = _fakeApiWorker.GetAll().GetRange(0, 5);

            return new BotTextMessage(
                DialogsStringsStorage.CreateAllPosts(fakePosts)
            );
        }
        else if (callBackData == BotButtonsStorage.AddNewPosts.CallBackData)
        {
            FakePost fakePost = new FakePost()
            {
                Body = "Mybody",
                Title = "Mytitle",
                UserId = 112111
            };

            FakePost addedPost = _fakeApiWorker.AddNew(fakePost);

            return new BotTextMessage(
                DialogsStringsStorage.CreatePost(addedPost)
            );
        }
        else if (callBackData == BotButtonsStorage.DeletePostById.CallBackData)
        {
            bool deleteResult = _fakeApiWorker.DeleteById(1);

            string textMessage = deleteResult ? "успешно удалено" : "ошибка удаления";

            return new BotTextMessage(
                textMessage
            );
        }
        else if (callBackData == BotButtonsStorage.UpdatePostById.CallBackData)
        {
            FakePost fakePost = new FakePost()
            {
                Body = "MybodyUpdate",
                Title = "MytitleUpdate",
                UserId = 10000
            };

            FakePost updatedPost = _fakeApiWorker.UpdateById(1, fakePost);

            return new BotTextMessage(
                DialogsStringsStorage.CreatePost(updatedPost)
            );
        }

        throw new Exception("CallBackData не распознана");
    }
}