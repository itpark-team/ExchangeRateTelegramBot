using ExchangeRateTelegramBot.BotInitializer;
using ExchangeRateTelegramBot.Service;
using ExchangeRateTelegramBot.Service.MenuPoints;
using ExchangeRateTelegramBot.Util;


namespace ExchangeRateTelegramBot.Router;

public class ChatsRouter
{
    private Dictionary<long, TransmittedData> _chatTransmittedDataPairs;
    private ServicesManager _servicesManager;

    public ChatsRouter()
    {
        _chatTransmittedDataPairs = new Dictionary<long, TransmittedData>();
        _servicesManager = new ServicesManager();
    }

    public BotTextMessage Route(long chatId, string textData)
    {
        if (!_chatTransmittedDataPairs.ContainsKey(chatId))
        {
            _chatTransmittedDataPairs[chatId] = new TransmittedData(chatId);
        }

        TransmittedData transmittedData = _chatTransmittedDataPairs[chatId];
        
        if (textData == SystemStringsStorage.CommandReset && transmittedData.State != State.CommandStart)
        {
            return SharedServices.GotoProcessClickInMenuMain(transmittedData);
        }
        
        return _servicesManager.ProcessBotUpdate(textData, transmittedData);
    }
}