// подгод с анонимен обект
function employees(array){
    let person = {} // анонимен обект

    for (const element of array) {
        person.name = element
        person.personalNumber = element.length
        console.log(`Name: ${person.name} -- Personal Number: ${person.personalNumber}`)
    }
}

// подход с клас
function employees(array){
    class Employee{
        constructor(name, personalNum){
            this.name = name
            this.personalNumber = personalNum
        }

        printInfo(){
            return `Name: ${this.name} -- Personal Number: ${this.personalNumber}`;
        }
    }

    for (const name of array) {
        let personalNumber = name.length

        // вдигам си нова инстанция на класа Employee
        let currentEmployee = new Employee(name, personalNumber)  

        console.log(currentEmployee.printInfo())
    }
}

employees([
'Silas Butler',
'Adnaan Buckley',
'Juan Peterson',
'Brendan Villarreal'
]
)