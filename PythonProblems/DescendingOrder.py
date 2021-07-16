def descending_order(num):
    reversedList = sorted(str(num), reverse=True)
    reversedNum = "".join(reversedList)
    return int(reversedNum)
