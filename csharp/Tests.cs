public static class Tests
{
    public static async Task<int> Main()
    {
        await Check.Test("no discount below threshold", () =>
            Check.Equal(500.0, Checkout.Total(new[] { new Item("Yoga mat", 500, 1) })));

        await Check.Test("no discount at exactly 1000", () =>
            Check.Equal(1000.0, Checkout.Total(new[] { new Item("Dumbbells", 1000, 1) })));

        await Check.Test("ten percent off above 1000", () =>
            Check.Equal(1800.0, Checkout.Total(new[] { new Item("Running shoes", 2000, 1) })));

        await Check.Test("adds up quantities", () =>
            Check.Equal(950.0, Checkout.Total(new[] { new Item("Socks", 150, 4), new Item("Cap", 350, 1) })));

        await Check.Test("coupon on small order", () =>
            Check.Equal(400.0, Checkout.Total(new[] { new Item("Bottle", 300, 2) }, "SAVE200")));

        await Check.Test("coupon on large order", () =>
            Check.Equal(1620.0, Checkout.Total(new[] { new Item("Running shoes", 2000, 1) }, "SAVE200")));

        return Check.Finish();
    }
}
