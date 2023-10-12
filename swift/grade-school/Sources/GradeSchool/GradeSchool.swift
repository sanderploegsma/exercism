class GradeSchool {
  private var students: [String: Int]

  init() {
    students = [:]
  }

  func addStudent(_ name: String, grade: Int) -> Bool {
    guard students[name] == nil else {
      return false
    }

    students[name] = grade
    return true
  }

  func roster() -> [String] {
    let grades = Set(students.values)
    return grades.sorted().flatMap { studentsInGrade($0) }
  }

  func studentsInGrade(_ grade: Int) -> [String] {
    Array(students.filter { $1 == grade }.keys).sorted()
  }
}
