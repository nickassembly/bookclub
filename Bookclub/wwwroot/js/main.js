(function () {
    window.logUser =
        window.logUser ||
    function (counter) {
        console.log(`Printing in Javascript counter: ${counter}`);
        }

    window.getFormattedMessage = window.getFormattedMessage ||
        function () {
            return "Hello from JavaScript to C#";
        }

    // calling back to an instance 
    // not useful IRL you would save to variable for use elsewhere. This is just to demo to show concepts
    window.invokeDotnetInstanceFunction = window.invokeDotnetInstanceFunction ||
        function (addressProvider) {
            addressProvider.invokeMethodAsync("GetAddress")
                .then(data => { console.log(data); })
        } 
}(window));