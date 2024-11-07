using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class item
{
    public required int ItemID { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    public item(int ItemId, string name, double price, int quantity)
    {
        ItemID = ItemId;
        Name = name;
        Price = price;
        Quantity = quantity;
    }


}

