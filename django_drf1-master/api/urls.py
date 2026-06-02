from django.urls import path
from . import views

urlpatterns = [
    path('api/me/', views.get_me),
    path('api/hobbies/', views.get_hobbies),
    path('api/skills/', views.get_skills),
    path('api/facts/', views.get_fact),
]