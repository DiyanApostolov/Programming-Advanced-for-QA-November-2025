function oddOccurrences(text){
    // правя си всички букви в изречение да са малки (case-insensitive)
    // разделям думиите в масив по интервал
    let words = text.toLowerCase().split(' ')

    // създавам с един празен обект (речник)
    let outputWords = {}

    for (const word of words) {
        // проверявам дали този ключ съществува
        if(word in outputWords){
            outputWords[word]++
        } else {
            outputWords[word] = 1
        }
    }

    // създавам си празен масив за думите срещнати нечетен брой пъти
    let outputArray = []

    // този for-in цикъл връша само ключвете!!!
    for (const key in outputWords) {
        if(outputWords[key] % 2 !== 0){
            outputArray.push(key)
        }  
    }

    console.log(outputArray.join(' '))
}

oddOccurrences('Java C# Php PHP Java PhP 3 C# 3 1 5 C#')
