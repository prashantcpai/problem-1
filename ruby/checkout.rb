Item = Struct.new(:name, :price, :qty)

module Checkout
  def self.total(items, coupon = nil)
    subtotal = items.sum { |item| item.price * item.qty }
    subtotal -= 200 if coupon == "SAVE200"
    subtotal *= 0.9 if subtotal > 1000
    subtotal.round(2)
  end
end
