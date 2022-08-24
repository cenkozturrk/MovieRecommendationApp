namespace MovieRecommendationApp.BackgroundJobs
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private IHttpClientFactory _client;
        private int count;

        public Worker(ILogger<Worker> logger, IHttpClientFactory client)
        {
            _logger = logger;
            _client = client;

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var result = await _client.CreateClient().GetAsync("https://api.themoviedb.org/3/movie/popular?api_key=eb46a1d6e27b97fe9b1e9e665465e6c1");

                if (result.IsSuccessStatusCode)
                    _logger.LogInformation("Movie data extraction was successful. Statuc code {StatusCode}", result.StatusCode);
                else
                    _logger.LogError("Failed to pull data. Status code {StatusCode}", result.StatusCode);

                _logger.LogInformation($"Worker has run {count} times");
                count++;
                await Task.Delay(5000, stoppingToken);
            }
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            //_client = new HttpClient();
            _logger.LogInformation("Worker starting...");
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            //_client.Dispose();
            _logger.LogInformation("Worker stopping");
            return base.StopAsync(cancellationToken);
        }
    }
}