using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Web.Http;
using symoapp.DataObjects;
using symoapp.Models;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Config;

namespace symoapp
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            HttpConfiguration config = new HttpConfiguration();

            new MobileAppConfiguration()
                .UseDefaultConfiguration()
                .ApplyTo(config);

            // To display errors in the browser during development, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
            // config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            Database.SetInitializer(new MobileServiceInitializer());
        }
    }

    public class MobileServiceInitializer : DropCreateDatabaseIfModelChanges<MobileServiceContext>
    {
        protected override void Seed(MobileServiceContext context)
        {
            List<TodoItem> todoItems = new List<TodoItem>
            {
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "First item", Details = "First Details", Complete = false },
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Second item", Details = "Second Details", Complete = false },
            };

            List<Person> people = new List<Person>
            {
                new Person { Id = Guid.NewGuid().ToString(), Name = "Jane Doe", EmailAddress = "janedoe@fabrikam.com" },
                new Person { Id = Guid.NewGuid().ToString(), Name = "John Doe", EmailAddress = "johndoe@fabrikam.com" },
            };

            foreach (TodoItem todoItem in todoItems)
            {
                context.Set<TodoItem>().Add(todoItem);
            }

            foreach (Person person in people)
            {
                context.Set<Person>().Add(person);
            }

            base.Seed(context);
        }
    }
}

