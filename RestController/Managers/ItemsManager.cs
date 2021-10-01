﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Collections.Generic;
using RestController.Models;

namespace RestController.Managers
{
    public class ItemsManager
    {
        private static int _nextId = 1;
        private static readonly List<Item> Data = new List<Item>
        {
            new Item {Id = _nextId++, Name = "C# is nice", Itemquality = 12, Quantity = 12},
            new Item {Id=_nextId++, Name = "Python is even nicer", Itemquality = 22, Quantity = 22}
            // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers
        };

        public List<Item> GetAll(string substring)
        {
            //return new List<Item>(Data);
            List<Item> result = new List<Item>(Data);
            if (substring != null)
            {
                result = Data.FindAll(item => item.Name.Contains(substring, StringComparison.OrdinalIgnoreCase));
            }

            return result;
            // copy constructor
            // Callers should no get a reference to the Data object, but rather get a copy
        }

        /*public Item GetById(int id)
        {
            return Data.Find(item => item.Id == id);
        }*/

        public Item Add(Item newItem)
        {
            newItem.Id = _nextId++;
            Data.Add(newItem);
            return newItem;
        }

        public Item Delete(int id)
        {
            Item item = Data.Find(item1 => item1.Id == id);
            if (item == null) return null;
            Data.Remove(item);
            return item;
        }

        public Item Update(int id, Item updates)
        {
            Item item = Data.Find(item1 => item1.Id == id);
            if (item == null) return null;
            item.Name = updates.Name;
            item.Itemquality = updates. Itemquality;
            return item;
        }
    }
}
