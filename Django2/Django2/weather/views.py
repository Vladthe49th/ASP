from django.shortcuts import render
from django.http import HttpResponse, JsonResponse
from django.views.decorators.csrf import csrf_exempt
import json


def request_demo(request):

    first = request.GET.get('first')
    second = request.GET.get('second')
    op = request.GET.get('op')

    result = None
    error = None
    operation_symbol = ""

    if first is not None and second is not None and op is not None:
        try:
            a = int(first)
            b = int(second)

            if op == 'add':
                result = a + b
                operation_symbol = '+'

            elif op == 'sub':
                result = a - b
                operation_symbol = '-'

            elif op == 'mul':
                result = a * b
                operation_symbol = '*'

            elif op == 'div':
                if b == 0:
                    error = "Ділення на нуль неможливе"
                else:
                    result = a / b
                    operation_symbol = '/'

            else:
                error = "Невідома операція"

        except ValueError:
            error = "Параметри повинні бути цілими числами"


    request_info = {
        "Метод": request.method,
        "Шлях": request.path,
        "Схема": request.scheme,
        "Хост": request.get_host(),
        "is_secure": request.is_secure(),
        "User-Agent": request.headers.get("User-Agent", "немає"),
        "Content-Type": request.headers.get("Content-Type", "немає"),
    }

    get_params = dict(request.GET)
    multi_get = request.GET.getlist('color')

    post_params = dict(request.POST)
    files_info = {
        k: f"{v.name} ({v.size} байт)"
        for k, v in request.FILES.items()
    }

    body_preview = ""
    if request.content_type and "multipart/form-data" not in request.content_type:
        if request.body:
            try:
                body_preview = json.loads(request.body.decode('utf-8'))
            except Exception:
                body_preview = request.body[:200].decode('utf-8', errors='ignore') + "..."

    context = {
        'request_info': json.dumps(request_info, indent=2, ensure_ascii=False),
        'get_params': json.dumps(get_params, indent=2, ensure_ascii=False),
        'multi_get': multi_get,
        'post_params': json.dumps(post_params, indent=2, ensure_ascii=False),
        'files_info': files_info,
        'body_preview': body_preview,
        'django_version': '6.0.2',

        # 🔢 калькулятор
        'first': first,
        'second': second,
        'operation': op,
        'operation_symbol': operation_symbol,
        'result': result,
        'error': error,
    }

    return render(request, 'weather/weather.html', context)


@csrf_exempt
def handle_form(request):
    if request.method == 'POST':
        data = {
            "method": request.method,
            "username": request.POST.get("username"),
            "colors": request.POST.getlist("color"),
            "files": [f.name for f in request.FILES.values()],
        }

      
        if request.content_type == "application/json":
            try:
                data["json_data"] = json.loads(request.body)
            except Exception:
                data["json_error"] = "Невалідний JSON"

        return JsonResponse({"status": "success", "received": data})

    return HttpResponse("Тільки POST дозволено", status=405)