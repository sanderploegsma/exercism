package protein

import "errors"

var (
	// ErrStop is returned when trying to convert a stop codon into protein.
	ErrStop = errors.New("encountered stop codon")

	// ErrInvalidBase is returned when an invalid codon is encountered.
	ErrInvalidBase = errors.New("invalid base")
)

var codonToProtein = map[string]string{
	"AUG": "Methionine",
	"UUU": "Phenylalanine",
	"UUC": "Phenylalanine",
	"UUA": "Leucine",
	"UUG": "Leucine",
	"UCU": "Serine",
	"UCC": "Serine",
	"UCA": "Serine",
	"UCG": "Serine",
	"UAU": "Tyrosine",
	"UAC": "Tyrosine",
	"UGU": "Cysteine",
	"UGC": "Cysteine",
	"UGG": "Tryptophan",
}

var stopCodons = []string{"UAA", "UAG", "UGA"}

// FromCodon translates the given codon to its corresponding protein.
func FromCodon(codon string) (string, error) {
	if protein, ok := codonToProtein[codon]; ok {
		return protein, nil
	}

	for _, c := range stopCodons {
		if c == codon {
			return "", ErrStop
		}
	}

	return "", ErrInvalidBase
}

// FromRNA translates the given RNA sequence to its corresponding sequence of proteins.
func FromRNA(rna string) ([]string, error) {
	proteins := make([]string, 0)

	for i := 0; i < len(rna); i += 3 {
		protein, err := FromCodon(rna[i : i+3])

		if err == ErrStop {
			break
		}

		if err != nil {
			return proteins, err
		}

		proteins = append(proteins, protein)
	}

	return proteins, nil
}
