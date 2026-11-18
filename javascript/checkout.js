function total(items, coupon = null) {
  let subtotal = items.reduce((sum, item) => sum + item.price * item.qty, 0);
  if (coupon === "SAVE200") {
    subtotal -= 200;
  }
  if (subtotal > 1000) {
    subtotal *= 0.9;
  }
  return Math.round(subtotal * 100) / 100;
}

module.exports = { total };
