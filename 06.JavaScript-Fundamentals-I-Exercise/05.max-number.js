function maxNumber(arr){
    //[1, 4, 3, 2]
    let outputArray = []

    for (let i = 0; i < arr.length; i++) {
        let currentNumber = arr[i]
        let isTop = true
        
        // обикаляме всички елементи надясно от текущия
        for (let j = i + 1; j < arr.length; j++){
            let nextRightElement = arr[j]

            if(currentNumber <= nextRightElement){
                // ако наметрим поне едно по-голямо число, прекъсваме цикъла
                isTop = false
                break;
            }
        }

        // само ако isTop e true, го добавяме за изхода
        if(isTop){
            outputArray.push(currentNumber)
        }
    }

    console.log(outputArray.join(' '))
}

maxNumber([1, 4, 3, 2])
maxNumber([14, 24, 3, 19, 15, 17])
maxNumber([27, 19, 42, 2, 13, 45, 48])