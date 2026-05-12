from django.shortcuts import render

def home(request):
    return render(request, 'main/home.html')

def news(request):
    return render(request, 'main/news.html')

def news_404(request):
    raise Http404("Сторінку про новини не знайдено!")

def management(request):
    return render(request, 'main/management.html')

def about(request):
    return render(request, 'main/about.html')

def contacts(request):
    return render(request, 'main/contacts.html')

def custom_404(request, exception):
    return render(request, '404.html', status=404)

class Product:
    def __init__(self, name, price, discount, category):
        self.name = name
        self.price = price
        self.discount = discount
        self.category = category

def catalog(request):
    products = [
     Product("Навушники Samsung", 2500, 10, "Аксесуари"),
     Product("Нос Дмитра", 800, 0, "Аксесуари"),
     Product("Нагетс у формі динозавра", 3200, 15, "Їжа"),
     Product("Ліхтарик шахтарський", 600, 5, "Твоє майбутнє"),
     Product("Карабін X-70", 1500, 0, "Для самозахисту"),
    ]

    return render(request, 'main/catalog.html', {
       'products': products
    })
