from django.db import models


class Country(models.Model):
    name = models.CharField(max_length=100)
    capital = models.CharField(max_length=100)

    class Meta:
        verbose_name = 'Country'
        verbose_name_plural = 'Countries'
        ordering = ['name']

    def __str__(self):
        return self.name


class Publishment(models.Model):
    name = models.CharField(max_length=255)
    founded_year = models.IntegerField()
    city = models.CharField(max_length=100)

    class Meta:
        verbose_name = 'Publishment'
        verbose_name_plural = 'Publishments'
        ordering = ['name']

    def __str__(self):
        return self.name


class Author(models.Model):
    name = models.CharField(max_length=255)
    birth_year = models.IntegerField()
    rating = models.FloatField()

    country = models.ForeignKey(
        Country,
        on_delete=models.CASCADE,
        related_name='authors'
    )

    class Meta:
        verbose_name = 'Author'
        verbose_name_plural = 'Authors'
        ordering = ['name']

    def __str__(self):
        return self.name


class Book(models.Model):
    title = models.CharField(max_length=255)

    author = models.ForeignKey(
        Author,
        on_delete=models.CASCADE,
        related_name='books'
    )

    publishment = models.ForeignKey(
        Publishment,
        on_delete=models.CASCADE,
        related_name='books'
    )

    pages = models.IntegerField()
    price = models.DecimalField(max_digits=8, decimal_places=2)
    published_year = models.IntegerField()
    stock = models.IntegerField()

    class Meta:
        verbose_name = 'Book'
        verbose_name_plural = 'Books'
        ordering = ['title']

    def __str__(self):
        return self.title