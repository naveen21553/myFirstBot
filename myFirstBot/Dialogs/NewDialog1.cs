using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace myFirstBot.Dialogs
{
    [Serializable]
    public class NewDialog1 : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Do you like me?");
            context.Wait(MessageRecievedAsync);
        }
        public async Task MessageRecievedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;
            if(message.Text.Contains("Yes"))
            {
                await context.PostAsync("I'm glad to here that");
                context.Done(message.Text);
                
            }
            else
            {
                await context.PostAsync("Sorry we only teke yes as an answer..");
                context.Done(message.Text);
            }
        }
    }
}