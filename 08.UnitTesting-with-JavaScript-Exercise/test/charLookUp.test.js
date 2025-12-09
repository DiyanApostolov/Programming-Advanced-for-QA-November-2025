import {lookupChar} from '../charLookUp.js'
import { expect } from 'chai'

describe('test_charLokUp', () => {
    it('should return undefined if first parameter is not a string', () => {
        expect(lookupChar(42, 5)).to.be.undefined
        expect(lookupChar([], 5)).to.be.undefined
        expect(lookupChar({}, 5)).to.be.undefined
        expect(lookupChar(null, 5)).to.be.undefined
        expect(lookupChar(undefined, 5)).to.be.undefined
    })
    it('should return undefined if second parameter is not am integer umber', () =>{
        expect(lookupChar('valid text', '2')).to.be.undefined
        expect(lookupChar('valid text', 5.5)).to.be.undefined
        expect(lookupChar('valid text', [4])).to.be.undefined
        expect(lookupChar('valid text', {})).to.be.undefined
        expect(lookupChar('valid text', null)).to.be.undefined
        expect(lookupChar('valid text', undefined)).to.be.undefined
    })
    it('should return "Incorrect index" if index is out of range', ()=>{
        // Arrange
        let exected = "Incorrect index"

        // Act & Assert
        expect(lookupChar('hello', -1)).to.equal(exected) // negative index
        expect(lookupChar('hello', 5)).to.equal(exected) // index equal length
        expect(lookupChar('hello', 10)).to.equal(exected) // index greater than length
    })
    it('should return characrer if all parameteres are valid', () => {
        expect(lookupChar('Diyan', 0)).to.equal('D')
        expect(lookupChar('Diyan', 2)).to.equal('y')
        expect(lookupChar('Diyan', 4)).to.equal('n')
    })
})