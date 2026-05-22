from django.db import models


class Author(models.Model):
    name = models.CharField(max_length=255)
    birth_year = models.IntegerField()
    rating = models.FloatField()

    def __str__(self):
        return self.name


class Book(models.Model):
    title = models.CharField(max_length=255)
    author = models.ForeignKey(Author, on_delete=models.CASCADE, related_name='books')
    pages = models.IntegerField()
    price = models.DecimalField(max_digits=8, decimal_places=2)
    published_year = models.IntegerField()
    stock = models.IntegerField()

    def __str__(self):
        return self.title