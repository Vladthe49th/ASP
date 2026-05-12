from django.shortcuts import render


class Product:
    def __init__(self, name, price, image, description, category):
        self.name = name
        self.price = price
        self.image = image
        self.description = description
        self.category = category


def products_view(request):
    products = [
        Product(
            "Macbook",
            52000,
            "Shop/images/MacBook.png",
            "A shiny computer for a shiny price",
            "Electronics"
        ),
        Product(
            "Wireless Mouse",
            1200,
            "shop/images/Mouse.png",
            "Won`t work with your pc, but looks cute",
            "Accessories"
        ),
        Product(
            "A batman toy",
            3400,
            "shop/images/Toy.jpg",
            "Nothing wrong here",
            "Accessories"
        ),
        Product(
            "Sausages",
            2800,
            "shop/images/Sasages.png",
            "Eat or wear them",
            "Food"
        ),
        
    ]

    return render(request, "shop/products.html", {
        "products": products
    })