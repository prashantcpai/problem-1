public record Item(string Name, double Price, int Qty);

public static class Checkout
{
    public static double Total(IEnumerable<Item> items, string? coupon = null)
    {
        var subtotal = items.Sum(item => item.Price * item.Qty);
        if (coupon == "SAVE200")
        {
            subtotal -= 200;
        }
        if (subtotal > 1000)
        {
            subtotal *= 0.9;
        }
        return Math.Round(subtotal, 2);
    }
}
