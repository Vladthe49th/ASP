from datetime import datetime
from django.shortcuts import render
from django.http import HttpRequest

###########################################################################################

from rest_framework.decorators import api_view
from rest_framework.response import Response
from datetime import datetime
from rest_framework import status

from .models import Person
from .serializers import PersonSerializer


@api_view(['GET']) # декоратор для вказівки, що цей метод обробляє GET запити
def hello_world(request):
    """Простий GET ендпоінт"""
    return Response({ # повертаємо JSON відповідь з повідомленням, статусом та часом
        "message": "Привіт від Django REST Framework!",
        "status": "success",
        "time": datetime.now().strftime("%Y-%m-%d %H:%M:%S")
    })


@api_view(['GET'])
def get_info(request):
    """Другий GET - повертає інформацію про запит"""
    return Response({
        "path": request.path,
        "method": request.method,
        "query_params": dict(request.query_params),
        "headers": {
            "User-Agent": request.headers.get('User-Agent'),
            "Host": request.headers.get('Host'),
        },
        "user": str(request.user)
    })



@api_view(['GET'])
def get_me(request):
    return Response({
        "name": "Vladislav Yerts",
        "country": "Ukraine",
        "city": "Odesa",
        "profession": "Student",
        "goal": "Become a game designer and team leader",
        "favorite_language": "Python"
    })


@api_view(['GET'])
def get_hobbies(request):
    return Response({
        "count": 5,
        "hobbies": [
            "Programming",
            "Game Design",
            "Writing Fiction",
            "Video Games",
            "Learning New Technologies"
        ]
    })


@api_view(['GET'])
def get_skills(request):
    return Response({
        "python": "Intermediate",
        "django": "Learning",
        "csharp": "Good",
        "sql": "Good",
        "entity_framework": "Good",
        "git": "Basic"
    })


@api_view(['GET'])
def get_fact(request):
    return Response({
        "fact": "One day I`ll make something interesting!",
        "favorite_game_series": "Bioshock",
        "dream_job": "Game Designer",
        "learning_now": "Django REST Framework",
        "fun_fact": "Programming might be a storytelling in it`s own right"
    })

###########################################################################################

def home(request):
    """Renders the home page."""
    assert isinstance(request, HttpRequest)
    return render(
        request,
        'api/index.html',
        {
            'title':'Home Page',
            'year':datetime.now().year,
        }
    )

def contact(request):
    """Renders the contact page."""
    assert isinstance(request, HttpRequest)
    return render(
        request,
        'api/contact.html',
        {
            'title':'Contact',
            'message':'Your contact page.',
            'year':datetime.now().year,
        }
    )

def about(request):
    """Renders the about page."""
    assert isinstance(request, HttpRequest)
    return render(
        request,
        'api/about.html',
        {
            'title':'About',
            'message':'Your application description page.',
            'year':datetime.now().year,
        }
    )



@api_view(['GET', 'POST'])
def persons(request):

    if request.method == 'GET':

        people = Person.objects.all()

        serializer = PersonSerializer(
            people,
            many=True
        )

        return Response(serializer.data)

    if request.method == 'POST':

        serializer = PersonSerializer(
            data=request.data
        )

        if serializer.is_valid():

            serializer.save()

            return Response(
                serializer.data,
                status=status.HTTP_201_CREATED
            )

        return Response(
            serializer.errors,
            status=status.HTTP_400_BAD_REQUEST
        )