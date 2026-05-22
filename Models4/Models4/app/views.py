from django.urls import reverse_lazy
from django.views.generic import ListView, CreateView, UpdateView, DeleteView

from .models import Product, Category, Manufacturer
from .forms import ProductForm, CategoryForm, ManufacturerForm


# PRODUCTS

class ProductListView(ListView):
    model = Product
    template_name = 'app/products/product_list.html'
    context_object_name = 'products'


class ProductCreateView(CreateView):
    model = Product
    form_class = ProductForm
    template_name = 'app/products/product_form.html'
    success_url = reverse_lazy('product_list')


class ProductUpdateView(UpdateView):
    model = Product
    form_class = ProductForm
    template_name = 'app/products/product_form.html'
    success_url = reverse_lazy('product_list')


class ProductDeleteView(DeleteView):
    model = Product
    template_name = 'app/products/product_confirm_delete.html'
    success_url = reverse_lazy('product_list')

# CATEGORIES

class CategoryListView(ListView):
    model = Category
    template_name = 'app/categories/category_list.html'
    context_object_name = 'categories'


class CategoryCreateView(CreateView):
    model = Category
    form_class = CategoryForm
    template_name = 'app/categories/category_form.html'
    success_url = reverse_lazy('category_list')


class CategoryUpdateView(UpdateView):
    model = Category
    form_class = CategoryForm
    template_name = 'app/categories/category_form.html'
    success_url = reverse_lazy('category_list')


class CategoryDeleteView(DeleteView):
    model = Category
    template_name = 'app/categories/category_confirm_delete.html'
    success_url = reverse_lazy('category_list')


#MANUFACTURERS



class ManufacturerListView(ListView):
    model = Manufacturer
    template_name = 'app/manufacturers/manufacturer_list.html'
    context_object_name = 'manufacturers'


class ManufacturerCreateView(CreateView):
    model = Manufacturer
    form_class = ManufacturerForm
    template_name = 'app/manufacturers/manufacturer_form.html'
    success_url = reverse_lazy('manufacturer_list')


class ManufacturerUpdateView(UpdateView):
    model = Manufacturer
    form_class = ManufacturerForm
    template_name = 'app/manufacturers/manufacturer_form.html'
    success_url = reverse_lazy('manufacturer_list')


class ManufacturerDeleteView(DeleteView):
    model = Manufacturer
    template_name = 'app/manufacturers/manufacturer_confirm_delete.html'
    success_url = reverse_lazy('manufacturer_list')





