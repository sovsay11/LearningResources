def array_diff(a, b):
    arrayDiff = []
    array1 = []
    for number in a:
        if number not in b:
            array1.append(number)
    return array1
