
var connection = new signalR.HubConnectionBuilder().withUrl("/Hubs/VisitStatistics").build();

connection.start()
    .then(function () {
        console.log("SignalR connection established.");
        registerVisit();
    })
    .catch(function (err) {
        console.error(err.toString());
    });

function registerVisit() {
    // Get visitor's IP address
    $.getJSON("https://api.ipify.org?format=json", function (data) {
        var ipAddress = data.ip;

        // Call the AddVisit method in the VisitStatisticsHub to register the visit
        connection.invoke("AddVisit", ipAddress)
            .catch(function (err) {
                console.error("Failed to register visit:", err.toString());
            });
    });
}

connection.on("UpdateVisitStatistics", function (count) {
    // Update visit statistics on the page
    $("#visitStatistics").text("Total Visitors: " + count);
});
