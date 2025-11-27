function partyTime(arr){
    let guestList = []

    while(arr[0] !== 'PARTY'){
        let guestNumber = arr.shift() // вадя госта от входния масив
        guestList.push(guestNumber)   // добавям госта в листа с гости
    }

    arr.shift() // премахвам 'PARTY' от входния масив

    for (const commingGuest of arr) {
        // проверявам дали идващия гост го има в списъка
        if(guestList.includes(commingGuest)){
            let guestIndex = guestList.indexOf(commingGuest)
            guestList.splice(guestIndex, 1) // прехамвам госта от листа (отбелязвам си, че е дошъл)
        }
    }

    let vipGuests = guestList.filter(guest => !isNaN(guest[0]))
    let regularGuests = guestList.filter(guest => isNaN(guest[0]))

    console.log(guestList.length)
    console.log(vipGuests.join('\n'))
    console.log(regularGuests.join('\n'))
}

partyTime(['m8rfQBvl',
'fc1oZCE0',
'UgffRkOn',
'7ugX7bm0',
'9CQBGUeJ',
'2FQZT3uC',
'dziNz78I',
'mdSGyQCJ',
'LjcVpmDL',
'fPXNHpm1',
'HTTbwRmM',
'B5yTkMQi',
'8N0FThqG',
'xys2FYzn',
'MDzcM9ZK',
'PARTY',
'2FQZT3uC',
'dziNz78I',
'mdSGyQCJ',
'LjcVpmDL',
'fPXNHpm1',
'HTTbwRmM',
'B5yTkMQi',
'8N0FThqG',
'm8rfQBvl',
'fc1oZCE0',
'UgffRkOn',
'7ugX7bm0',
'9CQBGUeJ'
]

)