using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Collections.Generic;

namespace myFirstBot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            await context.PostAsync("Let's get into new dialog 1");
            context.Call(new NewDialog1(), NewDialog1Resume);

            //calculate something for us to return
            //int length = (activity.Text ?? string.Empty).Length;

            //activity.TextFormat = "markdown";
            //activity.Text = "Connect to me: [Naveen Jangid](https://instagram.com/naveen_215)";
            //Activity reply = activity.CreateReply(activity.Text);
            // return our reply to the user

            //activity.TextFormat = "xml";
            //activity.Text = "<b>Hello Bot!</b>";
            //PromptDialog.Confirm(context, AfterOkAsync, "Are you sure?", promptStyle: PromptStyle.Auto);
            
            //await context.PostAsync(reply.Text);

            //dcontext.Wait(MessageReceivedAsync);
        }

        



        //public async Task AfterOkAsync(IDialogContext context, IAwaitable<bool> argument)
        //{
        //    var confirm = await argument;
        //    if (confirm)
        //    {
        //        await context.PostAsync("Proceeding");

        //    }
        //    else await context.PostAsync("Ignoring");
        //    context.Wait(MessageReceivedAsync);
        //}
        public async Task NewDialog1Resume(IDialogContext context, IAwaitable<object> obj)
        {
            await context.PostAsync("Moving to New Dialog 2");
            context.Call(new NewDialog2(), NewDialog2Resume);

        }
        public async Task NewDialog2Resume(IDialogContext context, IAwaitable<object> obj)
        {
            await context.PostAsync("Completed both dialogs");

        }
    }
   
}