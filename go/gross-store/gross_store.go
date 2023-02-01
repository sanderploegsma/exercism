package gross

const Dozen = 12

// Units stores the Gross Store unit measurements.
func Units() map[string]int {
	return map[string]int{
		"quarter_of_a_dozen": Dozen / 4,
		"half_of_a_dozen":    Dozen / 2,
		"dozen":              Dozen,
		"small_gross":        10 * Dozen,
		"gross":              Dozen * Dozen,
		"great_gross":        Dozen * Dozen * Dozen,
	}
}

// NewBill creates a new bill.
func NewBill() map[string]int {
	return map[string]int{}
}

// AddItem adds an item to customer bill.
func AddItem(bill, units map[string]int, item, unit string) bool {
	quantity, ok := units[unit]
	if !ok {
		return false
	}

	if currentQuantity, ok := bill[item]; ok {
		bill[item] = currentQuantity + quantity
	} else {
		bill[item] = quantity
	}

	return true
}

// RemoveItem removes an item from customer bill.
func RemoveItem(bill, units map[string]int, item, unit string) bool {
	quantity, ok := units[unit]
	if !ok {
		return false
	}

	currentQuantity, ok := bill[item]
	if !ok {
		return false
	}

	newQuantity := currentQuantity - quantity

	if newQuantity < 0 {
		return false
	}

	if newQuantity == 0 {
		delete(bill, item)
		return true
	}

	bill[item] = newQuantity
	return true
}

// GetItem returns the quantity of an item that the customer has in his/her bill.
func GetItem(bill map[string]int, item string) (quantity int, ok bool) {
	quantity, ok = bill[item]
	return
}
