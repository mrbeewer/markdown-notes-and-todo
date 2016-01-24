## Starting the project
  * After using the wizard to generate the base project, needed to open the `Package Manager Console`
  * run `Install-Package Microsoft.AspNet.Identity.EntityFramework` this will install ASP.NET Identity and install into the app
  * Right click on `References` (Solution Explorer) and select `Restore Packages`
  * `Build > Rebuild Solution` and the errors *should* be gone
  * `Debug > Start Debugging`
    * (F5) to run localhost
    * (Shift + F5) to stop debugging

## Entity Classes
  * Define the schema of the data -> similar to table definitions


## Routing
  * within `Startup.cs`
  *
  ``` c#
  routes.MapRoute(
    name: "default",
    // =Home etc are the default routing if none are given
    // in id? the ? means it is an optional parameter
    template: "{controller=Home}/{action=Index}/{id?}");
  ```

## Controller
  * Within routing, the controller name is key. `HelloWorldController` will be called for `localhost:1234/helloworld/`
  ```C#
  using Microsoft.AspNet.Mvc;
  using Microsoft.Extensions.WebEncoders;

  namespace WebApplication3.Controllers
  {
      public class HelloWorldController : Controller
      {
          //
          // GET: /HelloWorld/

          public string Index()
          {
              return "This is my default action...";
          }

          //
          // GET: /HelloWolrd/Welcome/

          public string Welcome(string name, int ID = 1)
          {
              //return "this is the Welcome action method...";

              // this protects from malicious input
              // doesn't seem to care about case
              return HtmlEncoder.Default.HtmlEncode(
                  "Hello " + name + ", ID: " + ID);
          }
      }
  }
  ```
