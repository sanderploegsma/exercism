module AnnalynsInfiltration

let canFastAttack = not

let canSpy (knightIsAwake: bool) (archerIsAwake: bool) (prisonerIsAwake: bool): bool =
    knightIsAwake || archerIsAwake || prisonerIsAwake

let canSignalPrisoner (archerIsAwake: bool) (prisonerIsAwake: bool): bool =
    prisonerIsAwake && (not archerIsAwake)

let canFreePrisoner (knightIsAwake: bool) (archerIsAwake: bool) (prisonerIsAwake: bool) (petDogIsPresent: bool): bool =
    petDogIsPresent && (not archerIsAwake) || (not knightIsAwake) && (not archerIsAwake) && prisonerIsAwake
