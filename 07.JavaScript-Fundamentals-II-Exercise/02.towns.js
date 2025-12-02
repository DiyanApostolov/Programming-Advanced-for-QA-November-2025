function towns (inputArray){
    class Town{
        constructor(name, lat, long){
            this.name = name
            this.latitude = Number(lat)
            this.longitude = Number(long)
        }
    }

    for (const element of inputArray) {
        // фукционално си инициализирам три променливи 
        let [name, latitude, longitude] = element.split(' | ')

        // нова инстанция на Town
        let city = new Town(name, latitude, longitude)

        console.log(`{ town: '${city.name}', latitude: '${city.latitude.toFixed(2)}', longitude: '${city.longitude.toFixed(2)}' }`)
    }
}

towns(['Sofia | 42.696552 | 23.32601',
'Beijing | 39.913818 | 116.363625']
)