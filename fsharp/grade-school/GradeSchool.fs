module GradeSchool

type School = Map<int, string list>

let empty: School = Map.empty

let add (student: string) (grade: int) (school: School): School =
    let existing =
        Map.tryFind grade school |> Option.defaultValue []

    Map.add grade (student :: existing) school

let roster (school: School): string list =
    let flatten (grade, students) =
        students
        |> List.map (fun student -> grade, student)

    Map.toList school
    |> List.collect flatten
    |> List.sortBy id
    |> List.map snd

let grade (number: int) (school: School): string list =
    Map.tryFind number school
    |> Option.defaultValue []
    |> List.sort
