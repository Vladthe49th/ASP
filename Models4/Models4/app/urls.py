from django.urls import path
from .views import *

urlpatterns = [

    # PRODUCTS
    path('products/', ProductListView.as_view(), name='product_list'),
    path('products/create/', ProductCreateView.as_view(), name='product_create'),
    path('products/<int:pk>/edit/', ProductUpdateView.as_view(), name='product_edit'),
    path('products/<int:pk>/delete/', ProductDeleteView.as_view(), name='product_delete'),

    # CATEGORIES
    path('categories/', CategoryListView.as_view(), name='category_list'),
    path('categories/create/', CategoryCreateView.as_view(), name='category_create'),
    path('categories/<int:pk>/edit/', CategoryUpdateView.as_view(), name='category_edit'),
    path('categories/<int:pk>/delete/', CategoryDeleteView.as_view(), name='category_delete'),

    # MANUFACTURERS
    path('manufacturers/', ManufacturerListView.as_view(), name='manufacturer_list'),
    path('manufacturers/create/', ManufacturerCreateView.as_view(), name='manufacturer_create'),
    path('manufacturers/<int:pk>/edit/', ManufacturerUpdateView.as_view(), name='manufacturer_edit'),
    path('manufacturers/<int:pk>/delete/', ManufacturerDeleteView.as_view(), name='manufacturer_delete'),
]
