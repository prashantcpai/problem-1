from dataclasses import dataclass


@dataclass
class Item:
    name: str
    price: float
    qty: int


def total(items, coupon=None):
    subtotal = sum(item.price * item.qty for item in items)
    if coupon == "SAVE200":
        subtotal -= 200
    if subtotal > 1000:
        subtotal *= 0.9
    return round(subtotal, 2)
