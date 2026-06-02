from django.contrib import admin

from .models import (
    Product,
    Category,
    Service
)


@admin.register(Product)
class ProductAdmin(admin.ModelAdmin):

    list_display = (
        'id',
        'name',
        'price',
        'category'
    )

    search_fields = (
        'name',
    )



@admin.register(Category)
class CategoryAdmin(admin.ModelAdmin):

    list_display = (
        'id',
        'name'
    )


@admin.register(Service)
class ServiceAdmin(admin.ModelAdmin):

    list_display = (
        'id',
        'title',
        'price'
    )