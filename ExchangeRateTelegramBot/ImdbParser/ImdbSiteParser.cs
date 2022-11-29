using System.Globalization;
using HtmlAgilityPack;

namespace ExchangeRateTelegramBot.ImdbParser;

public class ImdbSiteParser
{
    public List<Film> getFirstFilmsFromTop250(int limit)
    {
        if (limit < 1 || limit > 250)
        {
            throw new Exception("Wrong limit. Limit Must be from 1 to 250");
        }

        HttpClient httpClient = new HttpClient();
        //string htmlAsString = httpClient.GetStringAsync("https://www.imdb.com/chart/top").Result;
        string htmlAsString = httpClient.GetStringAsync("https://www.kinonews.ru/games_top100/").Result;

        HtmlDocument htmlDocument = new HtmlDocument();
        htmlDocument.LoadHtml(htmlAsString);

        HtmlNodeCollection trs = htmlDocument.DocumentNode.SelectNodes("//tbody[@class='lister-list']/tr");

        List<Film> films = new List<Film>();

        for (int i = 0; i < limit; i++)
        {
            HtmlNode filmRatingNode = trs[i].SelectSingleNode("td[@class='ratingColumn imdbRating']");

            string filmRatingAsString = filmRatingNode.InnerText.Trim(new char[] { ' ', '\n' });
            decimal filmRating = decimal.Parse(filmRatingAsString, CultureInfo.InvariantCulture);

            HtmlNode filmInfoNode = trs[i].SelectSingleNode("td[@class='titleColumn']");

            string filmInfo = filmInfoNode.InnerText.Trim(new char[] { ' ', '\n' });

            int dotPosition = filmInfo.IndexOf(".");

            int filmNumber = int.Parse(filmInfo.Substring(0, dotPosition));

            filmInfo = filmInfo.Remove(0, dotPosition + 1).TrimStart(new char[] { ' ', '\n' });

            int enterPosition = filmInfo.IndexOf("\n");
            string filmName = filmInfo.Substring(0, enterPosition);
            filmInfo = filmInfo.Remove(0, enterPosition).TrimStart(new char[] { ' ', '\n' })
                .Trim(new char[] { '(', ')' });

            int filmYear = int.Parse(filmInfo);

            Film film = new Film()
            {
                Number = filmNumber,
                Name = filmName,
                Year = filmYear,
                Rating = filmRating
            };

            films.Add(film);
        }

        return films;
    }
}