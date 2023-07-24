class Triangle(a: Double, b: Double, c: Double) {

    constructor(a: Int, b: Int, c: Int): this(a.toDouble(), b.toDouble(), c.toDouble())

    init {
        require(a + b > c)
        require(a + c > b)
        require(b + c > a)
    }

    private val sides = setOf(a, b, c)

    val isEquilateral: Boolean = sides.size == 1
    val isIsosceles: Boolean = sides.size <= 2
    val isScalene: Boolean = sides.size == 3
}
