// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
const userUpdatesConnection = new signalR.HubConnectionBuilder()
    .withUrl("/userUpdates")
    .build();

userUpdatesConnection.on("ReceiveSignIn", (user) => {
    toastr.options.escapeHtml = true;
    const message = user + " logged in.";
    toastr.info(message, "New Login!");
});

userUpdatesConnection.on("ReceiveSignOut", (user) => {
    toastr.options.escapeHtml = true;
    const message = user + " logged out.";
    toastr.info(message, "User logging out...");
});

userUpdatesConnection.on("ReceiveRegistration", (user) => {
    toastr.options.escapeHtml = true;
    const message = user + " registered.";
    toastr.success(message, "New Registration!");
});

userUpdatesConnection.start().catch(err => console.error(err.toString()));

