$(document).ready(() => {
    generateLeaderboard();
});

function generateLeaderboard() {
    let leaderboard = $("#full-leaderboard-table");

    $.ajax({
        url: "/Services/Game.svc/GetLeaderboard",
        method: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: (result) => {
            result = JSON.parse(result.d);
            if (result != null) {
                leaderboard.DataTable({
                    order: [[4, "desc"]],
                    pageLength: 10,
                    "oLanguage": {
                        "sUrl": "/Content/Datatable/German.json"
                    },
                    columns: [
                        {
                            data: "Role",
                            title: "Rolle",
                            render: (data) => data == null ? "-" : data
                        },
                        {
                            data: "Username",
                            title: "Username",
                            render: (data) =>data == null ? "-" : data
                        },
                        {
                            data: "Playtime",
                            title: "Spielzeit",
                            render: (data) => data == null ? "-" : data
                        },
                        {
                            data: "Coins",
                            title: "Münzen",
                            render: (data) => data == null ? "-" : formatNumber(data)
                        },
                        {
                            data: "Points",
                            title: "Punkte",
                            render: (data) => data == null ? "-" : formatNumber(data)
                        }
                    ],
                    data: result
                });
            }
        }
    });
}