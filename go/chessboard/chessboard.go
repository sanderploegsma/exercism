package chessboard

const (
	FirstRank = 1
	LastRank  = 8
)

// File contains the occupation status of all squares in a single file
type File []bool

// Chessboard contains all files on the chess board.
type Chessboard map[string]File

// CountInFile returns how many squares are occupied in the chessboard,
// within the given file.
func CountInFile(cb Chessboard, file string) int {
	occupied := 0
	for _, square := range cb[file] {
		if square {
			occupied++
		}
	}
	return occupied
}

// CountInRank returns how many squares are occupied in the chessboard,
// within the given rank.
func CountInRank(cb Chessboard, rank int) int {
	if rank < FirstRank || rank > LastRank {
		return 0
	}

	occupied := 0
	for _, file := range cb {
		if file[rank-1] {
			occupied++
		}
	}
	return occupied
}

// CountAll should count how many squares are present in the chessboard.
func CountAll(cb Chessboard) int {
	squares := 0
	for _, file := range cb {
		squares += len(file)
	}
	return squares
}

// CountOccupied returns how many squares are occupied in the chessboard.
func CountOccupied(cb Chessboard) int {
	occupied := 0
	for file := range cb {
		occupied += CountInFile(cb, file)
	}
	return occupied
}
