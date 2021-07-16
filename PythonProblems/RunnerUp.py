if __name__ == "__main__":
    n = int(input())
    arr = map(int, input().split())
    maxValue = -101
    runnerUp = -101
    for number in arr:
        # if the second highest is less than the current number
        if runnerUp < number:
            # check if the maxValue is also less than the current number
            # 0 < 100, 0 < 100
            if maxValue < number:
                # if so, assign the runner up to the maxValue
                runnerUp = maxValue
                # and the maxValue to the current number
                maxValue = number
                # 0 and 100
            # but if the maxValue is actually greater than the next number
            # 100 > 50
            elif maxValue > number:
                # then we assign the runnerUp to the number
                # 100, 50
                runnerUp = number
    print(runnerUp)
