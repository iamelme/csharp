using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

HttpClient client = new()
{
    BaseAddress = new Uri("https://jsonplaceholder.typicode.com")
};

try
{



    //var posts = await GetAsync<List<Post>>("/posts", client);

    //foreach (Post post in posts)
    //{
    //    Console.WriteLine("Title {0}", post.Title);
    //    Console.WriteLine("Body {0}", post.Body);
    //}


    //var post = await GetAsync<Post>("/posts/52", client);

    //Console.WriteLine(post.Id);
    //Console.WriteLine($"{post.Title} \n");
    //Console.WriteLine(post.Body);

    Post post1 = new Post()
    {
        UserId = 77,
        Title = "write code sample",
        Body = "test body"
    };

    var post = await AddPost<Post>("/posts", client, post1);


    Console.WriteLine(post);

}
catch (HttpRequestException e)
{
    Console.WriteLine(e.StatusCode);
}


static async Task<TReturn> GetAsync<TReturn>(string extended, HttpClient client)
{
    HttpResponseMessage res = await client.GetAsync(extended);

    if (res.IsSuccessStatusCode)
    {
        return await res.Content.ReadFromJsonAsync<TReturn>();
    }
    else
    {
        string msg =  "something went wrong";
        // TODO: return a proper error message
        throw new Exception(msg);
    }

}

static async Task<TResult> AddPost<TResult>(string extended, HttpClient client, Post payload)
{
    StringContent jsonContent = new(JsonSerializer.Serialize(new
    {
        userId = payload.UserId,
        title = payload.Title,
        body = payload.Body,
    }), Encoding.UTF8,
        "application/json");

    HttpResponseMessage res = await client.PostAsync(extended, jsonContent);

   if(res.IsSuccessStatusCode)
    {
        return await res.Content.ReadFromJsonAsync<TResult>();
    } else
    {
        string msg = "something went wrong";
        // TODO: return a proper error message
        throw new Exception(msg);
    }
}