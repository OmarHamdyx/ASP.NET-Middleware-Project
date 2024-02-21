


namespace MiddleWareProject.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LoginMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            using StreamReader reader = new(context.Request.Body);
            string requestBody = await reader.ReadToEndAsync();
            var formData = System.Web.HttpUtility.ParseQueryString(requestBody);
            var email = formData["email"];
            var password = formData["password"];
            int emailFlag = 0;
            int passwordFlag = 0;

            if (context.Request.Path == "/" && context.Request.Method == "POST")
            {
                if (formData.AllKeys.Contains("email"))
                {
                    emailFlag = 1;
                }
                else
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid input for 'email' with status code: " + context.Response.StatusCode + Environment.NewLine);


                }
                if (formData.AllKeys.Contains("password"))
                {
                    passwordFlag = 1;
                }
                else
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid input for 'password' with status code: " + context.Response.StatusCode + Environment.NewLine);


                }
                if (emailFlag == 1 && passwordFlag == 1 && formData["email"] == "admin@example.com" && formData["password"] == "admin1234")
                {
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync("Login Successful! " + context.Response.StatusCode + "OK" + Environment.NewLine);
                }
                else if (emailFlag == 1 && passwordFlag == 1)
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Login Failed!" + context.Response.StatusCode + Environment.NewLine);
                }

            }
            else
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Bad URL" + context.Response.StatusCode + Environment.NewLine);
                await _next(context);

            }


        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseLoginMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoginMiddleware>();
        }
    }
}
