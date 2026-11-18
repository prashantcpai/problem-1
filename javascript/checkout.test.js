const test = require("node:test");
const assert = require("node:assert/strict");
const { total } = require("./checkout");

const item = (name, price, qty) => ({ name, price, qty });

test("no discount below threshold", () => {
  assert.equal(total([item("Yoga mat", 500, 1)]), 500);
});

test("no discount at exactly 1000", () => {
  assert.equal(total([item("Dumbbells", 1000, 1)]), 1000);
});

test("ten percent off above 1000", () => {
  assert.equal(total([item("Running shoes", 2000, 1)]), 1800);
});

test("adds up quantities", () => {
  assert.equal(total([item("Socks", 150, 4), item("Cap", 350, 1)]), 950);
});

test("coupon on small order", () => {
  assert.equal(total([item("Bottle", 300, 2)], "SAVE200"), 400);
});

test("coupon on large order", () => {
  assert.equal(total([item("Running shoes", 2000, 1)], "SAVE200"), 1620);
});
