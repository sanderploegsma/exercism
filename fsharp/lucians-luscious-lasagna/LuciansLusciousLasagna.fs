module LuciansLusciousLasagna

let expectedMinutesInOven = 40

let remainingMinutesInOven minutesInOven = 
    expectedMinutesInOven - minutesInOven

let preparationTimeInMinutes numberOfLayers = 
    2 * numberOfLayers

let elapsedTimeInMinutes numberOfLayers minutesInOven = 
    (preparationTimeInMinutes numberOfLayers) + minutesInOven
