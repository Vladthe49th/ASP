from django.views import View
from django.shortcuts import render
from .models import Product
from .forms import ProductForm

from rest_framework.decorators import api_view

from rest_framework.response import Response

from .models import Product

from .serializers import ProductSerializer

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



@api_view(['GET'])
def api_products(request):

    products = Product.objects.all()

    serializer = ProductSerializer(
        products,
        many=True
    )

    return Response(
        serializer.data
    )


@api_view(['GET'])
def api_product(
        request,
        pk
):
    product = Product.objects.get(
        pk=pk
    )

    serializer = ProductSerializer(
        product
    )

    return Response(
        serializer.data
    )


@api_view(['POST'])
def api_create_product(request):

    serializer = ProductSerializer(
        data=request.data
    )

    if serializer.is_valid():

        serializer.save()

        return Response(
            serializer.data
        )



@api_view(['PUT'])
def api_update_product(
        request,
        pk
):

    product = Product.objects.get(
        pk=pk
    )

    serializer = ProductSerializer(
        product,
        data=request.data
    )

    if serializer.is_valid():

        serializer.save()

        return Response(
            serializer.data
        )


@api_view(['DELETE'])
def api_delete_product(
        request,
        pk
):
    product = Product.objects.get(
        pk=pk
    )

    product.delete()

    return Response(
        {
            'message':
            'deleted'
        }
    )


