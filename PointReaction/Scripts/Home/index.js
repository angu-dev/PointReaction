$(document).ready(() => {
    generateAnimationCanvas();
});

function generateAnimationCanvas() {
    let canvas = document.getElementById("animation-canvas");
    let context = canvas.getContext("2d");

    let dots = [];
    setInterval(() => {
        clearAnimationCanvas();
        resizeAnimationCanvas();

        if (dots == null || dots.length == 0) {
            getAnimationDots();
        }

        drawAnimationCanvas();
    }, 62.5)

    function resizeAnimationCanvas() {
        let box = $("#game-animation-area");
        let bHeight = box.height();
        let bWidth = box.width();
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
            getAnimationDots();
        }
    }

    function drawAnimationCanvas() {
        for (let curDot of dots) {
            strokeDot(curDot);
        }

        function strokeDot(dotSettings) {
            context.beginPath();
            context.arc(dotSettings.PositionX, dotSettings.PositionY, dotSettings.Radius, 0, 2 * Math.PI);
            context.stroke();
            context.fillStyle = getCorrectRGBA(dotSettings.ColorOptions.Red, dotSettings.ColorOptions.Green, dotSettings.ColorOptions.Blue);
            context.fill();
        }
    }

    function getAnimationDots() {
        $.ajax({
            url: "/Services/Game.svc/GenerateAnimationDots",
            method: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            data: {
                dotsCount: 50,
                maximalGameWidth: context.canvas.width,
                maximalGameHeight: context.canvas.height
            },
            success: (result) => {
                dots = JSON.parse(result.d);
                console.log(dots)
            }
        });
    }

    function clearAnimationCanvas() {
        context.clearRect(0, 0, canvas.width, canvas.height);
    }
}