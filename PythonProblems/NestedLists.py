if __name__ == '__main__':
    studentList = []
    studentScores = []
    for _ in range(int(input())):
        name = input()
        score = float(input())
        studentList.append([name, score])
        studentScores.append(score)
        
    studentScores.sort()
    
    # variables for the smallest and largest values
    smallest = studentScores[0]
    secondValue = None
    i = 0
    while True:
        if studentScores[i] == smallest:
            i += 1
        else:
            secondValue = studentScores[i]
            break
        
    studentList.sort()
    
    for student in studentList:
        if student[1] == secondValue:
            print(student[0])
