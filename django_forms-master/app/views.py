from datetime import datetime
from django.http import HttpRequest
from django.shortcuts import render, redirect
from django.contrib import messages
from .forms import ContactForm


def contact(request):

    greeting = ""

    if request.method == 'POST':

        form = GreetingForm(request.POST)

        if form.is_valid():

            first_name = form.cleaned_data['first_name']
            last_name = form.cleaned_data['last_name']

            current_hour = datetime.now().hour

            # визначення часу доби
            if 5 <= current_hour < 12:
                part_of_day = "ранку"

            elif 12 <= current_hour < 18:
                part_of_day = "дня"

            elif 18 <= current_hour < 23:
                part_of_day = "вечора"

            else:
                part_of_day = "ночі"

            greeting = f"Доброго {part_of_day}, {first_name} {last_name}!"

    else:
        form = GreetingForm()

    return render(request, 'app/contact.html', {
        'form': form,
        'greeting': greeting
    })

def home(request):
    """Renders the home page."""
    assert isinstance(request, HttpRequest)
    return render(
        request,
        'app/index.html',
        {
            'title': 'Home Page',
            'year': datetime.now().year,
        }
    )


def about(request):
    """Renders the about page."""
    assert isinstance(request, HttpRequest)
    return render(
        request,
        'app/about.html',
        {
            'title': 'About',
            'message': 'Your application description page.',
            'year': datetime.now().year,
        }
    )