namespace UrWarehouse{

    class Mainhouse{
        private Item[] inventory = new Item[]{};

        public Mainhouse(){
            inventory = new Item[]{
                new Item("Przedmiot 1",100,2),
                new Item("Przedmiot 2",33,300),
                new Item("Przedmiot 3",1,200),
                new Item("Przedmiot 4",5,13),
                new Item("Przedmiot 5",8,10),
                new Item("Przedmiot 6",13,100000)
            };
        }
                    public void ViewInventory()
        {
            // Calculate the column sizes based on the biggest item in each column
            int[] colSizes = {
                inventory.Max(i => i.Name.Length),
                inventory.Max(i => i.Price.ToString().Length),
                inventory.Max(i => i.Quantity.ToString().Length),
                inventory.Max(i => i.TotalPrice.ToString().Length)
            };

            // the colSize could be smaller than the column header
            if (colSizes[0] < "Inventory:".Length) colSizes[0] = "Inventory:".Length;
            if (colSizes[1] < "Price".Length) colSizes[1] = "Price".Length;
            if (colSizes[2] < "Quantity".Length) colSizes[2] = "Quantity".Length;
            if (colSizes[3] < "Total Price".Length) colSizes[3] = "Total Price".Length;

            // header row
            Console.Write("Inventory:".PadLeft(colSizes[0]));
            Console.Write("Price".PadLeft(colSizes[1] + 2));
            Console.Write("Quantity".PadLeft(colSizes[2] + 2));
            Console.WriteLine("Total Price".PadLeft(colSizes[3] + 2));

            // separator line
            Console.WriteLine(new string('-', colSizes.Sum() + 10));
            
            // each item row
            foreach (Item item in inventory)
            {
                Console.Write(item.Name.PadLeft(colSizes[0] + 2));
                Console.Write(item.Price.ToString().PadLeft(colSizes[1] + 2));
                Console.Write(item.Quantity.ToString().PadLeft(colSizes[2] + 2));
                Console.WriteLine(item.TotalPrice.ToString().PadLeft(colSizes[3] + 2));
            }

            // separator line
            Console.WriteLine(new string('-', colSizes.Sum() + 10));
        }
        public void AddItem(){}
        public void Search(){}

        }
    }

