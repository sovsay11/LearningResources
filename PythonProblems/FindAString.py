def count_substring(string, sub_string):
    occurences = 0
    for index in range(len(string)):
        if string.startswith(sub_string, index):
            occurences += 1
    return occurences
