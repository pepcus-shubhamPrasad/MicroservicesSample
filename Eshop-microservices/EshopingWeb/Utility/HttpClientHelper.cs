using System.Text.Json;
using System.Text;

namespace EshopingWeb.Utility
{
    public class HttpClientHelper
    {
        private readonly HttpClient _httpClient;

        public HttpClientHelper(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<T?> SendAsync<T>(HttpMethod method, string url, object? payload = null, Dictionary<string, string>? headers = null)
        {
            try
            {
                var request = new HttpRequestMessage(method, url);

                if (payload != null)
                {
                    var jsonPayload = JsonSerializer.Serialize(payload);
                    request.Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
                }

                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        request.Headers.Add(header.Key, header.Value);
                    }
                }

                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in {method} request: {ex.Message}");
                return default;
            }
        }

        public async Task<T?> GetAsync<T>(string url, Dictionary<string, string>? headers = null)
        {
            try
            {
                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }

                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Raw Response: {content}");
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                return JsonSerializer.Deserialize<T>(content, options);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GET request: {ex.Message}");
                return default;
            }
        }
        public async Task<T?> PostAsync<T>(string url, object payload, Dictionary<string, string>? headers = null)
        {
            try
            {
                // Serialize the payload to JSON
                var jsonPayload = JsonSerializer.Serialize(payload, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = content
                };

                // Add headers to the request
                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        request.Headers.Add(header.Key, header.Value);
                    }
                }

                // Add Accept header
                request.Headers.Add("Accept", "*/*");

                // Send the request
                var response = await _httpClient.SendAsync(request);

                // Log response for debugging
                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response Status: {response.StatusCode}");
                Console.WriteLine($"Response Content: {responseContent}");

                response.EnsureSuccessStatusCode();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                return JsonSerializer.Deserialize<T>(responseContent, options);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in POST request: {ex.Message}");
                return default;
            }
        }




        public async Task<bool> DeleteAsync(string url, Dictionary<string, string>? headers = null)
        {
            var response = await SendAsync<object>(HttpMethod.Delete, url, null, headers);
            return response != null;
        }
    }
}
