import unittest

from checkout import Item, total


class TotalTest(unittest.TestCase):
    def test_no_discount_below_threshold(self):
        self.assertEqual(total([Item("Yoga mat", 500, 1)]), 500)

    def test_no_discount_at_exactly_1000(self):
        self.assertEqual(total([Item("Dumbbells", 1000, 1)]), 1000)

    def test_ten_percent_off_above_1000(self):
        self.assertEqual(total([Item("Running shoes", 2000, 1)]), 1800)

    def test_adds_up_quantities(self):
        self.assertEqual(total([Item("Socks", 150, 4), Item("Cap", 350, 1)]), 950)

    def test_coupon_on_small_order(self):
        self.assertEqual(total([Item("Bottle", 300, 2)], coupon="SAVE200"), 400)

    def test_coupon_on_large_order(self):
        self.assertEqual(total([Item("Running shoes", 2000, 1)], coupon="SAVE200"), 1620)


if __name__ == "__main__":
    unittest.main()
