$(document).ready(() => {
    loadLeaderboard();
    generateAnimationCanvas();
});

function generateAnimationCanvas() {
    let currentInverval = null;

    let canvas = document.getElementById("animation-canvas");
    let context = canvas.getContext("2d");
    let dots = [];

    resizeAnimation();

    function clearAnimation() {
        context.clearRect(0, 0, canvas.width, canvas.height);
    }
    function resizeAnimation() {
        let box = $("#game-animation-area");
        let bHeight = Math.floor(box.height());
        let bWidth = Math.floor(box.width());
        let changedSomething = false;

        if (context.canvas.width != bWidth) {
            context.canvas.width = bWidth;
            changedSomething = true;
        }

        if (context.canvas.height != bHeight) {
            context.canvas.height = bHeight;
            changedSomething = true;
        }

        if (changedSomething) {
            generateAnimation();
        } else {
            getDots();
        }
    }
    function generateAnimation() {
        $.ajax({
            url: "/Services/Home.svc/GenerateAnimation",
            method: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: {
                animationWidth: context.canvas.width,
                animationHeight: context.canvas.height
            },
            success: () => {
                getDots();
            }
        });
    }
    function getDots() {
        $.ajax({
            url: "/Services/Home.svc/GetAnimation",
            method: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: (result) => {
                result = JSON.parse(result.d); 
                if (result != null) {
                    dots = result;
                    drawAnimation();
                }
            }
        });
    }
    function drawAnimation() {
        clearInterval(currentInverval);
        currentInverval = setInterval(() => {
            clearAnimation();
            resizeAnimation();
            for (let curDot of dots) {
                strokeDot(curDot);
            }
        }, 62.5);

        function strokeDot(dot) {
            context.beginPath();
            context.arc(dot.X, dot.Y, dot.Radius, 0, 2 * Math.PI);
            context.stroke();
            context.fillStyle = getCorrectRGBA(dot.Color.Red, dot.Color.Green, dot.Color.Blue, dot.Color.Alpha);
            context.fill();
        }
    }
}

function loadLeaderboard() {
    let table = $("#leaderboard-table");

    $.ajax({
        url: "/Services/Home.svc/GetLeaderboard",
        method: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: {
            getItems: 5
        },
        success: (result) => {
            result = JSON.parse(result.d);
            if (result != null) {
                table.DataTable({
                    order: [[1, "desc"]],
                    pageLength: 5,
                    columns: [
                        {
                            data: "Username",
                            title: "Username",
                            render: (data) => data == null ? "-" : data
                        },
                        {
                            data: "Points",
                            title: "Punkte",
                            render: (data) => data == null ? "-" : data
                        }
                    ],
                    data: result
                });
            }
            table.find("td.dataTables_empty").html("Keine Daten vorhanden")
        }
    });
}