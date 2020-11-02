$(document).ready(() => {
    setBackgroundCanvas();
    generateTooltips();
});

function setBackgroundCanvas() {
    let currentInterval = null;

    let canvas = document.getElementById("background-canvas");
    let context = canvas.getContext("2d");
    let stars = [];

    resizeBackground();

    function clearBackground() {
        context.clearRect(0, 0, canvas.width, canvas.height);
    }
    function resizeBackground() {
        let box = $("body");
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
            generateBackground();
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
                    drawBackground();
                }
            }
        });
    }
    function drawBackground() {
        clearInterval(currentInterval);
        currentInterval = setInterval(() => {
            clearBackground();
            resizeBackground();
            for (let curStar of stars) {
                strokeStar(curStar);
                animateStar(curStar);
            }
        }, 62.5);
        
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
        function animateStar(star) {
            scaleRadius();
            scaleAlpha();

            function scaleAlpha() {
                if (star.ScaleAlpha.Counter >= star.ScaleAlpha.MaximalValue) {
                    star.ScaleAlpha.GoesUp = false;
                } else if (star.ScaleAlpha.Counter <= star.ScaleAlpha.MinimalValue) {
                    star.ScaleAlpha.GoesUp = true;
                }

                switch (star.ScaleAlpha.GoesUp) {
                    case false:
                        star.Color.Alpha -= 0.01;
                        star.ScaleAlpha.Counter--;
                        break;
                    case true:
                    default:
                        star.Color.Alpha += 0.01;
                        star.ScaleAlpha.Counter++;
                        break;
                }
            }
            function scaleRadius() {
                if (star.ScaleStar.Counter >= star.ScaleStar.MaximalValue) {
                    star.ScaleStar.GoesUp = false;
                } else if (star.ScaleStar.Counter <= star.ScaleStar.MinimalValue) {
                    star.ScaleStar.GoesUp = true;
                }

                switch (star.ScaleStar.GoesUp) {
                    case false:
                        star.OuterRadius -= 0.05;
                        star.InnerRadius -= 0.05;
                        star.ScaleStar.Counter--;
                        break;
                    case true:
                    default:
                        star.OuterRadius += 0.05;
                        star.InnerRadius += 0.05;
                        star.ScaleStar.Counter++;
                        break;
                }
            }
        }
    }
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