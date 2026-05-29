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
