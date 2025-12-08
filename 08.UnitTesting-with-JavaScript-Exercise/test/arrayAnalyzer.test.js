import { analyzeArray } from "../arrayAnalyzer.js";
import { expect, assert } from "chai";

describe('test analyzeArray', () => {
    it('shoud return undefined if input parameter is not an array or empty array', () => {
        expect(analyzeArray(42)).to.be.undefined
        expect(analyzeArray('text')).to.be.undefined
        expect(analyzeArray({})).to.be.undefined
        expect(analyzeArray(null)).to.be.undefined
        expect(analyzeArray(undefined)).to.be.undefined

        expect(analyzeArray([])).to.be.undefined // empty array
    })
    it('if input is a single element array', () => {
        // сравняваме по пропъртира от върнатия обект
        expect(analyzeArray([5]).min).to.equal(5)
        expect(analyzeArray([5]).max).to.equal(5)
        expect(analyzeArray([5]).length).to.equal(1)

        // deepЕqual -> сравняваме дълбоко директно два обекта
        assert.deepEqual(analyzeArray([5]), { min: 5, max: 5, length: 1})
    })
    it('if input is a equal elements array', () => {
        // Assert
        let array = [5, 5, 5, 5]

        expect(analyzeArray(array).min).to.equal(5)
        expect(analyzeArray(array).max).to.equal(5)
        expect(analyzeArray(array).length).to.equal(4)
    })
    it('if input is a array with several numbers', () => {
        // Arrange
        let array = [-3, 5, 12, 42, 3]

        // Act & Assert
        expect(analyzeArray(array).min).to.equal(-3)
        expect(analyzeArray(array).max).to.equal(42)
        expect(analyzeArray(array).length).to.equal(5)
    })
})