public class DIYBookItem : Item
{
    public override void GenerateItem(ref Item item)
    {
        item.ID = 4;
        item.name = "DIY book";
        item.description = "You picked up a DIY book? She doesn't really seem like the type";
    }
}
