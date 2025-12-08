function isOddOrEven(inputText) {
    if (typeof(inputText) !== 'string') {
        return undefined;
    }
    if (inputText.length % 2 === 0) {
        return "even";
    }

    return "odd";
}

export{
    isOddOrEven
}
