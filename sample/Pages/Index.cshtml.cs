using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ctorx.Core.AspNet.Messaging;
using Microsoft.AspNetCore.Http.Extensions;

namespace Sample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        readonly Messenger Messenger;

        [BindProperty]
        public string NewMessageText { get; set; }

        public IndexModel(ILogger<IndexModel> logger, Messenger messenger)
        {
            _logger = logger;
            this.Messenger = messenger;
        }

        public void OnGet()
        {
            // Append some messages
            if(string.IsNullOrWhiteSpace(Request.Query["fwd"]))
            {
                this.Messenger.AppendError("This is an example of an appended message with a caption", "Appended Message");
                this.Messenger.AppendError(); // Append a generic error message
                this.Messenger.AppendSuccess(); // Append a generic success message
                this.Messenger.AppendSuccess(caption: "Generic message, custom caption");
                this.Messenger.AppendSuccess(messageText: "Generic caption, custom message");
            }
        }

        public ActionResult OnPost()
        {
            this.Messenger.ForwardSuccess(this.NewMessageText, "Forwarded Message");
            this.Messenger.ForwardError(); // Append a generic error message
            this.Messenger.ForwardSuccess(); // Append a generic success message
            this.Messenger.ForwardSuccess(caption: "Caption Text");
            this.Messenger.ForwardSuccess(messageText: "Message Text");


            return this.Redirect(this.Request.GetEncodedUrl() + "?fwd=1");
        }
    }
}
