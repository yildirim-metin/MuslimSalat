using Microsoft.AspNetCore.Http;
using MuslimSalat.BLL.Exceptions;
using System.Runtime.ExceptionServices;
using System.Text.Json;

namespace MuslimSalat.API.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _requestDelegate;
    public ExceptionMiddleware(RequestDelegate resquestDelegate)
    {
        _requestDelegate = resquestDelegate;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _requestDelegate(context);

        }
        catch (MuslimSalatException ex)
        {
            await HandleException(context, ex);
        }
    }
    public async Task HandleException(HttpContext context, MuslimSalatException ex)
    {
        context.Response.ContentType = "application/json";

        int statusCode = 400;

        switch (ex)
        {
            case MuslimSalatException e:
                await SendResponse(context, e);
                break;
            // case Exception:
            //     statusCode = 500;
            //     context.Response.StatusCode = statusCode;

            //     var reponse = new
            //     {
            //         message = ex.Message,
            //     };

            //     var jsonResponse = JsonSerializer.Serialize(reponse);

            //     await context.Response.WriteAsync(jsonResponse);
            //     break;
            default:
                throw new Exception("WTF");
        }
    }
    public async Task SendResponse(HttpContext context, MuslimSalatException ex)
    {
        context.Response.StatusCode = ex.StatusCode;

        var response = new
        {
            content = ex.Content
        };

        var jsonReponse = JsonSerializer.Serialize(response);
        await context.Response.WriteAsync(jsonReponse);
    

    }
}