from django.http import HttpResponse

def hello(request):
    return HttpResponse("Hello there! What are you doing in my swamp?!!!!")