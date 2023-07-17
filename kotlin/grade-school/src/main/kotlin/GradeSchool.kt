class School {
    private val roster = mutableMapOf<Int, List<String>>()

    fun add(student: String, grade: Int) {
        roster[grade] = roster.getOrDefault(grade, listOf()) + student
    }

    fun grade(grade: Int) = roster.getOrDefault(grade, listOf()).sorted()

    fun roster() = roster.keys.sorted().flatMap(::grade)
}
