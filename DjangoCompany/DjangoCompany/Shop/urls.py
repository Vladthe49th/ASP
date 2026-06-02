from django.urls import path
from .views import ProductListView

urlpatterns = [
    path('', views.products, name='products'),
    path('add/', views.add_product, name='add_product'),
    path(
    'api/products/create/',
    views.api_create_product
),

path(
    'api/products/update/<int:pk>/',
    views.api_update_product
),

path(
    'api/products/delete/<int:pk>/',
    views.api_delete_product
),
]