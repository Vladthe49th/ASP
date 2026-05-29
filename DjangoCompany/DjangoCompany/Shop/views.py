from django.views import View
from django.shortcuts import render
from .models import Product
from .forms import ProductForm

class ProductListView(View):
    def get(self, request):
        products = Product.objects.all()
        return render(request, 'shop/products.html', {'products': products})


def add_product(request):

    if request.method == 'POST':

        form = ProductForm(
            request.POST,
            request.FILES
        )

        if form.is_valid():
            form.save()
            return redirect('products')

    else:
        form = ProductForm()

    return render(request, 'shop/add_product.html', {
        'form': form
    })