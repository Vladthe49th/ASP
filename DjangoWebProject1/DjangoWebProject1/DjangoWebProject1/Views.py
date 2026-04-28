from django.http import HttpResponse
import datetime
import random


def main_page(request):
    return HttpResponse("Hello, this is the main page!")


def second_page(request):
    return HttpResponse("This is the second page!")


def current_day(request):
    days = [
        "Понеділок", "Вівторок", "Середа",
        "Четвер", "П'ятниця", "Субота", "Неділя"
    ]
    
    today_index = datetime.datetime.today().weekday()
    return HttpResponse(f"Сьогодні: {days[today_index]}")


def random_quote(request):
    quotes = [
        "Якщо тебе образили - не ображайся. Якщо вдарили - не вдаряйся",
        "Красиво роби - красиво буде",
        "Слово не горобець - вилетить, не застрелиш",
        "У самурая нема цілі - я вкрав",
        "Не поспішай - а то встигнеш"
    ]
    
    quote = random.choice(quotes)
    return HttpResponse(f"Цитата дня: {quote}")
