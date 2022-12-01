using System.Net;
using System.Text;
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

    public FakePost AddNew(FakePost insertFakePost)
    {
        HttpClient httpClient = new HttpClient();
        string insertFakePostAsJson = JsonSerializer.Serialize(insertFakePost);

        HttpContent httpContent = new StringContent(insertFakePostAsJson, Encoding.UTF8, "application/json");

        string addedFakePostAsJson = httpClient.PostAsync("https://jsonplaceholder.typicode.com/posts", httpContent)
            .Result.Content.ReadAsStringAsync().Result;

        FakePost addedFakePost = JsonSerializer.Deserialize<FakePost>(addedFakePostAsJson);

        return addedFakePost;
    }

    public bool DeleteById(int id)
    {
        HttpClient httpClient = new HttpClient();
        
        HttpStatusCode statusCode = httpClient.DeleteAsync($"https://jsonplaceholder.typicode.com/posts/{id}").Result
            .StatusCode;

        return statusCode == HttpStatusCode.OK;
    }
    
    public FakePost UpdateById(int id, FakePost insertFakePost)
    {
        HttpClient httpClient = new HttpClient();
        string updateFakePostAsJson = JsonSerializer.Serialize(insertFakePost);

        HttpContent httpContent = new StringContent(updateFakePostAsJson, Encoding.UTF8, "application/json");

        string updatedFakePostAsJson = httpClient.PutAsync($"https://jsonplaceholder.typicode.com/posts/{id}", httpContent)
            .Result.Content.ReadAsStringAsync().Result;

        FakePost updatedFakePost = JsonSerializer.Deserialize<FakePost>(updatedFakePostAsJson);

        return updatedFakePost;
    }
}