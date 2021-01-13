export function getProperty(elm, propertyName) {
    var value = elm[propertyName];

    // The "TimeRanges" type is a custom enumeration and cannot be processed by the JSON serializer.
    // Therefore, we have to convert it into a regular array containing plain objects.
    if (value instanceof TimeRanges) {
        var reshapedTimeRanges = new Array();
        for (var i = 0; i < value.length; i++)
            reshapedTimeRanges.push({
                start: value.start(i),
                end: value.end(i)
            });
        value = reshapedTimeRanges;
    }

    return value;
}

export function setProperty(elm, propertyName, value) {
    elm[propertyName] = value;
}

export function invokeFunction(elm, functionName, ...args) {
    return elm[functionName](...args);
}

const _listeners = [];

export function subscribeToEvent(elm, instance, eventName) {
    var listener = function () {
        instance.invokeMethodAsync('EventFired', eventName);
    };
    elm.addEventListener(eventName, listener);
    _listeners.push({
        elm: elm,
        eventName: eventName,
        listener: listener,
    });
}

export function dropAllEventListeners(elm) {
    for (var i = _listeners.length - 1; i >= 0; i--) { // The reason why we loop through the array in reverse is so that we could remove the items in it without breaking the loop.
        var listener = _listeners[i];
        if (listener.elm == elm) {
            elm.removeEventListener(listener.eventName, listener.listener);
            _listeners.splice(i, 1);
        }
    }
}