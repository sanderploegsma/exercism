rna_complement('G', 'C').
rna_complement('C', 'G').
rna_complement('T', 'A').
rna_complement('A', 'U').

rna_transcription(Rna, Dna) :-
    string_chars(Rna, RnaNucleotides),
    maplist(rna_complement, RnaNucleotides, DnaNucleotides),
    string_chars(Dna, DnaNucleotides).
