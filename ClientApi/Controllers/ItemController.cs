using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using clientapi.models;
using Microsoft.EntityFrameworkCore;

namespace ClientApi.Controllers
{
    [Route("api/items")]
    public class ItemController : Controller
    {
        private DataContext context;
        public ItemController(DataContext ctx)
        {
            context = ctx;
        }

        [HttpGet("{id}")]
        public Item GetItem(long id)
        {
            Item result = context.Items
            .Include(m => m.Studio).ThenInclude(s => s.Items)
            .Include(m => m.Ratings)
            .FirstOrDefault(m => m.ItemId == id);

            if (result != null)
            {
                if (result.Studio != null)
                {
                    result.Studio.Items = result.Studio.Items.Select(s=>
                    new Item{
                            ItemId = s.ItemId,
                            Name = s.Name,
                            Category = s.Category,
                            Description = s.Description,
                            Price = s.Price
                    });
                }
                if (result.Ratings != null)
                {
                    foreach (Rating r in result.Ratings)
                    {
                        r.Item = null;
                    }
                }
            }

            return result;
        }

        [HttpGet]
        public IEnumerable<Item> GetItems(string category, string search,
                                            bool related = false)
        {
            IQueryable<Item> query = context.Items;
            if (!string.IsNullOrWhiteSpace(category))
            {
                string catLower = category.ToLower();
                query = query.Where(m => m.Category.ToLower().Contains(catLower));
            }
            if (!string.IsNullOrWhiteSpace(search))
            {
                string searchLower = search.ToLower();
                query = query.Where(m => m.Name.ToLower().Contains(searchLower)
                || m.Description.ToLower().Contains(searchLower));
            }

            if (related)
            {
                query = query.Include(m => m.Studio).Include(m => m.Ratings);
                List<Item> data = query.ToList();
                data.ForEach(m =>
                {
                    if (m.Studio != null)
                    {
                        m.Studio.Items = null;
                    }
                    if (m.Ratings != null)
                    {
                        m.Ratings.ForEach(r => r.Item = null);
                    }
                });
                return data;
            }
            else
            {
                return query;
            }
        }


    }
}
