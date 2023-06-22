using Telegram.Bot;
using Telegram.Bot.Polling;

class BotBackgroundTask : BackgroundService
{
    private readonly ILogger<BotBackgroundTask> logg;
    private readonly ITelegramBotClient botClient;
    private readonly IUpdateHandler updateHandler;

    public BotBackgroundTask(
        ILogger<BotBackgroundTask> logg,
        ITelegramBotClient botClient,
        IUpdateHandler updateHandler
    )
    {
        this.logg = logg;
        this.botClient = botClient;
        this.updateHandler = updateHandler;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var me = await botClient.GetMeAsync(stoppingToken);
        logg.LogInformation("Bot started: {username}", me.Username);
        botClient.StartReceiving(
            updateHandler: updateHandler,
            receiverOptions: default,
            cancellationToken: stoppingToken
        );

        
    }
}