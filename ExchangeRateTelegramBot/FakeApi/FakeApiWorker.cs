using System.Text.Json;

namespace ExchangeRateTelegramBot.FakeApi;

public class FakeApiWorker
{
    public FakePost GetById(int id)
    {
        HttpClient httpClient = new HttpClient();
        string jsonAsString = httpClient.GetStringAsync($"https://jsonplaceholder.typicode.com/posts/{id}").Result;

        FakePost fakePost = JsonSerializer.Deserialize<FakePost>(jsonAsString);

        return fakePost;
    }
    
    public List<FakePost> GetAll()
    {
        HttpClient httpClient = new HttpClient();
        string jsonAsString = httpClient.GetStringAsync($"https://jsonplaceholder.typicode.com/posts/").Result;

        List<FakePost> fakePosts = JsonSerializer.Deserialize<List<FakePost>>(jsonAsString);

        return fakePosts;
    }
}