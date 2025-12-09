import { findNewApartment } from '../findNewApartment.js'
import { describe } from 'mocha'
import { expect, assert } from 'chai'

describe('test_findNewApartment', () =>{
    describe('isGoodLocation', () => {
        it('should throw error on invalid input', () => {
            // invalid city type
            expect(() => findNewApartment.isGoodLocation(42, true)).to.throw("Invalid input!")
            expect(() => findNewApartment.isGoodLocation([], true)).to.throw("Invalid input!")
            expect(() => findNewApartment.isGoodLocation(null, true)).to.throw("Invalid input!")

            // invalid boolen type
            expect(() => findNewApartment.isGoodLocation("Varna", 42)).to.throw("Invalid input!")
            expect(() => findNewApartment.isGoodLocation("Varna", {})).to.throw("Invalid input!")
            expect(() => findNewApartment.isGoodLocation("Varna", null)).to.throw("Invalid input!")
        });
        it('should return "This location is not suitable for you." if location is not valid', () => {
            expect(findNewApartment.isGoodLocation("Burgas", true)).to.equal("This location is not suitable for you.")
        });
        it('should return "You can go on home tour!" if location is good and public transport is available', () => {
            // Arange
            let message = "You can go on home tour!"
            // Act & Assert
            expect(findNewApartment.isGoodLocation("Sofia", true)).to.equal(message)
            expect(findNewApartment.isGoodLocation("Plovdiv", true)).to.equal(message)
            expect(findNewApartment.isGoodLocation("Varna", true)).to.equal(message)
        });
        it('should return "There is no public transport in area." if location is good but public transport is unavailable', () => {
            // Arange
            let message = "There is no public transport in area."
            // Act & Assert
            expect(findNewApartment.isGoodLocation("Sofia", false)).to.equal(message)
            expect(findNewApartment.isGoodLocation("Plovdiv", false)).to.equal(message)
            expect(findNewApartment.isGoodLocation("Varna", false)).to.equal(message)
        });
    }),
    describe('Test isLargeEnough', () => {
        it('Should return apartments that meet the wanted criteria for minimal square meters', () => {
            // Arange
            let apartmets = [30, 80, 40, 100, 50]
            let minimalSquareMeters = 50
            let expected = '80, 100, 50'

            // Act & Assert
            expect(findNewApartment.isLargeEnough(apartmets, minimalSquareMeters)).to.equal(expected)
        });

        it('Should throw error on onvalid input', () => {
            // first parameter is not an array
            expect(() => findNewApartment.isLargeEnough(42, 80)).to.throw("Invalid input!")
            expect(() => findNewApartment.isLargeEnough({}, 80)).to.throw("Invalid input!")
            expect(() => findNewApartment.isLargeEnough(null, 80)).to.throw("Invalid input!")
            expect(() => findNewApartment.isLargeEnough("array", 80)).to.throw("Invalid input!")

            // first parameter is empty array
            expect(() => findNewApartment.isLargeEnough([], 80)).to.throw("Invalid input!")

            // second parameter is not a number
            expect(() => findNewApartment.isLargeEnough([40, 60], "5")).to.throw("Invalid input!")
            expect(() => findNewApartment.isLargeEnough([40, 60], [])).to.throw("Invalid input!")
            expect(() => findNewApartment.isLargeEnough([40, 60], {})).to.throw("Invalid input!")
            expect(() => findNewApartment.isLargeEnough([40, 60], null)).to.throw("Invalid input!")
        });
    }),
    describe('isItAffordable', () => {
        it('should throw an error on invalid input', () => {
            // if price is not a number
            expect(() => findNewApartment.isItAffordable("cena", 50000)).to.throw("Invalid input!")
            // if budget is not a number
            expect(() => findNewApartment.isItAffordable(1000000, [])).to.throw("Invalid input!")
            // if price is <= 0
             expect(() => findNewApartment.isItAffordable(-100, 50000)).to.throw("Invalid input!")
             expect(() => findNewApartment.isItAffordable(0, 50000)).to.throw("Invalid input!")
             // if budget <= 0
            expect(() => findNewApartment.isItAffordable(1000000, -20)).to.throw("Invalid input!")
            expect(() => findNewApartment.isItAffordable(1000000, 0)).to.throw("Invalid input!")
        });
        it('should not be affordable if price is greater than budget', () => {
            let message = "You don't have enough money for this house!"
            expect(findNewApartment.isItAffordable(100000, 80000)).to.equal(message)
        });
        it('should be affordable if price is equal to or less than budget', () => {
            let message = "You can afford this home!"
            expect(findNewApartment.isItAffordable(100000, 120000)).to.equal(message)
            expect(findNewApartment.isItAffordable(100000, 100000)).to.equal(message)
        });
    })
})


