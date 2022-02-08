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
            this.Messenger.AppendError("This is an example of an appended message", "Appended Message");

        }

        public ActionResult OnPost()
        {
            this.Messenger.ForwardSuccess(this.NewMessageText, "Forwarded Message");
            return this.Redirect(this.Request.GetEncodedUrl());
        }
    }
}
