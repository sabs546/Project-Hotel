public class GenericItem : Item
{
    public override void GenerateItem(ref Item item)
    {
        item.ID = 0;
        item.name = "Generic item";
        item.description = "Generic test item";
    }
}
