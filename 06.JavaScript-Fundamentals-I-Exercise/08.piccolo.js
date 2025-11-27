function piccolo(arr){
    let parkingLot = []
    
    for (const carInfo of arr) {
        let direction = carInfo.split(', ')[0]
        let carNumber = carInfo.split(', ')[1]

        if (direction === 'IN'){
            // проверяваме дали колата вече не е в паркинга
            if(!parkingLot.includes(carNumber)){
                parkingLot.push(carNumber)
            }
        } else if (direction === 'OUT'){
                // намирам къде в паркинга (на кой индекс) се нанира колата
                let carIndex = parkingLot.indexOf(carNumber)

                // проверявам дали има такъв индекс
                if (carIndex !== -1){
                    // премахвам един елемент на конкретния индекс
                    parkingLot.splice(carIndex, 1)
                }
        }

    }

    if (parkingLot.length > 0){
        for (const carNumber of parkingLot.sort()) {
            console.log(carNumber)
        }
    } else {
        console.log("Parking Lot is Empty")
    }
}

piccolo(['IN, CA2844AA',
'IN, CA1234TA',
'OUT, CA2844AA',
'IN, CA9999TT',
'IN, CA2866HI',
'OUT, CA1234TA',
'IN, CA2844AA',
'OUT, CA2866HI',
'IN, CA9876HH',
'IN, CA2822UU']
)