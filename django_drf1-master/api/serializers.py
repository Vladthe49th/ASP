from rest_framework import serializers
from .models import Person


class PersonSerializer(serializers.ModelSerializer):

    class Meta:
        model = Person
        fields = '__all__'



class PersonSerializer(serializers.ModelSerializer):

    class Meta:
        model = Person
        fields = '__all__'

    def validate_first_name(self, value):
        if len(value) < 2:
            raise serializers.ValidationError(
                "Ім'я повинно містити мінімум 2 символи!"
            )
        return value

    def validate_age(self, value):
        if value < 16:
            raise serializers.ValidationError(
                "Вік повинен бути не менше 16 років!!111"
            )
        return value



def validate(self, data):

    age = data.get("age")
    email = data.get("email")

    if age < 18 and email.endswith("@company.com"):
        raise serializers.ValidationError(
            "Неповнолітні не можуть входити у супер-дорослий клуб! Геть звідси!"
        )

    return data