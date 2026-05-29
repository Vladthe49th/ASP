from django.db import models

class Product(models.Model):
    CATEGORY_CHOICES = [
        ('gadgets', 'Гаджети'),
        ('accessories', 'Аксесуари'),
        ('gear', 'Спорядження'),
        ('clothes', 'Одяг'),
    ]

    name = models.CharField(max_length=100)
    description = models.TextField()
    price = models.DecimalField(max_digits=10, decimal_places=2)

    discount = models.PositiveIntegerField(default=0)

    category = models.CharField(
        max_length=20,
        choices=CATEGORY_CHOICES
    )

    image = models.ImageField(
        upload_to='products/',
        blank=True,
        null=True
    )

    created_at = models.DateTimeField(auto_now_add=True)

    def __str__(self):
        return self.name

    def final_price(self):
        return self.price * (1 - self.discount / 100)