function wordTracker(arr){
    // масив с димите за следене на съвадения
    let wordsToTrack = arr.shift().split(' ')

    // създавам с един празен обект (ще го ползваме като речник)
    let outputWords = {}

    // обикалям всички думи в wordsToTrack и ги добавям като ключове със стойност 0
    for (const word of wordsToTrack) {
        outputWords[word] = 0
    }

    // обикалям всички думи във входния масив и търсим съвпадения
    for (const currentWord of arr) {
        // проверка дали има такъв ключ в речинка
        if(currentWord in outputWords){
            outputWords[currentWord]++
        }
    }

    // в JS не можем директно да сортираме речник (обект)
    // преобразувам речника в масив
    let entries = Object.entries(outputWords)

    // сортираме масива с ключове и стойности, в обратен ред по стойност[1]
    entries.sort((a, b) => b[1] - a[1]) 

    for(let [word, count] of entries){
        console.log(`${word} - ${count}`)
    }
}

wordTracker([
'In this sentence', 
'In', 'this', 'sentence','sentence','sentence', 'you', 'have', 'to', 'count', 'the', 'occurrences', 'of', 'the', 'words', 'this', 'and', 'sentence', 'because', 'this', 'is', 'your', 'task'
]
)