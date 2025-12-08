import {isOddOrEven} from '../isOddOrEven.js'
import { describe } from 'mocha'
import { expect } from 'chai'

describe('test_isOddOrEven', () => {
    it('shoud return undefined if input parameter is not a string', () => {
        // Arrange
        let input = 42;

        // Act
        let result = isOddOrEven(input)

        // Assert
        expect(result).to.be.undefined                  // number
        expect(isOddOrEven([42])).to.be.undefined       // array
        expect(isOddOrEven({})).to.be.undefined         // object
        expect(isOddOrEven(null)).to.be.undefined       // null
        expect(isOddOrEven(undefined)).to.be.undefined  // undefined

    })
    it('shoud return text even if input parameter is with even length', () => {
        // Arrange
        let input = 'text'
        let expected = 'even'

        // Act
        let result = isOddOrEven(input)

        // Assert
        expect(result).to.equal(expected)
    })
    it('shoud return text odd if input parameter is with odd length', () => {
        // Arrange
        let input = 'Hello'
        let expected = 'odd'

        // Act
        let result = isOddOrEven(input)

        // Assert
        expect(result).to.equal(expected)
    })
})