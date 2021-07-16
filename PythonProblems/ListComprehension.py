if __name__ == "__main__":
    x = int(input())
    y = int(input())
    z = int(input())
    n = int(input())

    # Need to grab the data
    # If x is 3, we iterate and add the numbers 0, 1, 2, and 3 to
    # the list
    xList = [xNum for xNum in range(x + 1)]
    yList = [yNum for yNum in range(y + 1)]
    zList = [zNum for zNum in range(z + 1)]

    combinedList = [
        [a, b, c] for a in xList for b in yList for c in zList if a + b + c != n
    ]

    print(combinedList)
