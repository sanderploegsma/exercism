object Hamming {
    fun compute(leftStrand: String, rightStrand: String): Int {
        require(leftStrand.length == rightStrand.length) {
            "left and right strands must be of equal length"
        }

        return leftStrand.zip(rightStrand).count { (l, r) -> l != r }
    }
}
