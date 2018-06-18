using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Collections.Generic;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;

namespace myFirstBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                await Conversation.SendAsync(activity, () => new Dialogs.RootDialog());
                //ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                //activity.TextFormat = "markdown";
                //activity.Text = "Connect with me on insta: [Naveen Jangid](https://instagram.com/naveen_215)";
                //Activity reply = activity.CreateReply(activity.Text);

                //activity.TextFormat = "xml";
                //activity.Text = "<b> Hello Mr Bot! </b>";
                //Activity reply = activity.CreateReply(activity.Text);

                //Activity reply = activity.CreateReply("Replying with image");
                //reply.Attachments = new List<Attachment>();
                //reply.Attachments.Add(new Attachment
                //{
                //    ContentUrl = "https://i1.rgstatic.net/ii/profile.image/614224199958542-1523453869191_Q512/Naveen_Jangid.jpg",
                //    ContentType = "Image/jpg",
                //    Name = "NaveenJangidLinkedIn.jpg"
                //});

                //Activity reply = activity.CreateReply("Here are my Github and Instagram Accounts");
                //reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;

                //CardAction gitAcct = new CardAction("openUrl", "gitHub Account", null, "https://github.com/naveen21553");
                //CardImage gitImg = new CardImage("https://assets-cdn.github.com/images/modules/logos_page/Octocat.png");
                //HeroCard gitCard = new HeroCard();

                //gitCard.Buttons = new List<CardAction>();
                //gitCard.Images = new List<CardImage>();


                //gitCard.Buttons.Add(gitAcct);
                //gitCard.Title = "My GitHub Account";
                //gitCard.Images.Add(gitImg);
                //reply.Attachments = new List<Attachment>();
                //reply.Attachments.Add(gitCard.ToAttachment());

                //CardAction instaAct = new CardAction("openUrl", "My Insta Account", null, "https://instagram.com/naveen_215");
                //CardImage instaImg = new CardImage("https://upload.wikimedia.org/wikipedia/commons/thumb/e/e7/Instagram_logo_2016.svg/1024px-Instagram_logo_2016.svg.png");

                //HeroCard instaCard = new HeroCard();
                //instaCard.Buttons = new List<CardAction>();
                //instaCard.Images = new List<CardImage>();

                //instaCard.Buttons.Add(instaAct);
                //instaCard.Images.Add(instaImg);
                //instaCard.Title = "My Instagram Account";

                //reply.Attachments.Add(instaCard.ToAttachment());

                //Activity reply = activity.CreateReply("How can I help?");
                //reply.SuggestedActions = new SuggestedActions()
                //{
                //    Actions = new List<CardAction>()
                //    {
                //        new CardAction() {Title = "Open twitter", Type = ActionTypes.OpenUrl, Value = "https://Twitter.com"},
                //        new CardAction() {Title = "Open Facebook", Type = ActionTypes.OpenUrl, Value = "https://Facebook.com"}
                //    }
                //};

                //await connector.Conversations.ReplyToActivityAsync(reply);

            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }   

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
}