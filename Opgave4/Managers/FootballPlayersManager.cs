using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opgave4.Managers
{
    public class FootballPlayersManager
    {
        private static int _nextId = 1;
        private static readonly List<FootballPlayer.FootballPlayer> Data = new List<FootballPlayer.FootballPlayer>
        {
            new FootballPlayer.FootballPlayer {Id = _nextId++, Name = "David", Price = 999999999, ShirtNumber = 42},
            new FootballPlayer.FootballPlayer {Id = _nextId++, Name = "Emil", Price = 100, ShirtNumber = 10},
            new FootballPlayer.FootballPlayer {Id = _nextId++, Name = "Kasper", Price = 100, ShirtNumber = 11},
        };

        public List<FootballPlayer.FootballPlayer> GetAll()
        {
            return new List<FootballPlayer.FootballPlayer>(Data);
        }

        public FootballPlayer.FootballPlayer GetById(int id)
        {
            return Data.Find(footballplayer => footballplayer.Id == id);
        }

        public FootballPlayer.FootballPlayer Add(FootballPlayer.FootballPlayer newFootballPlayer)
        {
            newFootballPlayer.Id = _nextId++;
            Data.Add(newFootballPlayer);
            return newFootballPlayer;
        }

        public FootballPlayer.FootballPlayer Delete(int id)
        {
            FootballPlayer.FootballPlayer footballplayer = Data.Find(footballplayer1 => footballplayer1.Id == id);
            if (footballplayer == null) return null;
            Data.Remove(footballplayer);
            return footballplayer;
        }

        public FootballPlayer.FootballPlayer Update(int id, FootballPlayer.FootballPlayer updates)
        {
            FootballPlayer.FootballPlayer footballplayer = Data.Find(footballplayer1 => footballplayer1.Id == id);
            if (footballplayer == null) return null;
            footballplayer.Name = updates.Name;
            footballplayer.ShirtNumber = updates.ShirtNumber;
            return footballplayer;
        }
    }
}
