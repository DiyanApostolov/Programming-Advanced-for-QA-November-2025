function mergeArrays(arr1, arr2) {
    let newArray = [];

    for (let i = 0; i < arr1.length; i++) {
        // ['5', '15', '23', '56', '35'],
        // ['17', '22', '87', '36', '11']

        let element1 = arr1[i]
        let element2 = arr2[i]

        if (i % 2 === 0){
            // прибавяме сумата на елементите като числа
            newArray.push(Number(element1) + Number(element2))
        } else {
            // прибавяме двата елемента конкатенирани
            newArray.push(element1 + element2)
        } 
    }

    console.log(newArray.join(' - '))
}

mergeArrays(
    ['5', '15', '23', '56', '35'],
    ['17', '22', '87', '36', '11']
)