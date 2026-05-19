from django.db import models
from django.utils import timezone
from django.core.validators import MinValueValidator, MaxValueValidator


class Category(models.Model):
   
    name = models.CharField(max_length=100, unique=True, verbose_name="Category name")
    slug = models.SlugField(max_length=120, unique=True, help_text="URL-friendly name") # https://netpeak.net/uk/blog/shcho-take-url-slug-i-yak-zrobiti-yogo-seo-druzhnim/
    description = models.TextField(blank=True, verbose_name="Description")
    created_at = models.DateTimeField(auto_now_add=True, verbose_name="Date")

    class Meta: # мета-інформація про модель, яка не є полями бази даних, але впливає на поведінку моделі, наприклад, на те, як вона відображається в адміністративній панелі або як сортуються записи
        verbose_name = "Категорія"
        verbose_name_plural = "Категорії"
        ordering = ['name']

    def __str__(self):
        return self.name


class Manufacturer(models.Model):
    
    name = models.CharField(max_length=150, unique=True, verbose_name="Назва виробника")
    country = models.CharField(max_length=100, verbose_name="Країна")
    website = models.URLField(max_length=200, blank=True, null=True, verbose_name="Веб-сайт")
    email = models.EmailField(blank=True, null=True, verbose_name="Email")
    logo = models.ImageField(upload_to='manufacturers/logos/', blank=True, null=True, verbose_name="Логотип")
    established_year = models.PositiveIntegerField(
        validators=[MinValueValidator(1800), MaxValueValidator(2026)],
        blank=True, null=True,
        verbose_name="Рік заснування"
    )

    class Meta:
        verbose_name = "Виробник"
        verbose_name_plural = "Виробники"
        ordering = ['name']

    def __str__(self):
        return self.name


class Product(models.Model):

    STATUS_CHOICES = [
        ('draft', 'Чернетка'),
        ('published', 'Опубліковано'),
        ('archived', 'Архівовано'),
    ]

    name = models.CharField(
        max_length=200,
        unique=True,
        verbose_name="Назва товару"
    )

    price = models.DecimalField(
    max_digits=10,
    decimal_places=2,
    validators=[MinValueValidator(0)],
    verbose_name="Ціна"
    )


    discount_price = models.DecimalField(
        max_digits=10,
        decimal_places=2,
        blank=True,
        null=True,
        verbose_name="Ціна зі знижкою"
    )
    stock_quantity = models.PositiveIntegerField(default=0, verbose_name="Кількість на складі")

    # додаткові поля різних типів
    sku = models.CharField(max_length=50, unique=True, verbose_name="Артикул (SKU)")
    weight = models.FloatField(null=True, blank=True, verbose_name="Вага (кг)")
    is_available = models.BooleanField(default=True, verbose_name="Доступний для продажу")
    status = models.CharField(
        max_length=20,
        choices=STATUS_CHOICES,
        default='draft',
        verbose_name="Статус"
    )
    tags = models.JSONField(default=list, blank=True, verbose_name="Теги") # сучасний спосіб зберігання списку

    # дата і час
    created_at = models.DateTimeField(auto_now_add=True, verbose_name="Дата створення")
    updated_at = models.DateTimeField(auto_now=True, verbose_name="Дата оновлення")
    published_at = models.DateField(null=True, blank=True, verbose_name="Дата публікації")

    # ManyToMany приклад (якщо потрібні додаткові категорії)
    additional_categories = models.ManyToManyField(
        Category,
        related_name='additional_products',
        blank=True,
        verbose_name="Додаткові категорії"
    )


    ...

    class Meta:
        verbose_name = "Товар"
        verbose_name_plural = "Товари"
        ordering = ['-created_at']

        indexes = [
            models.Index(fields=['price']),
            models.Index(fields=['status']),
        ]

        constraints = [
            models.CheckConstraint(
                check=models.Q(price__gte=0),
                name='product_price_gte_0'
            ),
            models.CheckConstraint(
                check=models.Q(stock_quantity__gte=0),
                name='product_stock_gte_0'
            ),
        ]