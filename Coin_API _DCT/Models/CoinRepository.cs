using System;
using System.Collections.Generic;
using System.Linq;

namespace Coin_API__DCT.Models
{
    public class CoinRepository
    {
        private JsonFile jsonFile { get; }
        private Asset Asset { get; set; }
        private string CoinId { get; set; }
        private string filePath = "Files/file.json";
        public API api;

        private string selectedAPI;
        public string SelectedAPI

        {
            get { return selectedAPI; }

            set
            {
                switch (api)
                {
                    case API.AssetsApi:
                        value = "https://api.coincap.io/v2/assets";
                        break;
                    case API.AssetsHistoryApi:
                        value = $"https://api.coincap.io/v2/assets/{CoinId}/history?interval=d1";
                        break;
                    case API.AssetsMarketsApi:
                        value = $"https://api.coincap.io/v2/assets/{CoinId}/markets";
                        break;
                    case API.RatesApi:
                        value = "https://api.coincap.io/v2/rates";
                        break;
                    case API.ExchangesApi:
                        value = "https://api.coincap.io/v2/exchanges";
                        break;
                    case API.MarketsApi:
                        value = "https://api.coincap.io/v2/markets";
                        break;
                    default:
                        value = "https://api.coincap.io/v2/assets";
                        break;
                }
                selectedAPI = value;
            }
        }

        public CoinRepository()
        {
            jsonFile = new JsonFile(selectedAPI);
            jsonFile.GetJsonFile();
        }
        public CoinRepository(API api) : base()
        {
            this.api = api;
        }
        public CoinRepository(API api, string coinId) : base()
        {
            this.api = api;
            this.CoinId = coinId;
        }

        public IEnumerable<Asset> GetAllCoins()
        {
            var list = JsonConvert.DeserializeObject<IEnumerable<Asset>>(File.ReadAllText(filePath));

            return list;
        }

        public Asset GetCoinByRank(int rank)
        {
            var list = JsonConvert.DeserializeObject<IEnumerable<Asset>>(File.ReadAllText(filePath));

            Asset = list.Where(r => r.Rank == rank).FirstOrDefault();

            return Asset;
        }

        public IEnumerable<Asset> GetNCoins(int number)
        {
            var list = JsonConvert.DeserializeObject<IEnumerable<Asset>>(File.ReadAllText(filePath));

            if (number >= 0)
            {
                return list.Where(r => r.Rank > 0 && r.Rank <= number);
            }

            return list;
        }

        public IEnumerable<Asset> GetFromToCoinsByRank(int from, int till)
        {
            var list = JsonConvert.DeserializeObject<IEnumerable<Asset>>(File.ReadAllText(filePath));

            if (from >= 0 && till >= 0 && till > from)
            {
                return list.Where(r => r.Rank >= from && r.Rank <= till);
            }

            return new List<Asset>() {
                new Asset()
                {
                    Id = "Not Found",
                    Rank = 0,
                    Symbol = "-",
                    Name = "-",
                    Supply = 0,
                    MaxSupply = 0,
                    MarketCapUsd = 0,
                    VolumeUsd24Hr = 0,
                    PriceUsd = 0,
                    ChangePercent24Hr = 0,
                    Vwap24Hr = 0,
                    Explorer = "-"
                }};
        }

        public IEnumerable<Asset> SearchCoin(string search)
        {
            var list = JsonConvert.DeserializeObject<IEnumerable<Asset>>(File.ReadAllText(filePath));

            if (search == null)
            {
                return list;
            }

            var result = list.Where(n => n.Name.Contains(search) ||
                                    n.Name.Contains(search.ToLower()) ||
                                    n.Name.Contains(search.ToUpper()) ||
                                    n.Name.Contains(search.ToLower().Replace(search[0], char.ToUpper(search[0]))) ||
                                    n.Symbol.Contains(search) ||
                                    n.Symbol.Contains(search.ToLower()) ||
                                    n.Symbol.Contains(search.ToLower().Replace(search[0], char.ToUpper(search[0]))) ||
                                    n.Symbol.Contains(search.ToUpper())).ToList();

            if (result.Count == 0)
            {
                return new List<Asset>() {
                new Asset()
                {
                    Id = "Not Found",
                    Rank = 0,
                    Symbol = "-",
                    Name = search,
                    Supply = 0,
                    MaxSupply = 0,
                    MarketCapUsd = 0,
                    VolumeUsd24Hr = 0,
                    PriceUsd = 0,
                    ChangePercent24Hr = 0,
                    Vwap24Hr = 0,
                    Explorer = "-"
                }};
            }

            return result;
        }
    }
    public enum API
    {
        AssetsApi,
        AssetsHistoryApi,
        AssetsMarketsApi,
        RatesApi,
        ExchangesApi,
        MarketsApi
    }
}
}
