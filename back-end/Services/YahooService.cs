﻿using System.Diagnostics;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.WebUtilities;

namespace Stockaccino.Services;

public class YahooService
{
    private readonly string _baseUrl = "https://yfapi.net/";
    private HttpClient _client = new HttpClient();

    private readonly Dictionary<string, string> _endPoints =
        new Dictionary<string, string>() {
        {"trending", "v1/finance/trending/US"},
        {"autocomplete", "v6/finance/autocomplete"},
        {"quote", "v6/finance/quote"},
        {"suggestion", "ws/screeners/v1/finance/screener/predefined/saved"},
        {"chart", "v8/finance/chart/" }
        };

    public YahooService(string apiKey)
    {
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _client.DefaultRequestHeaders.Add("x-api-key", apiKey);
    }

    public async Task<string> GetTrending()
    {
        return await _client.GetStringAsync(_baseUrl + _endPoints["trending"]);
    }

    public async Task<string> GetScreeners(string screener)
    {
        var query = new Dictionary<string, string?>
        {
            ["count"] = "25",
            ["scrIds"] = screener,
        };

        return await _client.GetStringAsync(QueryHelpers.AddQueryString(_baseUrl + _endPoints["suggestion"], query));
    }

    internal async Task<string> GetAutocomplete(string input)
    {
        var query = new Dictionary<string, string?>
        {
            ["region"] = "CA",
            ["lang"] = "fr",
            ["query"] = input,
        };

        return await _client.GetStringAsync(QueryHelpers.AddQueryString(_baseUrl + _endPoints["autocomplete"], query));
    }

    public async Task<string> GetQuote(string symbol)
    {
        var query = new Dictionary<string, string?>
        {
            ["region"] = "CA",
            ["lang"] = "fr",
            ["symbols"] = symbol,
        };


        return await _client.GetStringAsync(QueryHelpers.AddQueryString(_baseUrl + _endPoints["quote"], query));
    }

    public async Task<string> GetQuote(string[] symbols)
    {
        return await GetQuote(string.Join(",", symbols));
    }

    public async Task<string> GetChart(string symbol, string range, string interval)
    {
        var query = new Dictionary<string, string?>
        {
            ["region"] = "CA",
            ["lang"] = "fr",
            ["range"] = range,
            ["interval"] = interval,
        };

        return await _client.GetStringAsync(QueryHelpers.AddQueryString(_baseUrl + _endPoints["chart"] + symbol, query));
    }

    public string ReloadApiKey()
    {
        Console.WriteLine("Limit Exceeded. Refreshing Api Key...");
        //_client.GetAsync("https://api.danlevy.ca/webhook/reloadyahooapikey");

        /*
        var psi = new ProcessStartInfo();
        psi.FileName = "/bin/bash";
        psi.Arguments = "/Users/danlevy/scripts/generateYahooApiKey";
        psi.RedirectStandardOutput = true;
        psi.UseShellExecute = false;
        psi.CreateNoWindow = true;

        using var process = Process.Start(psi);
        */

        return "reached limit";
    }
}
