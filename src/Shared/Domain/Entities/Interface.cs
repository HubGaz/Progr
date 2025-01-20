namespace Domain.Entities
{
    public interface IInventory
    {
        List<Item> GetItems();
        bool ItemExists(int itemId);
        bool CanReserve(int itemId, int amount);
        void ReserveItem(int itemId, int amount);
        void AddItem(Item item);
    }
}