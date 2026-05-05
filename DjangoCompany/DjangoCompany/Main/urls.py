from django.urls import path
from . import views

urlpatterns = [

    path('', views.home, name='home'),
    path('news/', views.news, name='news'),
    path('management/', views.management, name='management'),
    path('about/', views.about, name='about'),
    path('contacts/', views.contacts, name='contacts'),
    re_path(r'^news/.+$', views.news_404),
    
]

handler404 = 'main.views.custom_404',
