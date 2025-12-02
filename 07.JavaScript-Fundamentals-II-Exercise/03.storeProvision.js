function storeProvision(currentStock, orderedStock){
    let store = {} // празен оберк -> ще го ползваме за речник

    for (let i = 0; i < currentStock.length; i+=2) {
        const productName = currentStock[i];      // само четни индекси
        const quantity = Number(currentStock[i+1])// само нечетни индекси
        
        store[productName] = quantity
    }

    for (let i = 0; i < orderedStock.length; i+=2) {
        const productName = orderedStock[i]; // само четни индекси
        const quantity = Number(orderedStock[i+1])   //само нечетни индекси
        
        if(store.hasOwnProperty(productName)){ // проверяваме имаме ли такъв продукт (ключ/пропърти)
            store[productName] += quantity // добавяме количество кум съществуващ продукт (ключ)
        } else {
            store[productName] = quantity // добавям нов продукт (ключ) в магазина
        }
    }

    for (const key in store) {
        console.log(`${key} -> ${store[key]}`)    
    }
}

storeProvision(
['Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'],
['Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30']
)