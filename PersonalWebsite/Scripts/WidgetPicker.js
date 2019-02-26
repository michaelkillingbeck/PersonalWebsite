const newWidgetUpdateInterval = 1500;
const widgetLifetime = 7500;

setInterval(function () {
    updateRandomWidget();
}, newWidgetUpdateInterval);

function updateRandomWidget() {
    var widgets = document.querySelectorAll('.widgetHolder:not(.active)');
    var index = Math.round(Math.random() * widgets.length);
    var selectedWidget = widgets[index];

    selectedWidget.classList.add('active');
    selectedWidget.style.opacity = 0;

    setTimeout(function () {
        selectedWidget.innerHTML = getWidgetDetails();
        selectedWidget.style.opacity = 1;

        setTimeout(function () {
            removeActiveWidget(selectedWidget);
        }, widgetLifetime);
    }, 500);
}

function getWidgetDetails() {
    var xmlHttp = new XMLHttpRequest();
    xmlHttp.open("GET", 'http://localhost:53766/Home/Widget', false);
    xmlHttp.send(null);
    return xmlHttp.responseText;
}

function removeActiveWidget(widget) {
    widget.style.opacity = 0;
    setTimeout(function () {
        widget.classList.remove('active');
    }, 500);
}