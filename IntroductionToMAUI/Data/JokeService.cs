
using Newtonsoft.Json;

namespace IntroductionToMAUI.Data;

public class JokeService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public JokeService(IHttpClientFactory httpClientFactory)
        => _httpClientFactory = httpClientFactory;

    public async Task<JokePoco> GetJoke()
        => JsonConvert.DeserializeObject<JokePoco>(
            await
                (await _httpClientFactory
                .CreateClient()
                .GetAsync("https://v2.jokeapi.dev/joke/Programming?blacklistFlags=nsfw,racist,sexist&type=single")
                )
                .Content
                .ReadAsStringAsync());

    public async Task<JokesPoco> GetJokes(int nb = 10)
        => JsonConvert.DeserializeObject<JokesPoco>(
                await (
                    await _httpClientFactory
                    .CreateClient()
                    .GetAsync($"https://v2.jokeapi.dev/joke/Programming?blacklistFlags=nsfw,racist,sexist&type=single&amount={nb}")
                )
                .Content
                .ReadAsStringAsync()
            );
}

public class JokePoco : ListJokePoco
{
    [JsonProperty("error")]
    public bool Error { get; set; }
}

public class ListJokePoco
{

    [JsonProperty("category")]
    public string Category { get; set; }

    [JsonProperty("joke")]
    public string Joke { get; set; }

    [JsonProperty("flags")]
    public Flags Flags { get; set; }

    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("safe")]
    public bool Safe { get; set; }

    [JsonProperty("lang")]
    public string Lang { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }
}

public class JokesPoco
{
    [JsonProperty("error")]
    public bool Error { get; set; }

    [JsonProperty("amount")]
    public string Amount { get; set; }

    [JsonProperty("jokes")]
    public List<ListJokePoco> Jokes { get; set; }
}

public class Flags
{
    [JsonProperty("nsfw")]
    public bool Nsfw { get; set; }

    [JsonProperty("religious")]
    public bool Religious { get; set; }

    [JsonProperty("political")]
    public bool Political { get; set; }

    [JsonProperty("racist")]
    public bool Racist { get; set; }

    [JsonProperty("sexist")]
    public bool Sexist { get; set; }

    [JsonProperty("explicit")]
    public bool Explicit { get; set; }
}
