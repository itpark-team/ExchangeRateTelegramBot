using ExchangeRateTelegramBot.BotInitializer;
using ExchangeRateTelegramBot.Router;
using ExchangeRateTelegramBot.Service.MenuPoints;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ExchangeRateTelegramBot.Service;

public class ServicesManager
{
    private Dictionary<State, Func<string, TransmittedData, BotTextMessage>>
        _methods;

    private MainMenuService _mainMenuService;


    public ServicesManager()
    {
        _mainMenuService = new MainMenuService();
        
        _methods =
            new Dictionary<State, Func<string, TransmittedData, BotTextMessage>>();

        #region MenuMainService

        _methods[State.CommandStart] = _mainMenuService.ProcessCommandStart;

        _methods[State.ClickInMenuMain] =
            _mainMenuService.ProcessClickInMenuMain;

        #endregion
        
    }

    public BotTextMessage ProcessBotUpdate(string textData, TransmittedData transmittedData)
    {
        var serviceMethod = _methods[transmittedData.State];

        return serviceMethod.Invoke(textData, transmittedData);
    }
}