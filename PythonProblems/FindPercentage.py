if __name__ == "__main__":
    n = int(input())
    student_marks = {}
    # Grabs the data and provides lists for us to use
    for _ in range(n):
        name, *line = input().split()
        scores = list(map(float, line))
        student_marks[name] = scores
    # Asks for a specific name percentage
    query_name = input()

    totalSum = 0
    if query_name in student_marks:
        for score in student_marks[query_name]:
            totalSum += score

    print(format(totalSum / len(student_marks[query_name]), ".2f"))
