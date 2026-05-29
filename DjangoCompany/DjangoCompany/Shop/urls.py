from django.urls import path
from .views import ProductListView

urlpatterns = [
    path('', views.products, name='products'),
    path('add/', views.add_product, name='add_product'),
]