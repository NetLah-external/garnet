using Garnet;

namespace NetLah.GarnetHost;

public class Worker(string[] args) : BackgroundService
{
    private bool _isDisposed = false;
    private readonly string[] args = args;

    private GarnetServer? _server;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            _server = new GarnetServer(args);

            // Start the server
            _server.Start();

            await Task.Delay(Timeout.Infinite, stoppingToken).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unable to initialize server due to exception: {ex.Message}");
        }
    }

    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        Dispose();
        await base.StopAsync(cancellationToken).ConfigureAwait(false);
    }

    public override void Dispose()
    {
        if (_isDisposed)
        {
            return;
        }
        _server?.Dispose();
        _isDisposed = true;
    }
}
