import java.util.List;

public class CheckoutTest {
    public static void main(String[] args) {
        Check.test("no discount below threshold", () ->
            Check.equal(500.0, Checkout.total(List.of(new Item("Yoga mat", 500, 1)))));

        Check.test("no discount at exactly 1000", () ->
            Check.equal(1000.0, Checkout.total(List.of(new Item("Dumbbells", 1000, 1)))));

        Check.test("ten percent off above 1000", () ->
            Check.equal(1800.0, Checkout.total(List.of(new Item("Running shoes", 2000, 1)))));

        Check.test("adds up quantities", () ->
            Check.equal(950.0, Checkout.total(List.of(new Item("Socks", 150, 4), new Item("Cap", 350, 1)))));

        Check.test("coupon on small order", () ->
            Check.equal(400.0, Checkout.total(List.of(new Item("Bottle", 300, 2)), "SAVE200")));

        Check.test("coupon on large order", () ->
            Check.equal(1620.0, Checkout.total(List.of(new Item("Running shoes", 2000, 1)), "SAVE200")));

        Check.finish();
    }
}
