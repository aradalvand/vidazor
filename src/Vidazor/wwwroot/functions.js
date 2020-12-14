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

export function subscribeToEvent(elm, instance, eventName) {
    elm.addEventListener(eventName, function () {
        instance.invokeMethodAsync('EventFired', eventName);
    });
}