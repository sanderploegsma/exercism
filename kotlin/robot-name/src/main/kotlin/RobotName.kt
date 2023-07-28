class Robot {
    companion object {
        private val namesInUse = mutableSetOf<String>()
        private val alpha = ('A'..'Z')
        private val numeric = ('0'..'9')
        private val nameRecipe = listOf(alpha, alpha, numeric, numeric, numeric)
        private val maxNumberOfNames = nameRecipe.fold(1) { n, r -> n * r.toList().size }
    }

    lateinit var name: String
        private set

    init {
        reset()
    }

    fun reset() {
        require(namesInUse.size < maxNumberOfNames) { "Robot names exhausted" }

        name = generateSequence(::generateName).first { namesInUse.add(it) }
    }

    private fun generateName() = nameRecipe.map { it.random() }.joinToString("")
}
