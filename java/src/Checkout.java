import java.util.List;

public final class Checkout {

    private Checkout() {
    }

    public static double total(List<Item> items) {
        return total(items, null);
    }

    public static double total(List<Item> items, String coupon) {
        double subtotal = 0;
        for (Item item : items) {
            subtotal += item.price() * item.qty();
        }
        if ("SAVE200".equals(coupon)) {
            subtotal -= 200;
        }
        if (subtotal > 1000) {
            subtotal *= 0.9;
        }
        return Math.round(subtotal * 100) / 100.0;
    }
}
