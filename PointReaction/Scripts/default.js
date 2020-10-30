$(document).ready(() => {
    setBackgroundCanvas();
    generateTooltips();
});

function setBackgroundCanvas() {
    let canvas = document.getElementById("background-canvas");
    let context = canvas.getContext("2d");
    let stars = [];

    function clearBackground() {
        context.clearRect(0, 0, canvas.width, canvas.height);
    }
    function resizeBackground() {
        let body = $("body");
        let bHeight = body.height();
        let bWidth = body.width();
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
            generateBackground();
        } else {
            getStars();
        }
    }
    function generateBackground() {
        $.ajax({
            url: "/Services/Home.svc/GenerateBackground",
            method: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: {
                backgroundWidth: context.canvas.width,
                backgroundHeight: context.canvas.height
            },
            success: () => {
                getStars();
            }
        });
    }
    function getStars() {
        $.ajax({
            url: "/Services/Home.svc/GetBackgroundStars",
            method: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: (result) => {
                result = JSON.parse(result.d);
                if (result != null) {
                    stars = result;
                }
            }
        });
    }
    function drawBackground() {
        for (let curStar of stars) {
            strokeStar(curStar);
        }

        function strokeStar(star) {
            context.save();
            context.beginPath();
            context.translate(star.X, star.Y);
            context.fillStyle = getCorrectRGBA(star.Color.Red, star.Color.Green, star.Color.Blue, star.Color.Alpha);
            context.moveTo(0, -star.OuterRadius);

            for (var i = 0; i < star.Spikes; i++) {
                context.rotate(Math.PI /  star.Spikes);
                context.lineTo(0, 0 - (star.OuterRadius * star.InnerRadius));
                context.rotate(Math.PI / star.Spikes);
                context.lineTo(0, 0 - star.OuterRadius);
            }

            context.closePath();
            context.fill();
            context.restore();
        }
    }

    setInterval(() => {
        clearBackground();
        resizeBackground();
        drawBackground();
    }, 62.5);
}

function generateTooltips() {
    $(function () {
        $('[title]').tooltip({
            trigger: "hover",
            boundary: "window",
            html: true,
            offset: "center",
            placement: "right"
        });
    });
}

function getCorrectRGBA(red, green, blue, alpha) {
    return "rgba(" + red + ", " + green + ", " + blue + ", " + alpha +")";
}