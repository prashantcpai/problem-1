# Exercise 3: Checkout Discount Calculator

**Time:** 30 minutes
**Language:** Pick one of TypeScript, JavaScript, Python, Java, Ruby, C#, or pseudocode. Every version behaves the same way.

## Background

Our e-commerce platform runs a sale for a sports retailer. Marketing has launched two offers, and a developer has implemented the checkout total. All tests pass, and it's about to ship.

## Spec

From Marketing's brief:

> - Orders above ₹1000 get 10% off.
> - Coupon **SAVE200** takes ₹200 off the order.
> - Totals are in rupees, to two decimal places.

## Implementation

Full runnable code and tests are in this folder.

### TypeScript

```typescript
export function total(items: Item[], coupon: string | null = null): number {
  let subtotal = items.reduce((sum, item) => sum + item.price * item.qty, 0);
  if (coupon === "SAVE200") {
    subtotal -= 200;
  }
  if (subtotal > 1000) {
    subtotal *= 0.9;
  }
  return Math.round(subtotal * 100) / 100;
}
```

### JavaScript

```javascript
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
```

### Python

```python
def total(items, coupon=None):
    subtotal = sum(item.price * item.qty for item in items)
    if coupon == "SAVE200":
        subtotal -= 200
    if subtotal > 1000:
        subtotal *= 0.9
    return round(subtotal, 2)
```

### Java

```java
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
```

### Ruby

```ruby
def self.total(items, coupon = nil)
  subtotal = items.sum { |item| item.price * item.qty }
  subtotal -= 200 if coupon == "SAVE200"
  subtotal *= 0.9 if subtotal > 1000
  subtotal.round(2)
end
```

### C#

```csharp
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
```

### Pseudocode

```text
function TOTAL(items, coupon = NONE):
    subtotal = sum of (item.price × item.qty) for each item
    if coupon is "SAVE200":
        subtotal = subtotal − 200
    if subtotal > 1000:
        subtotal = subtotal × 0.9
    return subtotal rounded to 2 decimal places
```

## Your task

1. **Predict without running anything:**
   - A cart worth ₹150 with SAVE200 applied.
   - A cart worth ₹1,100, with SAVE200 and without it.
2. **Is this ready to ship?** Compare the code to Marketing's brief. Tell us what you'd raise, and who you'd raise it with.
3. **If time allows,** add a test for your top concern, or sketch the fix.

You can run the code and tests at any time. Please think out loud, and ask as many questions as you like: anything you could find out on the job, we'll tell you.

## Running the code

| Language | Folder | Command |
|---|---|---|
| TypeScript | `typescript/` | `npm install && npm test` |
| JavaScript | `javascript/` | `npm test` (Node 18+) |
| Python | `python/` | `python -m unittest` (Python 3.9+) |
| Java | `java/` | `javac -d out src/*.java test/*.java && java -cp out CheckoutTest` (JDK 17+) |
| Ruby | `ruby/` | `ruby test_checkout.rb` |
| C# | `csharp/` | `dotnet run` (.NET 8+) |
