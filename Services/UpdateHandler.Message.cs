using Telegram.Bot;
using Telegram.Bot.Types;

public partial class UpdateHandler
{
    private Task HandleMessageUpdateAsync(ITelegramBotClient botClient, Message? message, CancellationToken cancellationToken)
    {
        var username = message?.From?.Username ?? message?.From?.FirstName;
        logger.LogInformation("Received Message from {username}", username);

        return Task.CompletedTask;
    }
}