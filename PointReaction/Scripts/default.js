$(document).ready(() => {
    setBackgroundCanvas();
    checkUserSettings();
});

function setBackgroundCanvas() {
    let canvas = document.getElementById("background-canvas");
    let context = canvas.getContext("2d");
    let stars = [];

    setInterval(() => {
        clearBackgroundCanvas();
        resizeBackgroundCanvas();

        if (stars == null || stars.length == 0) {
            getStars();
        }

        drawBackgroundCanvas();
    }, 62.5)

    function resizeBackgroundCanvas() {
        if (context.canvas.width != window.innerWidth || context.canvas.height != window.innerHeight) {
            context.canvas.width = window.innerWidth;
            context.canvas.height = window.innerHeight;
            getStars();
        }
    }
    
    function drawBackgroundCanvas() {
        for (let curStar of stars) {
            strokeStar(curStar);
        }

        function strokeStar(starSettings) {
            context.save();
            context.beginPath();
            context.translate(starSettings.PositionX, starSettings.PositionY);
            context.fillStyle = starSettings.Color;
            context.moveTo(0, 0 - starSettings.OuterRadius);
            
            if (starSettings.ScaleOptions.Count >= starSettings.ScaleOptions.Distance) {
                starSettings.ScaleOptions.Type = 1;
            } else if (starSettings.ScaleOptions.Count <= 0) {
                starSettings.ScaleOptions.Type = 0;
            }

            switch (starSettings.ScaleOptions.Type) {
                case 0:
                    starSettings.OuterRadius += starSettings.ScaleOptions.Value;
                    starSettings.InnerRadius += starSettings.ScaleOptions.Value;
                    starSettings.ScaleOptions.Count += 1;
                    break;
                case 1:
                default:
                    starSettings.OuterRadius -= starSettings.ScaleOptions.Value;
                    starSettings.InnerRadius -= starSettings.ScaleOptions.Value;
                    starSettings.ScaleOptions.Count -= 1;
                    break;
            }

            for (var i = 0; i < starSettings.Spikes; i++) {
                context.rotate(Math.PI /  starSettings.Spikes);
                context.lineTo(0, 0 - (starSettings.OuterRadius * starSettings.InnerRadius));
                context.rotate(Math.PI / starSettings.Spikes);
                context.lineTo(0, 0 - starSettings.OuterRadius);
            }

            context.closePath();
            context.fill();
            context.restore();
        }
    }

    function getStars() {
        $.ajax({
            url: "/Services/Game.svc/GenerateBackgroundStars",
            method: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            data: {
                starsCount: 200,
                maximalGameWidth: context.canvas.width,
                maximalGameHeight: context.canvas.height
            },
            success: (result) => {
                stars = JSON.parse(result.d);
            }
        });
    }

    function clearBackgroundCanvas() {
        context.clearRect(0, 0, canvas.width, canvas.height);
    }
}


function checkUserSettings() {
    /* Ajax, welcher mir die User-Einstellungen angibt */
}