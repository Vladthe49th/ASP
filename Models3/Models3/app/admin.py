from django.contrib import admin
from .models import Author, Book, Country, Publishment


admin.site.register(Author)
admin.site.register(Book)
admin.site.register(Country)
admin.site.register(Publishment)
