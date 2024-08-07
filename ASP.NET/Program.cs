using Newtonsoft.Json;
using System.Net.Http;
using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

class MainClass
{
    static async Task Main()
    {
        HttpClient client = new HttpClient();
        string response = await client.GetStringAsync("https://coderbyte.com/api/challenges/json/json-cleaning");

        JObject jsonObject = JObject.Parse(response);

        //CleanJson(jsonObject);


        foreach (JToken token in jsonObject.Descendants().ToList())
        {
            if (token.Parent is JProperty property)
            {
                var value = property.Value.ToString();

                if (ShouldRemoveToken(value))
                {
                    property.Remove();
                }
            }
            else if (token.Parent is JArray array && ShouldRemoveToken(token.ToString()))
            {
                token.Remove();
            }
        }

        string cleanedJson = jsonObject.ToString(Formatting.Indented);

        Console.WriteLine(cleanedJson);
    }

    static bool ShouldRemoveToken(string token)
    {
        return string.IsNullOrEmpty(token) || token == "N/A" || token == "-";
    }

    static void CleanJson(JToken token)
    {
        if (token is JValue value)
        {
            if (value.Type == JTokenType.String && (value.Value<string>() == "N/A" || value.Value<string>() == "-" || string.IsNullOrEmpty(value.Value<string>())))
            {
                value.Parent.Remove();
            }
        }
        else if (token is JArray array)
        {
            for (int i = array.Count - 1; i >= 0; i--)
            {
                if (array[i] is JValue arrayValue && arrayValue.Type == JTokenType.String && arrayValue.Value<string>() == "-")
                {
                    arrayValue.Remove();
                }
                else
                {
                    CleanJson(array[i]);
                }
            }
        }
        else if (token is JObject obj)
        {
            var propertiesToRemove = new List<JProperty>();
            foreach (var property in obj.Properties())
            {
                if (property.Value is JValue propValue && propValue.Type == JTokenType.String &&
                    (propValue.Value<string>() == "N/A" || propValue.Value<string>() == "-" || string.IsNullOrEmpty(propValue.Value<string>())))
                {
                    propertiesToRemove.Add(property);
                }
                else
                {
                    CleanJson(property.Value);
                }
            }
            foreach (var property in propertiesToRemove)
            {
                property.Remove();
            }
        }
    }

    public class MyClass
    {
        public string data { get; set; }
    }

    static async Task<int> MainO()
    {
        HttpClient client = new HttpClient();
        string response = await client.GetStringAsync("https://coderbyte.com/api/challenges/json/age-counting");

        MyClass jsonResponse = JsonConvert.DeserializeObject<MyClass>(response);

        string data = jsonResponse!.data;

        var listKey = data.Split(", ");

        int ageOver50 = 0;

        foreach (var key in listKey)
        {
            var curr = key.Split("=");

            if (curr[0] == "age" && int.Parse(curr[1]) >= 50)
            {
                ageOver50++;
            }
        }

        Console.WriteLine(ageOver50);


        return ageOver50;

    }
}
