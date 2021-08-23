public class OddCheeseItem : Item
{
    public override void GenerateItem(ref Item item)
    {
        item.ID = 3;
        item.name = "Odd Cheese";
        item.description = "So... you paid a weird orange man your only bit of money, then you traded that... so now you have this... \"cheese\"...";
    }
}
