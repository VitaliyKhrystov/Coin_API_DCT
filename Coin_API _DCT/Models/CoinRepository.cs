using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Sockets;

namespace Coin_API__DCT.Models
{
    public class CoinRepository
    {
        public JsonFile jsonFile { get; set;}
        public Asset Asset { get; set; }
        public Exchange Exchange { get; set; }
        public string CoinId { get; set; }
        public string filePath = "Files/file.json";


        public CoinRepository(string selectedAPI)
        {
            GetFile(selectedAPI);
        }

        public ObservableCollection<Asset> GetAllCoins()
        {
            var collectionList = new ObservableCollection<Asset>();

            var list = JsonConvert.DeserializeObject<IEnumerable<Asset>>(File.ReadAllText(filePath));

            foreach (var item in list)
            {
                collectionList.Add(item);
            }

            return collectionList;
        }

        public Asset GetCoinByRank(int rank)
        {

            var list = JsonConvert.DeserializeObject<IEnumerable<Asset>>(File.ReadAllText(filePath));

            Asset = list.Where(r => r.Rank == rank).FirstOrDefault();

            if (Asset != null)
            {
                return Asset;
            }

            return new Asset()
            {
                Id = $"Rank {rank} Not Found",
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
            };
        }

        public Exchange GetCoinByIdExchange(string id)
        {
         
            var list = JsonConvert.DeserializeObject<IEnumerable<Exchange>>(File.ReadAllText(filePath));

            Exchange = list.Where(r => r.Id == id).FirstOrDefault();

            if (Asset != null)
            {
                return Exchange;
            }

            return new Exchange()
            {
                Id = $"Id {id} Not Found",
                Rank = 0,
                Name = "-",
                PercentTotalVolume = 0,
                VolumeUsd = 0,
                TradingPairs = 0 ,
                Socket = false,
                ExchangeUrl = "-",
                Updated = default
            };
        }

        public ObservableCollection<Asset> GetNCoins(int number)
        {
            var collectionList = new ObservableCollection<Asset>();

            var list = JsonConvert.DeserializeObject<IEnumerable<Asset>>(File.ReadAllText(filePath));

            if (number >= 0)
            {
                foreach (var item in list.Where(r => r.Rank > 0 && r.Rank <= number))
                {
                    collectionList.Add(item);

                }
                return collectionList;
            }

            foreach (var item in list)
            {
                collectionList.Add((Asset)item);
            }
            return collectionList;
        }

        public ObservableCollection<Asset> GetFromToCoinsByRank(int from, int till)
        {
            var collectionList = new ObservableCollection<Asset>();
            var list = JsonConvert.DeserializeObject<IEnumerable<Asset>>(File.ReadAllText(filePath));

            if (from >= 0 && till >= 0 && till > from)
            {
                foreach (var item in list.Where(r => r.Rank >= from && r.Rank <= till))
                {
                    collectionList.Add(item);
                }
                return collectionList;
            }

            collectionList.Add(new Asset()
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
            });

            return collectionList;
        }

        public ObservableCollection<Asset> SearchCoin(string search)
        {
            var collectionList = new ObservableCollection<Asset>();

            var list = JsonConvert.DeserializeObject<IEnumerable<Asset>>(File.ReadAllText(filePath));

            if (search == null)
            {
                foreach (var item in list)
                {
                    collectionList.Add(item);
                }
                return collectionList;
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
                collectionList.Add(new Asset()
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
                });

                return collectionList;
            }

            foreach (var item in result)
            {
                collectionList.Add(item);
            }

            return collectionList;
        }

        public void GetFile(string apilink)
        {
            jsonFile = new JsonFile(apilink);
            jsonFile.GetJsonFile();
        }
    }

}

