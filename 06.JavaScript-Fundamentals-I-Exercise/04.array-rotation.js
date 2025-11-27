function arrayRotation(arr, rotations){
    //[51, 47, 32, 61, 21], 2

    for (let i = 1; i <= rotations; i++) {
        let firstElement = arr.shift(); // премахва и взима първия елеметн

        arr.push(firstElement) // добавяме елемента в края на масива 
    }

    console.log(arr.join(' '))
}

arrayRotation([51, 47, 32, 61, 21], 3)