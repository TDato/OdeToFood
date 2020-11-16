using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            this.restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Sabatino's", Location = "Chicago", Cuisine = CuisineType.Italian},
                new Restaurant { Id = 2, Name = "Vegan Plate", Location = "Chicago", Cuisine = CuisineType.Thai},
                new Restaurant { Id = 3, Name = "Quesadilla La Rena Del Sur", Location = "Chicago", Cuisine = CuisineType.Mexican},
                new Restaurant { Id = 4, Name = "Uru-Swati", Location = "Chicago", Cuisine = CuisineType.Indian}

            };
        }
        public int Commit()
        {
            // ToDo: update when using a real datasource
            return 0;
        }
        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }

        /**
         * This is only for working inside a development environment. 
         * It's just here to provide data to focus on building other parts of the
         * application until I come back and start working with SQL Server
         *
         */
        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            // TO DO: Work with SQL Server

            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.Contains(name, StringComparison.OrdinalIgnoreCase)
                   orderby r.Name
                   select r;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public int GetCountOfRestaurants()
        {
            return restaurants.Count();
        }
    }
}
