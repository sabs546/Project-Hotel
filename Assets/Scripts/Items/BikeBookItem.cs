public class BikeBookItem : Item
{
    public override void GenerateItem(ref Item item)
    {
        item.ID = 4;
        item.name = "Chopper lifestyle";
        item.description = "A book on bikes, she doesn't seem like the type though";
    }
}
