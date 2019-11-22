using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using graph_tutorial.Helpers;
using graph_tutorial.ViewModels;
using Microsoft.Graph;

namespace graph_tutorial.Services
{
  public class MailServices
  {
    public static async Task SendEmailToUsers(CreateNewItems model)
    {
      var graphClient = GraphHelper.GetAuthenticatedClient();
      var gettingUsers = await FormServices.GetGroupUsers();

      foreach (User item in gettingUsers.CurrentPage)
      {
        var message = new Message
        {
          Subject = "Inbjudan till Aw: " + model.Title,
          Body = new ItemBody
          {
            ContentType = BodyType.Text,
            Content = model.Title + "\n" + "\n"
                      + model.Description + "\n" + "\n"
                      + model.Time + "\n" + "\n"
                      + model.Address + "\n" + "\n"
                      + "Med vänlig hälsning \nAw-Gruppen "
          },
          ToRecipients = new List<Recipient>()
          {
            new Recipient
            {
              EmailAddress = new EmailAddress
              {
                Address = item.Mail
              }
            }
          }
        };
        var saveToSentItems = false;

        await graphClient.Me
          .SendMail(message, saveToSentItems)
          .Request()
          .PostAsync();
      }
    }
  }
}
