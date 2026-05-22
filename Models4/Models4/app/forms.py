from django import forms
from .models import Product, Category, Manufacturer


class CategoryForm(forms.ModelForm):
    class Meta:
        model = Category
        fields = '__all__'


class ManufacturerForm(forms.ModelForm):
    class Meta:
        model = Manufacturer
        fields = '__all__'


class ProductForm(forms.ModelForm):
    class Meta:
        model = Product
        fields = '__all__'

        widgets = {
            'published_at': forms.DateInput(attrs={'type': 'date'}),
        }