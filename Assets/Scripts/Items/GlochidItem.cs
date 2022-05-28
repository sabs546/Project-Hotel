public class GlochidItem : Item
{
    public override void GenerateItem(ref Item item)
    {
        item.ID = 5;
        item.name = "Glochid";
        item.description = "Ouch";
    }
}
