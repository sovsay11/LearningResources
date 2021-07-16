def merge_the_tools(string, k):
    # just gotta split by k, then compare the results
    # so duplicates are removed
    substrings = []
    uniqueSubs = []

    # splitting the string into substrings
    for x in range(len(string)):
        if x % k == 0:
            substrings.append(string[x : x + k])

    # comparing the characters to each other
    # then adding the unique values to the uniqueSubs list
    for substring in substrings:
        unique = set(substring)
        print("".join(unique))
