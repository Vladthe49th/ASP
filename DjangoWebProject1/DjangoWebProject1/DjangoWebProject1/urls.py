from django.urls import path
from .views import main_page, second_page, current_day, random_quote

urlpatterns = [
    # 1 і 2 з прикладу
    path('', main_page, name='hello'),
    path('second/', second_page, name='test'),

    # 3 - день тижня
    path('day/', current_day, name='current_day'),

    # 4 - випадкова цитата
    path('quote/', random_quote, name='random_quote'),
]