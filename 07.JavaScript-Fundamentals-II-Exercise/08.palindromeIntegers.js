function palindromeIntegers(inputArray){
    for (const element of inputArray) {
        console.log(isPalindrome(element))
    }

    function isPalindrome(num){
        let numAsAString = num.toString()
        let reversedString = numAsAString.split('').reverse().join('')

        if(numAsAString === reversedString){
            return true
        } else {
            return false
        }
    }
}

// функционално решение на задачата
function palindromeIntegers(inputArray){
    for (const element of inputArray) {
        console.log(element == element.toString().split('').reverse().join(''))
    }
}

palindromeIntegers([123,323,421,121])