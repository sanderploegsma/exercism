package lasagna

// PreparationTime calculates the estimated preparation time of the lasagna
// based on the number of layers and the average time per layer.
func PreparationTime(layers []string, timePerLayer int) int {
	if timePerLayer <= 0 {
		timePerLayer = 2
	}

	return len(layers) * timePerLayer
}

// Quantities calculates the amount of noodles and amount of sauce needed
// based on the number of layers.
func Quantities(layers []string) (noodles int, sauce float64) {
	noodles = 0
	sauce = 0.0

	for _, layer := range layers {
		switch layer {
		case "noodles":
			noodles += 50
		case "sauce":
			sauce += 0.2
		}
	}

	return
}

// AddSecretIngredient adds the friend's secret ingredient to my list of ingredients.
func AddSecretIngredient(friendsList, myList []string) {
	sourceIndex := len(friendsList) - 1
	targetIndex := len(myList) - 1

	myList[targetIndex] = friendsList[sourceIndex]
}

// ScaleRecipe calculates the quantities needed to cook the given amount of portions.
// The given quantities are amounts needed for 2 portions.
func ScaleRecipe(quantities []float64, portions int) []float64 {
	scaled := make([]float64, len(quantities))

	for i, q := range quantities {
		scaled[i] = q * float64(portions) / 2
	}

	return scaled
}
