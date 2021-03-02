// Package twofer is all about sharing.
package twofer

import "fmt"

// ShareWith shares some with you and me.
func ShareWith(name string) string {
	receiver := name
	if receiver == "" {
		receiver = "you"
	}

	return fmt.Sprintf("One for %s, one for me.", receiver)
}
