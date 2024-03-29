const tileDisplay = document.querySelector('.tile-container')
const keyboard = document.querySelector('.key-container')
const messageDisplay = document.querySelector('.message-container')

const wordle = 'SUPER'
const keys=[
    'Q',
    'W',
    'E',
    'R',
    'T',
    'Y',
    'U',
    'I',
    'O',
    'P',
    'A',
    'S',
    'D',
    'F',
    'G',
    'H',
    'J',
    'K',
    'L',
    'ENTER',
    'Z',
    'X',
    'C',
    'V',
    'B',
    'N',
    'M',
    '«',
]
const guessRows = [
    ['','','','',''],
    ['','','','',''],
    ['','','','',''],
    ['','','','',''],
    ['','','','',''],
    ['','','','','']
]
let currentRow = 0
let currentTile = 0
let isGameover = false;

guessRows.forEach((guessRow,guessRowIndex) => {
    const rowElement = document.createElement('div')
    rowElement.setAttribute('id','guessRow-' + guessRowIndex)
    guessRow.forEach((guess, guessIndex) => {
       const tileElement = document.createElement('div')
       tileElement.setAttribute('id','guessRow-'+ guessRowIndex + '-tile-'+ guessIndex)
       tileElement.classList.add('tile')
       
       rowElement.append(tileElement)
    })
    tileDisplay.append(rowElement)
    //const append update
})

keys.forEach(key => {
    const buttonElement = document.createElement('button')
    buttonElement.textContent = key
    buttonElement.setAttribute('id', key)
    buttonElement.addEventListener('click',() => handleClick(key))
    keyboard.append(buttonElement)
})

const handleClick = (letter) => {
    console.log('clicked', letter)
    if(letter === '«'){
      //  console.log('delete letter')
      deleteLetter()
      console.log('guessRows', guessRows)
        return 
    }
    if(letter === 'ENTER'){
        checkRow()
        console.log('guessRows', guessRows)
        return 
    }
    addLetter(letter)
    console.log('guessRows', guessRows)
}

const addLetter = (letter) => {
    if(currentTile < 5 && currentRow < 6){

    const tile = document.getElementById('guessRow-' + currentRow + '-tile-'+ currentTile)
    tile.textContent = letter 
    guessRows[currentRow][currentTile] = letter
    tile.setAttribute('data',letter)
    currentTile++

}
}

const deleteLetter = () => {
    if(currentTile > 0){
    currentTile--
    const tile = document.getElementById('guessRow-' + currentRow + '-tile-' + currentTile) //여기 -의 의미 찾기.
    tile.textContent = ''
    guessRows[currentRow][currentTile] = ''
    tile.setAttribute('data', '')
}
}

const checkRow = () => {
    const guess = guessRows[currentRow].join('')
    
    if(currentTile > 4){
      console.log('guess is' + guess, 'worlde is ' + wordle)
      flipTile()
    if(wordle == guess){
        showMessage('magnificent!')
        isGameover = true;
        return
    }else{
        if(currentRow >= 5){
            isGameover = true;
            showMessage('Game Over! ;) ')
            return
        }
        if(currentRow < 5){
            currentRow++
            currentTile = 0
        }
      }
    }
}


const showMessage = (message) =>{
   const messageElement = document.createElement('p')
   messageElement.textContent = message
   messageDisplay.append(messageElement)
   setTimeout(() => messageDisplay.removeChild(messageElement).ATTRIBUTE_NOD,2000) //it will be disapprear after 2000sec

}

const flipTile =() => {
 const rowTiles = document.querySelector('#guessRow-' + currentRow).childNodes //#guess를 사용하는 이유는 id이기 떄문이다 57분참조
rowTiles.forEach((tile,index) => {
   const dataLetter = tile.getAttribute('data')
   
   if(dataLetter == wordle[index]){
    tile.classList.add('green-overlay')
   } else if(wordle.includes(dataLetter)){
    tile.classList.add('yellow-overlay')
   } else{
    tile.classList.add('grey-overlay')
   }

})


}
