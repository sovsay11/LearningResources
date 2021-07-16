def sort_array(source_array):
    # Logic... grab all the odd numbers and add them to an array
    oddNumbers = []
    sortedArray = []
    for number in source_array:
        if number % 2 == 1:
            oddNumbers.append(number)
    oddNumbers.sort(reverse=True)

    # Now gotta iterate through the actual list and add the odd numbers there...
    for x in range(len(source_array)):
        if source_array[x] % 2 == 1:
            source_array[x] = oddNumbers[len(oddNumbers) - 1]
            oddNumbers.pop()
    return source_array
