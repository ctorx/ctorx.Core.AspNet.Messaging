# ctorx.Core.AspNet.Messaging
A simple framework for persisting messages between ASP.NET Requests

## What is it?
A simple messaging system for notifying users about statuses of the operations they perform on your web application (i.e. letting users know when things worked or didn't work), either in the same request or after redirection.

## Setup
Use the extension method like this:

```csharp
services.AddMessaging();
```
# Usage

Add the Messenger to your controller

```csharp
public class YourController : Controller
{
    readonly Messenger Messenger;

    public YourController(Messenger messenger)
    {
        this.Messenger = messenger;
    }
}
```

Append or Forward a message as needed

```csharp
[HttpPost]
public async Task<IActionResult> YourPostAction(YourViewModel viewModel)
{
    if(!ModelState.IsValid)
    {
        // This appends a message to the current request 
        this.Messenger.AppendError("Looks like you missed something");
        return View(viewModel);
    }
    
    /// do saving and stuff
    
    // This will forward the message to the next request
    this.Messenger.ForwardSuccess("Your changes have been saved!");
    return RedirectToAction(nameof(YourGetAction), new { id = viewModel.Id });
}
```

#### Displaying Messages
This library does not provide a way of displaying messages because your unique design and layout will ultimately determine how messages should be rendered.  

Here is a simple example of a partial using Bootstrap classes to display messages:

```csharp
@using ctorx.Core.AspNet.Messaging
@inject Messenger Messenger
@{
    var messages = this.Messenger.GetMessages();
}

@if (messages?.Count > 0)
{
    <div id="messages">
        @foreach (var message in messages)
        {
            var messageClasses = new List<string> { "alert" };
            var iconClass = string.Empty;

            if (message.IsDismissable)
            {
                messageClasses.Add("alert-dismissible");
            }

            switch (message.Type)
            {
                case MessageType.Error:
                    messageClasses.Add("alert-danger");
                    iconClass = "glyphicon-exclamation-sign";
                    break;

                case MessageType.Warn:
                    messageClasses.Add("alert-warning");
                    iconClass = "glyphicon-exclamation-sign";
                    break;

                case MessageType.Info:
                    messageClasses.Add("alert-info");
                    iconClass = "glyphicon-info-sign";
                    break;

                case MessageType.Success:
                    messageClasses.Add("alert-success");
                    iconClass = "glyphicon-ok-sign";
                    break;
            }

            <div class="@(string.Join(" ", messageClasses))" role="alert">
                @if (message.IsDismissible)
                {
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">×</span></button>
                }

                <span class="glyphicon @iconClass" aria-hidden="true"></span>

                @if (!string.IsNullOrWhiteSpace(message.Caption))
                {
                    <strong>@message.Caption</strong>
                }
                @Html.Raw(message.Text)
            </div>            
        }
    </div>
}
```

## Where can I get it?
Install from [Nuget](https://www.nuget.org/packages/ctorx.Core.AspNet.Messaging/) 
```
Install-Package ctorx.Core.AspNet.Messaging
```

## License, etc.
ctorx.Core.AspNet.Messaging is copyright © 2022 Matthew Marksbury and other contributors under the MIT license.
