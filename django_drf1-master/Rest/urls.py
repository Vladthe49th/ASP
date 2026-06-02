from datetime import datetime
from django.urls import path, include # !!!
from django.contrib import admin
from django.contrib.auth.views import LoginView, LogoutView
from api import forms, views

urlpatterns = [
     path('', include('api.urls')),
]