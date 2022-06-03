using Polly;
using Polly.Retry;

namespace RequestService.Policies;

public class ClientPolicy
{
    public AsyncRetryPolicy<HttpResponseMessage> ImmediateHttpRetry { get; }
    public AsyncRetryPolicy<HttpResponseMessage> LinearHttpRetry { get; }

    public AsyncRetryPolicy<HttpResponseMessage> ExponenTialHttpRetry { get; }

    public ClientPolicy()
    {
        ImmediateHttpRetry = Policy.HandleResult<HttpResponseMessage>(
            res => !res.IsSuccessStatusCode).RetryAsync(5);

        LinearHttpRetry = Policy.HandleResult<HttpResponseMessage>(
            res => !res.IsSuccessStatusCode).WaitAndRetryAsync(5, retryAttemp => TimeSpan.FromSeconds(3));

        ExponenTialHttpRetry = Policy.HandleResult<HttpResponseMessage>(
           res => !res.IsSuccessStatusCode).WaitAndRetryAsync(5, retryAttemp => TimeSpan.FromSeconds(Math.Pow(2, retryAttemp)));
    }
}
