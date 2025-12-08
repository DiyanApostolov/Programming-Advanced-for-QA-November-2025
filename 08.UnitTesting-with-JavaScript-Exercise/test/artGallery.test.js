import { artGallery } from "../artGallery.js"
import { expect } from "chai"

describe.only('artGallery', () => {
    describe('test addArtwork', () => {
        it('shoud throw an error if title is not a string', () => {
            let errorMessage = "Invalid Information!"
            expect(() => artGallery.addArtwork(42, '50 x 70', 'Picasso')).to.throw(errorMessage)
            expect(() => artGallery.addArtwork([], '50 x 70', 'Picasso')).to.throw(errorMessage)
            expect(() => artGallery.addArtwork({}, '50 x 70', 'Picasso')).to.throw(errorMessage)
            expect(() => artGallery.addArtwork(null, '50 x 70', 'Picasso')).to.throw(errorMessage)
        })
        it('shoud throw an error if artist is not a string', () => {
            let errorMessage = "Invalid Information!"
            expect(() => artGallery.addArtwork('Dove of peace', '50 x 70', 5)).to.throw(errorMessage)
            expect(() => artGallery.addArtwork('Dove of peace', '50 x 70', [])).to.throw(errorMessage)
            expect(() => artGallery.addArtwork('Dove of peace', '50 x 70', {})).to.throw(errorMessage)
            expect(() => artGallery.addArtwork('Dove of peace', '50 x 70', null)).to.throw(errorMessage)
        })
        it('shoud throw an error if dimension is not in valid format', () => {
            let errorMessage = "Invalid Dimensions!"
            expect(() => artGallery.addArtwork('Dove of peace', 42, 'Picasso')).to.throw(errorMessage)
            expect(() => artGallery.addArtwork('Dove of peace', [30, 50], 'Picasso')).to.throw(errorMessage)
            expect(() => artGallery.addArtwork('Dove of peace', '30x40', 'Picasso')).to.throw(errorMessage)
            expect(() => artGallery.addArtwork('Dove of peace', '75x 50', 'Picasso')).to.throw(errorMessage)
            expect(() => artGallery.addArtwork('Dove of peace', '75 x50', 'Picasso')).to.throw(errorMessage)
        })
        it('shoud throw an error if artist is not allowed', () => {
            // Arrange
            let invalidArtist = 'V.D. Maistora'
            let errorMessage = "This artist is not allowed in the gallery!"

            // Act & Assert
            expect(() => artGallery.addArtwork('Dove of peace', '30 x 50', invalidArtist)).to.throw(errorMessage)
        })
        it('shoud return proper message if all parameters are valid', () => {
            let message = `Artwork added successfully: 'Dove of peace' by Picasso with dimensions 50 x 70.`

            expect(artGallery.addArtwork('Dove of peace', '50 x 70', 'Picasso')).to.equal(message)
        })
    })
    describe('test calculateCosts', () => {
        it('shoud thrown an error if any parameter are not valid', () => {
            let errorMessage = "Invalid Information!"
            // first parameter is not a number
            expect(() => artGallery.calculateCosts('5', 10, true)).to.throw(errorMessage)
            // second parameter is not a number
            expect(() => artGallery.calculateCosts(5, '10', true)).to.throw(errorMessage)
            // third parameter is not a boolean
            expect(() => artGallery.calculateCosts(5, 10, 'text')).to.throw(errorMessage)
            // first parameter is negative number
            expect(() => artGallery.calculateCosts(-5, 10, true)).to.throw(errorMessage)
            // second parameter is negative number
            expect(() => artGallery.calculateCosts(5, -10, true)).to.throw(errorMessage)
        })
        it('with sponsor (true)', ()=> {
            let message = `Exhibition and insurance costs are 270$, reduced by 10% with the help of a donation from your sponsor.`
            expect(artGallery.calculateCosts(100, 200, true)).to.equal(message)
        })
        it('without sponsor (false)', ()=> {
            let message = `Exhibition and insurance costs are 300$.`
            expect(artGallery.calculateCosts(100, 200, false)).to.equal(message)
        })
    })
    describe('test organizeExhibits', () => {
        it('validate parameters -> thrown an error', () => {
            let errorMessage = "Invalid Information!"
            expect(() => artGallery.organizeExhibits('40', 100)).to.throw(errorMessage)
            expect(() => artGallery.organizeExhibits(40, '100')).to.throw(errorMessage)
            expect(() => artGallery.organizeExhibits(-40, 100)).to.throw(errorMessage)
            expect(() => artGallery.organizeExhibits(0, 100)).to.throw(errorMessage)
            expect(() => artGallery.organizeExhibits(40, -100)).to.throw(errorMessage)
            expect(() => artGallery.organizeExhibits(40, 0)).to.throw(errorMessage)
        })
        it('if result is lower than five', () => {
            let message = `There are only 3 artworks in each display space, you can add more artworks.`
            expect(artGallery.organizeExhibits(24, 7)).to.equal(message)
        })
        it('if result is greater than five', () => {
            let message = `You have 7 display spaces with 9 artworks in each space.`
            expect(artGallery.organizeExhibits(67, 7)).to.equal(message)
        })
    })
})