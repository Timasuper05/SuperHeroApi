
namespace SuperHeroApi.MyMiddleWars
{
    public class LoggerMiddleware
    {
        private readonly RequestDelegate _next;
        public LoggerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
          var getlog =   context.Request.Method;
            if(getlog == "Put")
            {
                Console.WriteLine("request PUT");
            }
            await _next(context);
        }
    }
}
