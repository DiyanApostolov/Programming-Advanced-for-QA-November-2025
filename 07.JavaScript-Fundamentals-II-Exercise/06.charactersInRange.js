function solve(a, b){
    let start = Math.min(a.charCodeAt(), b.charCodeAt()) // трябва ми индекса на символа от ASCII
    let end = Math.max(a.charCodeAt(), b.charCodeAt())

    let charsArray = []

    for (let i = start + 1; i < end; i++) {
        let currentChar = String.fromCharCode(i) // от индекс го обдъщам в ASCII char
        charsArray.push(currentChar)
    }

    console.log(charsArray.join(' '))
}

solve('g', 'a')