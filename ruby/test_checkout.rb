require "minitest/autorun"
require_relative "checkout"

class TotalTest < Minitest::Test
  def test_no_discount_below_threshold
    assert_equal 500, Checkout.total([Item.new("Yoga mat", 500, 1)])
  end

  def test_no_discount_at_exactly_1000
    assert_equal 1000, Checkout.total([Item.new("Dumbbells", 1000, 1)])
  end

  def test_ten_percent_off_above_1000
    assert_equal 1800, Checkout.total([Item.new("Running shoes", 2000, 1)])
  end

  def test_adds_up_quantities
    assert_equal 950, Checkout.total([Item.new("Socks", 150, 4), Item.new("Cap", 350, 1)])
  end

  def test_coupon_on_small_order
    assert_equal 400, Checkout.total([Item.new("Bottle", 300, 2)], "SAVE200")
  end

  def test_coupon_on_large_order
    assert_equal 1620, Checkout.total([Item.new("Running shoes", 2000, 1)], "SAVE200")
  end
end
